using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.Cliente
{
    public class CadastroClienteViewModel
    {
        [Display(Name = "Cpf")]
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Display(Name = "Primeiro Nome")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required]
        public int Sobrenome { get; set; }

        [Display(Name = "Rg")]
        public string RG { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
    }
}
