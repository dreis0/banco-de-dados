﻿using Domain.DBHelper;

namespace Domain
{
    [TableName("Avaliacao")]
    public class Avaliacao
    {
        public string CpfCliente { get; set; }

        public string CnpjRestaurante { get; set; }

        public int Nota { get; set; }

        public string Comentario { get; set; }
    }
}
