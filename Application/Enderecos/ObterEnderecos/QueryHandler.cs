using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Enderecos
{
    public partial class ObterEnderecos
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<EnderecoViewModel> Handle(string cpfCliente)
            {
                string sql = @"select 
                                ec.Id as EnderecoId
	                            ,ec.rua
	                            ,ec.Cep
	                            ,ec.Numero
	                            ,ec.Complemento
	                            ,ec.Selecionado
	                            ,cid.Nome as NomeCidade 
	                            ,es.Nome as NomeEstado " +
                            $"from {new EnderecoCliente().GetTableName()} ec " +
                            $"join {new Cidade().GetTableName()} cid on cid.Id = ec.CidadeId " +
                            $"join {new Estado().GetTableName()} es on es.Id = cid.EstadoId " +
                            "where CpfCliente = @CpfCliente order by ec.Id";

                return connection.Query<EnderecoViewModel>(sql, param: new { CpfCliente = cpfCliente });
            }
        }
    }
}
