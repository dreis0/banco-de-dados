using Application.Restaurantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.Restaurante.Avaliar
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public AvaliarRestaurante.AvaliacaoViewModel Avaliacao { get; set; }

        public IActionResult OnGet([FromRoute]string cnpjRestaurante
            , [FromServices]ObterAvaliacao.QueryHandler handler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if(!string.IsNullOrWhiteSpace(sessionCpf))
            {
                Avaliacao = handler.Handle(sessionCpf, cnpjRestaurante);

                return Page();
            }

            return Redirect("/Cliente");
        }

        public IActionResult OnPostAvaliar([FromRoute]string cnpjRestaurante
            , [FromServices]ObterAvaliacao.QueryHandler handler
            , [FromServices]AvaliarRestaurante.CommandHandler commandHandler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                Avaliacao.CnpjRestaurante = cnpjRestaurante;
                Avaliacao.CpfCliente = sessionCpf;
                commandHandler.Handle(Avaliacao);

                Avaliacao = handler.Handle(sessionCpf, cnpjRestaurante);
                return Page();
            }

            return Redirect("/Cliente");
        }
    }
}