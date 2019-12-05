using Dapper;
using Domain;
using System.Data;

namespace Application.Clientes
{
    public partial class ObterCliente
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public Cliente Handle(string cpf)
            {
                string sql = @"select
                                Cpf
                                ,Nome
                                ,Sobrenome
                                ,Rg
                                ,Email
                                ,Telefone
                            from Cliente
                            where cpf = @Cpf";

                return connection.QuerySingleOrDefault<Cliente>(sql, param: new { Cpf = cpf });
            }
        }
    }
}
