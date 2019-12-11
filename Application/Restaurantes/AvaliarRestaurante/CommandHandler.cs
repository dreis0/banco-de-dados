using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Restaurantes
{
    public partial class AvaliarRestaurante
    {
        public class CommandHandler
        {
            private readonly IDbConnection connection;

            public CommandHandler(IDbConnection db)
            {
                connection = db;
            }

            public void Handle(AvaliacaoViewModel avaliacao)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    string sqlAvaliacao = $"select * from {new Avaliacao().GetTableName()} " +
                                        $"where CpfCliente = @CpfCliente and CnpjRestaurante = @CnpjRestaurante ";

                    var result = connection
                        .QuerySingleOrDefault<Avaliacao>(sqlAvaliacao, param: new
                        {
                            CpfCliente = avaliacao.CpfCliente,
                            CnpjRestaurante = avaliacao.CnpjRestaurante
                        }, transaction: transaction);

                    if (result != null)
                    {
                        sqlAvaliacao = $"update {new Avaliacao().GetTableName()} " +
                                        @"set nota = @Nota, comentario = @Comentario 
                                        where CpfCliente = @CpfCliente and CnpjRestaurante = @CnpjRestaurante";
                    }
                    else
                    {
                        sqlAvaliacao = $"insert into {new Avaliacao().GetTableName()} " +
                                        @"(CpfCliente, CnpjRestaurante, Nota, Comentario)
                                        values(@CpfCliente, @CnpjRestaurante, @Nota, @Comentario)";
                    }

                    connection.Execute(sqlAvaliacao, param: new
                    {
                        CpfCliente = avaliacao.CpfCliente,
                        CnpjRestaurante = avaliacao.CnpjRestaurante,
                        Nota = avaliacao.Nota,
                        Comentario = avaliacao.Comentario
                    }, transaction: transaction);

                    transaction.Commit();
                }
                connection.Close();
            }
        }
    }
}
