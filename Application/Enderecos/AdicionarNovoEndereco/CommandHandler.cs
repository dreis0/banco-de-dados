using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Enderecos
{
    public partial class AdicionarNovoEndereco
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
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    string sql = @"INSERT INTO enderecocliente
                                (cpfcliente, cidadeid, rua, cep, complemento, numero, selecionado)
	                                VALUES(@CpfCliente, @CidadeId, @Rua, @Cep, @Complemento, @Numero, false)";

                    connection.Execute(sql, param: new
                    {
                        CpfCliente = command.CpfCliente,
                        CidadeId = command.CidadeId,
                        Rua = command.Rua,
                        Cep = command.Cep,
                        Complemento = command.Complemento,
                        Numero = command.Numero,
                    }, transaction: transaction);

                    transaction.Commit();
                }

                connection.Close();
            }
        }
    }
}
