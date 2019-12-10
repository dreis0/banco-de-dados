using Domain;
using System;

namespace Application.Pedidos
{
    public partial class ObterPedidoAberto
    {
        public class PedidoViewModel : Restaurante
        {
            public int ProdutoId { get; set; }

            public int PedidoId { get; set; }

            public DateTime DataPedido { get; set; }

            public string NomeProduto { get; set; }

            public string DescricaoProduto { get; set; }

            public double PrecoProduto { get; set; }

            public string NomeCidade { get; set; }

            public string NomeEstado { get; set; }

            public string NomePais { get; set; }

            public string NomeCliente { get; set; }

            public int Quantidade { get; set; }

            public int StatusId { get; set; }
        }
    }
}
