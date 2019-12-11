using Domain.DBHelper;

namespace Domain
{
    [TableName("PagamentoCartao")]
    public class PagamentoCartao
    {
        public int CaratoId { get; set; }

        public int PedidoId { get; set; }

        public double Valor { get; set; }
    }
}
