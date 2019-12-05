using Domain.DBHelper;

namespace Domain
{
    [TableName("Estado")]
    public class Estado
    {
        public int Id { get; set; }

        public int PaisId { get; set; }

        public string Nome { get; set; }
    }
}
