using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Cartoes
{
    public partial class ObterTipos
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<CartaoTipo> Handle()
            {
                string sql = $"select * from {new CartaoTipo().GetTableName()}";
                return connection.Query<CartaoTipo>(sql);
            }
        }
    }
}
