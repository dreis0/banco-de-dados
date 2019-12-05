using Domain;
using System.Collections.Generic;

namespace Application.Restaurantes
{
    public partial class ListarRestaurantes
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

            public IEnumerable<Categoria> Categorias { get; set; }
        }
    }
}
