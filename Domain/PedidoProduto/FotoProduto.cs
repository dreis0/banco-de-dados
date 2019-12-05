using Domain.DBHelper;

namespace Domain
{
    [TableName("FotoProduto")]
    public class FotoProduto
    {
        public int ProdutoId { get; set; }

        public byte[] Foto { get; set; }
    }
}
