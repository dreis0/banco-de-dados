using Domain.DBHelper;

namespace Domain
{
    [TableName("EnderecoCliente")]
    public class EnderecoCliente
    {
        public int Id { get; set; }

        public string CpfCliente { get; set; }

        public int CidadeId { get; set; }

        public string Rua { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }

        public int Numero { get; set; }

        public bool Selecionado { get; set; }
    }
}
