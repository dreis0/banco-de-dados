using Dapper;
using Domain;
using System.Collections.Generic;
using System.Data;

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

            public IEnumerable<PedidoViewModel> Handle(string cpf)
            {
                string sqlPedidoAberto = $"select Id " +
                                            $"from {new Pedido().GetTableName()} " +
                                            $"where CpfCliente = @cpf and StatusId = @status";

                int pedidoId = connection
                    .QuerySingleOrDefault<int>(sqlPedidoAberto, param: new { cpf = cpf, status = (int)eStatusPedido.Pendente });

                if (pedidoId > 0)
                {
                    string sqlPedido = @"select 
                                            pe.Id           as PedidoId 
                                            ,pe.Data        as DataPedido
                                            ,p.Id           as ProdutoId
                                            ,p.nome         as NomeProduto 
                                            ,p.Descricao    as DescricaoProduto 
                                            ,p.Preco        as PrecoProduto 
                                            ,r.*            as NomeRestaurante 
                                            ,c.Nome         as NomeCidade 
                                            ,es.Nome        as NomeEstado 
                                            ,pa.Nome        as NomePais 
                                            ,e.Nome         as NomeEntregador 
                                            ,cli.Nome       as NomeCliente 
                                            ,pp.Quantidade  as Quantidade 
                                            ,s.Id     as StatusId " +
                                        $"from {new Pedido().GetTableName()} pe " +
                                        $"join {new Cliente().GetTableName()} cli on cli.Cpf = pe.CpfCliente " +
                                        $"join {new StatusPedido().GetTableName()} s on s.Id = pe.StatusId " +
                                        $"join {new ProdutosPedido().GetTableName()} pp on pp.PedidoId = pe.Id " +
                                        $"join {new Produto().GetTableName()} p on p.Id = pp.ProdutoId " +
                                        $"join {new Restaurante().GetTableName()} r on r.cnpj = p.cnpjrestaurante " +
                                        $"join {new Entregador().GetTableName()} e on e.cpf = pe.cpfentregador " +
                                        $"join {new Cidade().GetTableName()} c on c.Id = r.CidadeId " +
                                        $"join {new Estado().GetTableName()} es on es.Id = c.EstadoId " +
                                        $"join {new Pais().GetTableName()} pa on pa.Id = es.PaisId " +
                                        "where pe.Id = @PedidoId";

                    var resultPedido = connection
                        .Query<PedidoViewModel>(sqlPedido, param: new { PedidoId = pedidoId });

                    return resultPedido;
                }

                return null;
            }
        }
    }
}
