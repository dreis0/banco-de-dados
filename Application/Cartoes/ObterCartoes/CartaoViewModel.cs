﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cartoes
{
    public partial class ObterCartoes
    {
        public class CartaoViewModel
        {
            public int CartaoId { get; set; }

            public string CpfCliente { get; set; }

            public string NomeDoTitular { get; set; }

            public string Numero { get; set; }

            public string Codigo { get; set; }

            public string Bandeira { get; set; }

            public string Tipo { get; set; }

            public bool Selecionado { get; set; }

            public string Apelido { get; set; }
        }
    }
}
