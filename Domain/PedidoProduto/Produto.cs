using Domain.DBHelper;

namespace Domain
{
    [TableName("Produto")]
    public class Produto
    {
        public int Id { get; set; }

        public string CnpjRestaurante { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }

        public bool Disponivel { get; set; }
    }
}
