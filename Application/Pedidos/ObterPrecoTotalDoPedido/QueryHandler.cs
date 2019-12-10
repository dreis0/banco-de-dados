using Dapper;
using Domain;
using System.Data;

namespace Application.Pedidos
{
    public partial class ObterPrecoTotalDoPedido
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public double Handle(int PedidoId)
            {
                string sqlPreco = @"select 
	                                sum(p.Preco * pp.quantidade) as PrecoPedido " +
                                    $"from Pedido pe " +
                                    $"join {new ProdutosPedido().GetTableName()} pp on pp.PedidoId = pe.Id " +
                                    $"join {new Produto().GetTableName()} p on p.Id = pp.ProdutoId " +
                                    $"where pe.Id = @PedidoId ";

                return connection.QuerySingleOrDefault<double>(sqlPreco, param: new { PedidoId });
            }
        }
    }
}
