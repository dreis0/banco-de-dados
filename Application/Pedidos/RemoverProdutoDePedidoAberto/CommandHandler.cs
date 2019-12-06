using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Pedidos
{
    public partial class RemoverProdutoDePedidoAberto
    {
        public class CommandHandler
        {
            private readonly IDbConnection connection;

            public CommandHandler(IDbConnection db)
            {
                connection = db;
            }

            public void Handle(int produtoId, string cpf)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    string sqlPedido = $"select " +
                                        $"Id " +
                                        $",Data " +
                                        $",CpfCliente " +
                                        $",StatusId" +
                                        $"from {new Pedido().GetTableName()} " +
                                        $"where CpfCliente = @Cpf and StatusId = @Status";

                    var pedido = connection.QuerySingleOrDefault(sqlPedido, new { Cpf = cpf, Status = (int)eStatusPedido.Pendente }, transaction: transaction);

                    if (pedido != null)
                    {
                        string sqlRemoveProduto = $"delete from PedidosProduto" +
                                                    $"where ProdutoId = @ProdutoId and PedidoId = @PedidoId";

                        connection.Execute(sqlRemoveProduto, new { ProdutoId = produtoId, PedidoId = pedido.Id }, transaction: transaction);
                    }

                    transaction.Commit();
                }

                connection.Close();
            }
        }
    }
}
