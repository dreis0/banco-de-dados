using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Pedidos
{
    public partial class ObterPedidoAberto
    {
        public class QueryHandler
        {
            private IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public PedidoViewModel Handle(string cpf)
            {
                string sqlPedidoAberto = $"select Id" +
                                                $",Data " +
                                                $",CpfCliente" +
                                                $",StatusId " +
                                            $"from ${new Pedido().GetTableName()} " +
                                            $"where CpfCliente = @cpf and StatusId = @status";

                var resultPedido = connection
                    .QuerySingleOrDefault<PedidoViewModel>(sqlPedidoAberto, param: new { cpf = cpf, status = (int)eStatusPedido.Pendente });

                if (resultPedido != null)
                {
                    string sqlRestaurantes = $"select " +
                                            $"r.Cnpj as CnpjRestaurante" +
                                            $",r.NomeFantasia as NomeRestaurante " +
                                            $"from {new ProdutosPedido().GetTableName()} pp " +
                                            $"join {new Produto().GetTableName()} p on p.Id = pp.ProdutoId " +
                                            $"join {new Restaurante().GetTableName()} r on r.Cnpj = p.CnpjRestaurante " +
                                            $"where PedidoId = @PedidoId " +
                                            $"group by r.Cnpj";

                    resultPedido.Restaurantes = connection
                        .Query<RestaurantePedidoViewModel>(sqlRestaurantes, param: new { PedidoId = resultPedido.Id });

                    foreach (var r in resultPedido.Restaurantes)
                    {

                    }
                }
            }
        }
    }
}
