using Domain.DBHelper;
using System;

namespace Domain
{
    [TableName("HorarioNormal")]
    public class HorarioNormal
    {
        public string CnpjRestaurante { get; set; }

        public int Dia { get; set; }

        public TimeSpan Abertura { get; set; }

        public TimeSpan Fechamento { get; set; }
    }
}
