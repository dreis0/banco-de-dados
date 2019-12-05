using Domain.DBHelper;

namespace Domain
{
    [TableName("Cidade")]
    public class Cidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int EstadoId { get; set; }
    }
}
