using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enderecos
{
    public partial class AdicionarNovoEndereco
    {
        public class Command
        {
            public string CpfCliente { get; set; }

            public int CidadeId { get; set; }

            public string Rua { get; set; }

            public string Cep { get; set; }

            public string Complemento { get; set; }

            public int Numero { get; set; }
        }
    }
}
