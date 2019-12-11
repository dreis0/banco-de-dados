using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Enderecos
{
    public partial class ObterEstados
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;
            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<Estado> Handle()
            {
                string sql = $"select * from {new Estado().GetTableName()} ";
                return connection.Query<Estado>(sql);
            }
        }
    }
}
