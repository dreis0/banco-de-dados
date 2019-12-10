using System.ComponentModel.DataAnnotations;

namespace Application.Clientes
{
    public partial class Cadastrar
    {
        public class Command
        {
            [Display(Name = "*Cpf")]
            [Required(ErrorMessage = "Campo obrigatório")]
            [MaxLength(11)]
            public string Cpf { get; set; }

            [Display(Name = "*Primeiro Nome")]
            [Required(ErrorMessage = "Campo obrigatório")]
            public string Nome { get; set; }

            [Display(Name = "*Sobrenome")]
            [Required(ErrorMessage = "Campo obrigatório")]
            public string Sobrenome { get; set; }

            [Display(Name = "Rg")]
            [MaxLength(10)]
            public string RG { get; set; }

            [Display(Name = "*Email")]
            [Required(ErrorMessage = "Campo obrigatório")]
            [EmailAddress]
            public string Email { get; set; }

            [Display(Name = "Telefone")]
            public string Telefone { get; set; }
        }
    }
}
