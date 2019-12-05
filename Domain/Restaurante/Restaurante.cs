using Domain.DBHelper;

namespace Domain
{
    [TableName("Restaurante")]
    public class Restaurante
    {
        public string CnpjRestaurante { get; set; }

        public string NomeOficial { get; set; }

        public string NomeFantasia { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }

        public int Numero { get; set; }

        public int CidadeId { get; set; }
    }
}
