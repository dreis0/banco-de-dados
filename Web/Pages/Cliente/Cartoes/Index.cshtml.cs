using Application.Cartoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.Cliente.Cartoes
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ObterCartoes.CartaoViewModel> Cartoes { get; set; }

        public IActionResult OnGet([FromServices]ObterCartoes.QueryHandler handler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                Cartoes = handler.Handle(sessionCpf);
                return Page();
            }

            return Redirect("/Cliente");
        }

        public IActionResult OnPostSelecionar(int cartaoId
            , [FromServices]ObterCartoes.QueryHandler handler
            , [FromServices]SelecionarCartao.CommandHandler commandHandler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                commandHandler.Handle(sessionCpf, cartaoId);

                return OnGet(handler);
            }

            return Redirect("/Cliente");
        }
    }
}