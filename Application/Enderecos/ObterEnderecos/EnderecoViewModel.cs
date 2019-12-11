namespace Application.Enderecos
{
    public partial class ObterEnderecos
    {
        public class EnderecoViewModel
        {
            public int EnderecoId { get; set; }

            public string Rua { get; set; }

            public string Cep { get; set; }

            public string Complemento { get; set; }

            public int Numero { get; set; }

            public string NomeCidade { get; set; }

            public string NomeEstado { get; set; }

            public bool Selecionado { get; set; }
        }
    }
}
