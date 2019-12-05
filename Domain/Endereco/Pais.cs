using Domain.DBHelper;

namespace Domain
{
    [TableName("Pais")]
    public class Pais
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
