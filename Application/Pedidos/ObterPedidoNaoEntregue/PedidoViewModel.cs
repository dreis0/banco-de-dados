using Domain;

namespace Application.Pedidos
{
    public partial class ObterPedidoNaoEntregue
    {
        public class PedidoViewModel : Restaurante
        {
            public int PedidoId { get; set; }

            public int ProdutoId { get; set; }

            public string Restaurante { get; set; }

            public string NomeEntregador { get; set; }

            public string NomeProduto { get; set; }

            public int Quantidade { get; set; }

            public string RuaEntrega { get; set; }

            public int NumeroEntrega { get; set; }

            public string CidadeEntrega { get; set; }
        }
    }
}
