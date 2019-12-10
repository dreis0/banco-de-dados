using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Pedidos
{
    public partial class ObterPedidoNaoEntregue
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<PedidoViewModel> Handle(string cpf)
            {
                string sqlPedido = @"select 
                                            pe.Id           as PedidoId 
                                            ,p.Id           as ProdutoId
                                            ,p.nome         as NomeProduto 
                                            ,p.Preco        as PrecoProduto 
                                            ,r.*            
                                            ,e.Nome         as NomeEntregador 
                                            ,pp.Quantidade  as Quantidade 
                                            ,s.Id           as StatusId 
                                            ,ec.Rua         as RuaEntrega
                                            ,ec.Numero      as NumeroEntrega
                                            ,cid.Nome       as CidadeEntrega " +
                                        $"from {new Pedido().GetTableName()} pe " +
                                        $"join {new Cliente().GetTableName()} cli on cli.Cpf = pe.CpfCliente " +
                                        $"join {new StatusPedido().GetTableName()} s on s.Id = pe.StatusId " +
                                        $"join {new ProdutosPedido().GetTableName()} pp on pp.PedidoId = pe.Id " +
                                        $"join {new Produto().GetTableName()} p on p.Id = pp.ProdutoId " +
                                        $"join {new Restaurante().GetTableName()} r on r.cnpj = p.cnpjrestaurante " +
                                        $"join {new Entregador().GetTableName()} e on e.cpf = pe.cpfentregador " +
                                        $"join {new EnderecoCliente().GetTableName()} ec on ec.Id = pe.EnderecoId " +
                                        $"join {new Cidade().GetTableName()} cid on cid.Id = ec.CidadeId " +
                                        "where cli.cpf = @CpfCliente and s.Id = @StatusId";

                return connection.Query<PedidoViewModel>(sqlPedido, param: new { CpfCliente = cpf, StatusId = (int)eStatusPedido.Fechado });
            }
        }
    }
}
