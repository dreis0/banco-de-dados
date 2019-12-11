using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Cartoes
{
    public partial class ObterCartao
    {

        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public Cartao Handle(string cpf)
            {
                string sql = @"select 
                                Id
                                ,CpfCliente
                                ,NomeDoTitular
                                ,Numero
                                ,Codigo
                                ,BandeiraId
                                ,TipoId
                                ,Selecionado " +
                            $"from {new Cartao().GetTableName()} " +
                            "where CpfCliente = @CpfCliente and selecionado";

                return connection.QuerySingleOrDefault<Cartao>(sql, param: new { CpfCliente = cpf });
            }
        }
    }
}
