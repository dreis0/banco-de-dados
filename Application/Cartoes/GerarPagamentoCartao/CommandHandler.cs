using Application.Pedidos;
using Dapper;
using Domain;
using System.Data;

namespace Application.Cartoes
{
    public partial class GerarPagamentoCartao
    {
        public class CommandHandler
        {
            private readonly IDbConnection connection;
            private readonly ObterCartao.QueryHandler obterCartaoHandler;
            private readonly ObterPrecoTotalDoPedido.QueryHandler precoHandler;

            public CommandHandler(IDbConnection db, ObterCartao.QueryHandler cartaoHandler
                , ObterPrecoTotalDoPedido.QueryHandler preco)
            {
                connection = db;
                obterCartaoHandler = cartaoHandler;
                precoHandler = preco;
            }

            public void Handle(string cpf, int pedidoId, IDbTransaction transaction = null)
            {
                bool disposeTransaction = false;

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                if (transaction == null)
                {
                    transaction = connection.BeginTransaction();
                    disposeTransaction = true;
                }

                var cartao = obterCartaoHandler.Handle(cpf);
                decimal preco = (decimal)precoHandler.Handle(pedidoId);

                string sql = $"insert into {new PagamentoCartao().GetTableName()} " +
                            $" (PedidoId, CartaoId, Valor) " +
                            $" values (@PedidoId, @CartaoId, @Valor);";

                connection.Execute(sql, param: new
                {
                    PedidoId = pedidoId,
                    CartaoId = cartao.Id,
                    Valor = preco
                }, transaction: transaction);


                if (disposeTransaction)
                {
                    transaction.Dispose();
                    transaction.Commit();

                    connection.Close();
                }
            }
        }
    }
}
