using System;

namespace Application.Pedidos
{
    public partial class ObterPedidosEncerrados
    {
        public class PedidoViewModel
        {
            public string CnpjRestaurante { get; set; }

            public string NomeRestaurante { get; set; }

            public int PedidoId { get; set; }

            public DateTime DataPedido { get; set; }

            public double PrecoTotal { get; set; }
        }
    }
}
