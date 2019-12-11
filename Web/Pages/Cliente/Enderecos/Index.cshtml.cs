using Application.Enderecos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.Cliente.Enderecos
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ObterEnderecos.EnderecoViewModel> Enderecos { get; set; }

        public IActionResult OnGet([FromServices]ObterEnderecos.QueryHandler handler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                Enderecos = handler.Handle(sessionCpf);
                return Page();
            }

            return Redirect("/Cliente");
        }

        public IActionResult OnPostSelecionar(int enderecoId
            , [FromServices]ObterEnderecos.QueryHandler handler
            , [FromServices]SelecionarEndereco.CommandHandler commandHandler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                commandHandler.Handle(sessionCpf, enderecoId);

                return OnGet(handler);
            }

            return Redirect("/Cliente");
        }
    }
}