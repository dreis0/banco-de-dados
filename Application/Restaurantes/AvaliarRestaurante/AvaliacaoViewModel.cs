using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Restaurantes
{
    public partial class AvaliarRestaurante
    {
        public class AvaliacaoViewModel
        {
            public string CpfCliente { get; set; }

            public string CnpjRestaurante { get; set; }

            [Display(Name = "*Nota (0 ~ 10)")]
            [Required(ErrorMessage = "Campo obrigatório")]
            public int Nota { get; set; }

            [Display(Name = "*Comentário")]
            [MaxLength(1000, ErrorMessage = "Máximo 1000 caracs")]
            [Required(ErrorMessage = "Campo obrigatório")]
            public string Comentario { get; set; }
        }
    }
}
