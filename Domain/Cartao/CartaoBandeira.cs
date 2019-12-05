using Domain.DBHelper;

namespace Domain
{
    [TableName("CartaoBandeira")]
    public class CartaoBandeira
    {
        public int BandeiraId { get; set; }

        public string Bandeira { get; set; }
    }
}
