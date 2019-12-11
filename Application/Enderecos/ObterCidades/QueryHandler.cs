using Dapper;
using Domain;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Application.Enderecos
{
    public partial class ObterCidades
    {

        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<Cidade> Handle(int estadoId)
            {
                string sql = $"select * from {new Cidade().GetTableName()} " +
                            $"where EstadoId = @EstadoId";

                return connection.Query<Cidade>(sql, param: new { EstadoId = estadoId });
            }
        }
    }
}
