using Domain.DBHelper;

namespace Domain
{
    [TableName("CategoriasProduto")]
    public class CategoriasProduto
    {
        public int ProdutoId { get; set; }

        public int CategoriaId { get; set; }
    }
}
