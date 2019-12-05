using Domain.DBHelper;

namespace Domain
{
    [TableName("StatusPedido")]
    public class StatusPedido
    {
        public int Id { get; set; }

        public string Status { get; set; }
    }
}
