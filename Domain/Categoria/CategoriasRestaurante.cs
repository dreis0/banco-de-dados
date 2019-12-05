using Domain.DBHelper;

namespace Domain
{
    [TableName("CategoriasRestaurante")]
    public class CategoriasRestaurante
    {
        public string CnpjRestaurante { get; set; }

        public int CategoriaId { get; set; }
    }
}
