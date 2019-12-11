using Dapper;
using Domain;
using System.Data;

namespace Application.Cartoes
{
    public partial class SelecionarCartao
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
                    string setFalse = $"update {new Cartao().GetTableName()} " +
                                        @"set Selecionado = false
                                            where CpfCliente = @CpfCliente";

                    connection.Execute(setFalse, param: new { CpfCliente = cpf }, transaction: transaction);

                    string setTrue = $"update {new Cartao().GetTableName()} " +
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
