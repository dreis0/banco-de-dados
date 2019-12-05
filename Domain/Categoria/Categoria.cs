using Domain.DBHelper;

namespace Domain
{
    [TableName("Categoria")]
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
