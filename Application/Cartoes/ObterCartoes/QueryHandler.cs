using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Cartoes
{
    public partial class ObterCartoes
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;
            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<CartaoViewModel> Handle()
            {
                string sql = @"select 
                                c.Id as CartaoId
	                            ,c.CpfCliente as CpfCliente
	                            ,c.NomeDoTitular as NomeDoTitular
	                            ,c.Numero as Numero
	                            ,c.Codigo as Codigo
	                            ,cb.bandeira as Bandeira
	                            ,ct.Tipo as Tipo
                            from Cartao c
                            join cartaobandeira cb on cb.Id = c.BandeiraId
                            join cartaoTipo ct on ct.Id = c.TipoId ";

                return connection.Query<CartaoViewModel>(sql);
            }
        }
    }
}
