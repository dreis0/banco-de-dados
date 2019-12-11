using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Restaurantes
{
    public partial class ObterAvaliacao
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public AvaliarRestaurante.AvaliacaoViewModel Handle(string cpfCliente, string cnpjRestaurante)
            {
                string sql = $"select * from {new Avaliacao().GetTableName()} " +
                            $"where CpfCliente = @CpfCliente and CnpjRestaurante = @CnpjRestaurante ";

                return connection
                    .QuerySingleOrDefault<AvaliarRestaurante.AvaliacaoViewModel>(sql, param: new { CpfCliente = cpfCliente, CnpjRestaurante = cnpjRestaurante });
            }
        }
    }
}
