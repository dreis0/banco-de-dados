using Dapper;
using Domain;
using System.Collections.Generic;
using System.Data;

namespace Application.Pedidos
{
    public partial class ObterPedidosEncerrados
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;
            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<PedidoViewModel> Handle(string cpfCliente)
            {
                string sqlPedidos = @"select 
                                        res.Cnpj            as CnpjRestaurante
                                        ,res.NomeOficial    as NomeRestaurante
                                        ,p.Id               as PedidoId
                                        ,p.Data             as DataPedido " +
                                    $"from {new Pedido().GetTableName()} p " +
                                        $"join {new ProdutosPedido().GetTableName()} pp on pp.PedidoId = p.Id " +
                                        $"join {new Produto().GetTableName()} pro on pro.Id = pp.ProdutoId " +
                                        $"join {new Restaurante().GetTableName()} res on res.Cnpj = pro.CnpjRestaurante " +
                                    $"where p.CpfCliente = @Cpf and p.StatusId = @Status " +
                                    $"group by res.Cnpj, p.Id ";

                return connection.Query<PedidoViewModel>(sqlPedidos, new { Cpf = cpfCliente, Status = (int)eStatusPedido.Entregue });
            }
        }
    }
}
