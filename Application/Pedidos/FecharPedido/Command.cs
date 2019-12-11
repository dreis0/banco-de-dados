using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Pedidos
{
    public partial class FecharPedido
    {
        public class Command
        {
            public string Cpf { get; set; }

            public int PedidoId { get; set; }

            public bool PagarComCartao { get; set; }

            public IEnumerable<ProdutoQuantidade> Produtos { get; set; }
        }

        public class ProdutoQuantidade
        {
            public int ProdutoId { get; set; }

            public int Quantidade { get; set; }
        }
    }
}
