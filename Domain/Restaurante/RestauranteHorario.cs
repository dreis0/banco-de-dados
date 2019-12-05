using Domain.DBHelper;
using System;

namespace Domain
{
    [TableName("RestauranteHorario")]
    public class RestauranteHorario
    {
        public string CnpjRestaurante { get; set; }

        public int DiaId { get; set; }

        public TimeSpan Abertura { get; set; }

        public TimeSpan Fechamento { get; set; }
    }
}
