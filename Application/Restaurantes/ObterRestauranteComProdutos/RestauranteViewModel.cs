using Domain;
using System.Collections.Generic;

namespace Application.Restaurantes
{
    public partial class ObterRestauranteComProdutos
    {
        public class RestauranteViewModel
        {
            public string Cnpj { get; set; }

            public string NomeOficial { get; set; }

            public string NomeFantasia { get; set; }

            public string Cep { get; set; }

            public string Complemento { get; set; }

            public int Numero { get; set; }

            public int CidadeId { get; set; }

            public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        }

        public class ProdutoViewModel
        {
            public int Id { get; set; }

            public string CnpjRestaurante { get; set; }

            public string Nome { get; set; }

            public string Descricao { get; set; }

            public double Preco { get; set; }

            public bool Disponivel { get; set; }

            public IEnumerable<Categoria> Categorias { get; set; }
        }
    }
}
