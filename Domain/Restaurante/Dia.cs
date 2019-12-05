using Domain.DBHelper;

namespace Domain
{
    [TableName("Dia")]
    public class Dia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
