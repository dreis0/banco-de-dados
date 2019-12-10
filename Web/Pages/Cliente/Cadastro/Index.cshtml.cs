using Application.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Cliente.Cadastro
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Cadastrar.Command Cadastro { get; set; }

        public void OnGet()
        {
            Cadastro = new Cadastrar.Command();
        }

        public IActionResult OnPost([FromServices]Cadastrar.CommandHandler handler)
        {
            if (ModelState.IsValid)
            {
                handler.Handle(Cadastro);
            }

            return Redirect("/Cliente");
        }
    }
}