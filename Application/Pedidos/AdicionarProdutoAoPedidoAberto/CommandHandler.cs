using Dapper;
using Domain;
using System;
using System.Data;

namespace Application.Pedidos
{
    public partial class AdicionarProdutoAoPedidoAberto
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
                if(connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var transaction = connection.BeginTransaction(IsolationLevel.Serializable))
                {

                    string sqlPedidoAberto = $"select Id" +
                                                $",Data" +
                                                $",CpfCliente" +
                                                $",StatusId " +
                                            $"from ${new Pedido().GetTableName()}" +
                                            $"where CpfCliente = @cpf and StatusId = @status";

                    var resultPedido = connection
                        .QuerySingleOrDefault<Pedido>(sqlPedidoAberto, param: new { status = (int)eStatusPedido.Pendente, cpf }, transaction: transaction);

                    if (resultPedido != null)
                    {
                        string sqlInsertProduto = $"insert into {new ProdutosPedido().GetTableName()} " +
                                                    $"(ProdutoId, PedidoId, Quantidade)" +
                                                    $"values(@ProdutoId, @PedidoId, 1)";

                        connection.Execute(sqlInsertProduto, param: new { ProdutoId = produtoId, PedidoId = resultPedido.Id }, transaction: transaction);
                        transaction.Commit();
                    }
                    else
                    {
                        string sqlEntregador = $"select " +
                                                $"Cpf " +
                                                $",Nome " +
                                                $"Veiculo " +
                                                $"PlacaDoVeiculo " +
                                                $"from {new Entregador().GetTableName()}";

                        var entregador = connection.QueryFirstOrDefault<Entregador>(sqlEntregador, transaction: transaction);

                        string sqlInsertPedido = $"insert into {new Pedido().GetTableName()} " +
                                                    $"(Data, CpfCliente, CpfEntregador, StatusId)" +
                                                    $"values(@Data, @CpfCliente, @CpfEntregador, @StatusId)";

                        connection.Execute(sqlInsertPedido,
                            param: new
                            {
                                Data = DateTime.Now,
                                CpfCliente = cpf,
                                CpfEntregador = entregador.Cpf,
                                StatusId = (int)eStatusPedido.Pendente
                            },
                            transaction: transaction
                        );

                        transaction.Commit();
                        Handle(produtoId, cpf);
                    }
                }

                connection.Close();
            }
        }
    }
}
