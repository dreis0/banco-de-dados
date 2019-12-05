using Dapper;
using Domain;
using System.Collections.Generic;
using System.Data;

namespace Application.Restaurantes
{
    public partial class ListarRestaurantes
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public IEnumerable<RestauranteViewModel> Handle()
            {
                string sql = @"select
                                Cnpj
                                ,NomeOficial
                                ,NomeFantasia
                                ,Cep
                                ,Complemento
                                ,Numero
                                ,CidadeId
                            from Restaurante";

                var result = connection.Query<RestauranteViewModel>(sql);

                foreach (var r in result)
                {
                    string sqlCategorias = @"select c.Id, c.nome 
	                                            from CategoriasRestaurante cr
	                                            join categoria c on c.Id = cr.CategoriaId
                                                where cr.CnpjRestaurante = @Cnpj";

                    r.Categorias = connection.Query<Categoria>(sqlCategorias, param: new { Cnpj = r.Cnpj });
                }

                return result;
            }
        }
    }
}
