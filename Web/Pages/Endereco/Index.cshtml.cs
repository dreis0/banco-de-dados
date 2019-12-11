using Application.Enderecos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.Endereco
{
    public class IndexModel : PageModel
    {
        public ObterCidades.QueryHandler cidadesHandler;
        public IndexModel(ObterCidades.QueryHandler _cidadesHandler)
        {
            cidadesHandler = _cidadesHandler;
        }

        [BindProperty]
        public IEnumerable<SelectListItem> Cidades
        {
            get => cidadesHandler.Handle().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome });
        }

        [BindProperty]
        public List<SelectListItem> Estados { get; set; }

        [BindProperty]
        public int CidadeId { get; set; }

        [BindProperty]
        public int EstadoId { get; set; }

        public AdicionarNovoEndereco.Command Command { get; set; }

        public IActionResult OnGet([FromServices]ObterCidades.QueryHandler cidadesHandler)
        {
            string sessionCpf = HttpContext.Session.GetString("CpfCliente");
            if (!string.IsNullOrWhiteSpace(sessionCpf))
            {
                return Page();
            }

            return Redirect("/Cliente");
        }
    }
}