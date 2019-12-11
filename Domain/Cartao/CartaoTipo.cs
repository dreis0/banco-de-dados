using Domain.DBHelper;

namespace Domain
{
    [TableName("CartaoTipo")]
    public class CartaoTipo
    {
        public int Id { get; set; }

        public string Tipo { get; set; }
    }
}
