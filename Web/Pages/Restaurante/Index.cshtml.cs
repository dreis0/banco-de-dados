using Application.Pedidos;
using Application.Restaurantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Web.Pages.Restaurante
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ObterRestauranteComProdutos.RestauranteViewModel Restaurante { get; set; }

        public IActionResult OnGet([FromRoute]string cnpjRestaurante
            , [FromServices]ObterRestauranteComProdutos.QueryHandler handler)
        {
            Restaurante = handler.Handle(cnpjRestaurante);
            return Page();
        }

        public IActionResult OnPostAdicionarProduto(int produtoId
            , [FromServices]AdicionarProdutoAoPedidoAberto.CommandHandler handler
            , [FromRoute]string cnpjRestaurante
            , [FromServices]ObterRestauranteComProdutos.QueryHandler handlerProdutos)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                handler.Handle(produtoId, sessionCpf);
                return OnGet(cnpjRestaurante, handlerProdutos);
            }

            return Redirect("/Cliente");
        }

        public IActionResult OnPostRemoverProduto(int produtoId
            , [FromServices]RemoverProdutoDePedidoAberto.CommandHandler handler
            , [FromRoute]string cnpjRestaurante
            , [FromServices]ObterRestauranteComProdutos.QueryHandler handlerProdutos)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                handler.Handle(produtoId, sessionCpf);
                return OnGet(cnpjRestaurante, handlerProdutos);
            }

            return Redirect("/Cliente");
        }
    }
}