using Application.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ClienteViewModel Cliente { get; set; }

        public void OnGet()
        {
            Cliente = new ClienteViewModel();
        }

        public IActionResult OnPost([FromServices]ObterCliente.QueryHandler queryHandler)
        {
            if (ModelState.IsValid)
            {
                var clienteResult = queryHandler.Handle(Cliente.Cpf);

                if (clienteResult != null)
                {
                    HttpContext.Session.SetString("CpfCliente", clienteResult.Cpf);
                    return Redirect("Cliente/Area");
                }
                else
                    ModelState.AddModelError("validation", "Cpf não encontrado");
            }

            return Page();
        }
    }
}