using System;

namespace Domain
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string CpfCliente { get; set; }

        public int StatusId { get; set; }
    }
}
