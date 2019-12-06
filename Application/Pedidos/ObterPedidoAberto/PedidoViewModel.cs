using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Pedidos
{
    public partial class ObterPedidoAberto
    {
        public class PedidoViewModel
        {
            public int Id { get; set; }

            public DateTime Data { get; set; }

            public string CpfCliente { get; set; }

            public int StatusId { get; set; }

            public IEnumerable<RestaurantePedidoViewModel> Restaurantes { get; set; }
        }

        public class RestaurantePedidoViewModel
        {
            public string CnpjRestaurante { get; set; }

            public string NomeRestaurante { get; set; }

            public IEnumerable<Produto> Produtos { get; set; }
        }

    }
}
