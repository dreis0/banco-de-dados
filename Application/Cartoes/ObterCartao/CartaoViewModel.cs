namespace Application.Cartoes
{
    public partial class ObterCartao
    {
        public class CartaoViewModel
        {
            public int CartaoId { get; set; }

            public string CpfCliente { get; set; }

            public string NomeDoTitular { get; set; }

            public string Numero { get; set; }

            public string Codigo { get; set; }

            public string Banderia { get; set; }

            public string Tipo { get; set; }
        }
    }
}
