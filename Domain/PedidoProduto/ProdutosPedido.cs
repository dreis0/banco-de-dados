using Domain.DBHelper;

namespace Domain
{
    [TableName("ProdutosPedido")]
    public class ProdutosPedido
    {
        public int ProdutoId { get; set; }

        public int PedidoId { get; set; }

        public int Quantidade { get; set; }
    }
}
