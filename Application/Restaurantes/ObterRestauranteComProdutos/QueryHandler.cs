using Dapper;
using Domain;
using System.Data;

namespace Application.Restaurantes
{
    public partial class ObterRestauranteComProdutos
    {
        public class QueryHandler
        {
            private readonly IDbConnection connection;

            public QueryHandler(IDbConnection db)
            {
                connection = db;
            }

            public RestauranteViewModel Handle(string cnpj)
            {
                string sql = @"select
                                Cnpj
                                ,NomeOficial
                                ,NomeFantasia
                                ,Cep
                                ,Complemento
                                ,Numero
                                ,CidadeId
                            from Restaurante
                            where Cnpj = @Cnpj";

                var result = connection.QuerySingleOrDefault<RestauranteViewModel>(sql, param: new { Cnpj = cnpj });

                if (result != null)
                {
                    string sqlProdutos = @"select
                                        Id
                                        ,CNPJRestaurante
                                        ,Nome
                                        ,Descricao
                                        ,Preco
                                    from Produto
                                    where CnpjRestaurante = @Cnpj and Disponivel";

                    result.Produtos = connection.Query<ProdutoViewModel>(sqlProdutos, param: new { Cnpj = cnpj });

                    if (result.Produtos != null)
                    {

                        foreach (var p in result.Produtos)
                        {
                            string sqlCategorias = @"select c.Id, c.Nome
                                            from CategoriasProduto cp
                                            join categoria c on c.Id = cp.CategoriaId
                                            where cp.ProdutoId = @Id";

                            p.Categorias = connection.Query<Categoria>(sqlCategorias, param: new { Id = p.Id });
                        }
                    }
                }

                return result;
            }
        }
    }
}
