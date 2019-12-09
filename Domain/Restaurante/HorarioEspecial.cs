using Domain.DBHelper;
using System;

namespace Domain
{
    [TableName("restaurante_horarioespecial")]
    public class HorarioEspecial
    {
        public string CnpjRestaurante { get; set; }

        public DateTime DataEspecial { get; set; }

        public TimeSpan Abertura { get; set; }

        public TimeSpan Fechamento { get; set; }
    }
}
