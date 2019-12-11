using Application.Cartoes;
using Application.Pedidos;
using Application.Restaurantes;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Web.Pages.Cliente.Area
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<ListarRestaurantes.RestauranteViewModel> Restaurantes { get; set; }

        [BindProperty]
        public IEnumerable<ObterPedidoAberto.PedidoViewModel> PedidoAberto { get; set; }

        [BindProperty]
        public IEnumerable<ObterPedidoNaoEntregue.PedidoViewModel> PedidoNaoEntregue { get; set; }

        [BindProperty]
        public double ValorPedidoFechado { get; set; }

        [BindProperty]
        public bool PagarNoCartao { get; set; }

        public IActionResult OnGet([FromServices]ListarRestaurantes.QueryHandler listarHandler
            , [FromServices]ObterPedidoAberto.QueryHandler pedidoHandler
            , [FromServices]ObterPedidoNaoEntregue.QueryHandler naoEntregueHandler
            , [FromServices]ObterPrecoTotalDoPedido.QueryHandler precoHandler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                Restaurantes = listarHandler.Handle();
                PedidoAberto = pedidoHandler.Handle(sessionCpf);
                PedidoNaoEntregue = naoEntregueHandler.Handle(sessionCpf);

                if (PedidoNaoEntregue != null && PedidoNaoEntregue.Count() > 0)
                    ValorPedidoFechado = precoHandler.Handle(PedidoNaoEntregue.FirstOrDefault().PedidoId);

                return Page();
            }

            return Redirect("/Cliente");
        }

        public IActionResult OnPostFecharPedido([FromServices]FecharPedido.CommandHandler handler
            , [FromServices]ListarRestaurantes.QueryHandler listarHandler
            , [FromServices]ObterPedidoAberto.QueryHandler pedidoHandler
            , [FromServices]ObterPedidoNaoEntregue.QueryHandler naoEntregueHandler
            , [FromServices]ObterPrecoTotalDoPedido.QueryHandler precoHandler
            , [FromServices]GerarPagamentoCartao.CommandHandler pagamentoHandler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                handler.Handle(new FecharPedido.Command
                {
                    PedidoId = PedidoAberto.FirstOrDefault().PedidoId,
                    Produtos = PedidoAberto.Select(p => new FecharPedido.ProdutoQuantidade { ProdutoId = p.ProdutoId, Quantidade = p.Quantidade }),
                    PagarComCartao = PagarNoCartao,
                    Cpf = sessionCpf
                });
            }

            return OnGet(listarHandler, pedidoHandler, naoEntregueHandler, precoHandler);
        }

        public IActionResult OnPostPedidoEntregue([FromServices]PedidoEntregue.CommandHandler handler
            , [FromServices]ListarRestaurantes.QueryHandler listarHandler
            , [FromServices]ObterPedidoAberto.QueryHandler pedidoHandler
            , [FromServices]ObterPedidoNaoEntregue.QueryHandler naoEntregueHandler
            , [FromServices]ObterPrecoTotalDoPedido.QueryHandler precoHandler)
        {
            var x = PedidoNaoEntregue.FirstOrDefault();
            handler.Handle(PedidoNaoEntregue.FirstOrDefault().PedidoId);

            return OnGet(listarHandler, pedidoHandler, naoEntregueHandler, precoHandler);
        }
    }
}