using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Cartoes
{
    public partial class ObterBandeiras
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;
            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<CartaoBandeira> Handle()
            {
                string sql = $"select * from {new CartaoBandeira().GetTableName()} ";
                return connection.Query<CartaoBandeira>(sql);
            }
        }
    }
}
