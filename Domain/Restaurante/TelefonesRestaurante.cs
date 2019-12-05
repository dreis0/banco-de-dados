using Domain.DBHelper;

namespace Domain
{
    [TableName("TelefonesRestaurante")]
    public class TelefonesRestaurante
    {
        public string CnpjRestaurante { get; set; }

        public string Telefone { get; set; }
    }
}
