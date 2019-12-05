using Domain.DBHelper;

namespace Domain
{
    [TableName("Cliente")]
    public class Cliente
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Rg { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}