using Application.Pedidos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Web.Pages.Cliente.Pedidos
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<ObterPedidosEncerrados.PedidoViewModel> Pedidos { get; set; }

        public IActionResult OnGet([FromServices]ObterPedidosEncerrados.QueryHandler queryHandler
            ,[FromServices]ObterPrecoTotalDoPedido.QueryHandler precoHandler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                Pedidos = queryHandler.Handle(sessionCpf);

                foreach (var item in Pedidos)
                {
                    item.PrecoTotal = precoHandler.Handle(item.PedidoId);
                }

                return Page();
            }

            return Redirect("/Cliente");
        }
    }
}