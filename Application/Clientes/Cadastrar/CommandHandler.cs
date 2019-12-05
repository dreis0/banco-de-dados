using Dapper;
using Domain;
using Domain.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Clientes
{
    public partial class Cadastrar
    {
        public class CommandHandler
        {
            private readonly IDbConnection connection;

            public CommandHandler(IDbConnection db)
            {
                connection = db;
            }

            public void Handle(Command command)
            {
                string sql = $"insert into {new Cliente().GetTableName()}" + 
                              "(Cpf, Nome, Sobrenome, Rg, Email, Telefone)" +
                              "values(" +
                              "@Cpf" +
                              ",@Nome" +
                              ",@Sobrenome" +
                              ",@Rg" +
                              ",@Email" +
                              ",@Telefone" +
                              ")" ;

                connection.Execute(sql, param: command);
            }
        }
    }
}
