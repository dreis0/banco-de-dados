using Application.Pedidos;
using Application.Restaurantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IActionResult OnPostAdicionarProduto(int produtoId,
            [FromServices]AdicionarProdutoAoPedidoAberto.CommandHandler handler)
        {
            if (HttpContext.Session.GetString("CpfCliente") != null)
            {
                string sessionCpf = HttpContext.Session.GetString("CpfCliente");
                handler.Handle(produtoId, sessionCpf);
            }

            return Page();
        }

        public IActionResult OnPostRemoverProduto(int produtoId,
            [FromServices]RemoverProdutoDePedidoAberto.CommandHandler handler)
        {
            return Page();
        }
    }
}