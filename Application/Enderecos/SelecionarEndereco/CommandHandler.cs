using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Enderecos
{
    public partial class SelecionarEndereco
    {
        public class CommandHandler
        {
            private readonly IDbConnection connection;
            public CommandHandler(IDbConnection db)
            {
                connection = db;
            }

            public void Handle(string cpf, int enderecoId)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    string setFalse = $"update {new EnderecoCliente().GetTableName()} " +
                                        @"set Selecionado = false
                                            where CpfCliente = @CpfCliente";

                    connection.Execute(setFalse, param: new { CpfCliente = cpf }, transaction: transaction);

                    string setTrue = $"update {new EnderecoCliente().GetTableName()} " +
                                        @"set Selecionado = true
                                            where Id = @EnderecoId";

                    connection.Execute(setTrue, param: new { EnderecoId = enderecoId }, transaction: transaction);
                    transaction.Commit();
                }

                connection.Close();
            }
        }
    }
}
