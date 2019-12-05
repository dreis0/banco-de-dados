using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.Cliente
{
    public class ClienteViewModel
    {
        [Display(Name = "CPF")]
        [MaxLength(11)]
        [Required]
        public string Cpf { get; set; }
    }
}
