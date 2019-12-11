using Application.Cartoes;
using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Pedidos
{
    public partial class FecharPedido
    {
        public class CommandHandler
        {
            private readonly IDbConnection connection;
            private readonly GerarPagamentoCartao.CommandHandler pagamentoHandler;

            public CommandHandler(IDbConnection db
                , GerarPagamentoCartao.CommandHandler handler)
            {
                connection = db;
                pagamentoHandler = handler;
            }

            public void Handle(Command command)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var prod in command.Produtos)
                    {
                        string sqlQtd = $"update {new ProdutosPedido().GetTableName()} " +
                                    @"set Quantidade = @qtd
                                    where ProdutoId = @ProdutoId and PedidoId = @PedidoId";

                        connection.Execute(sqlQtd, param: new
                        {
                            qtd = prod.Quantidade,
                            ProdutoId = prod.ProdutoId,
                            PedidoId = command.PedidoId
                        }, transaction: transaction);

                    }

                    if (command.PagarComCartao)
                        pagamentoHandler.Handle(command.Cpf, command.PedidoId, transaction);

                    string sqlFecharPedido = $"update {new Pedido().GetTableName()} " +
                                            @"set StatusId = @status
                                            where Id = @PedidoId";

                    connection.Execute(sqlFecharPedido, param: new
                    {
                        status = (int)eStatusPedido.Fechado,
                        PedidoId = command.PedidoId
                    }, transaction: transaction);

                    transaction.Commit();
                }
            }
        }
    }
}
