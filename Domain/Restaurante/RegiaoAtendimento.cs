using Domain.DBHelper;

namespace Domain
{
    [TableName("RegiaoAtendimento")]
    public class RegiaoAtendimento
    {
        public string CnpjRestaurante { get; set; }

        public string Descricao { get; set; }

        public int RaioDeAtendimento { get; set; }
    }
}
