using Domain.DBHelper;

namespace Domain
{
    [TableName("Entregador")]
    public class Entregador
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Veiculo { get; set; }

        public string PlacaDoVeiculo { get; set; }
    }
}
