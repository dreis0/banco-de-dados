using Domain.DBHelper;

namespace Domain
{
    [TableName("Cartao")]
    public class Cartao
    {
        public int Id { get; set; }

        public string CpfCliente { get; set; }

        public string NomeDoTitular { get; set; }

        public string Numero { get; set; }

        public string Codigo { get; set; }

        public bool Selecionado { get; set; }

        public int BandeiraId { get; set; }

        public int TipoId { get; set; }

        public string Apelido { get; set; }
    }
}
