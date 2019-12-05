using System.Collections.Generic;
using Application.Restaurantes;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Cliente.Area
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ListarRestaurantes.RestauranteViewModel> Restaurantes { get; set; }

        public void OnGet([FromServices]ListarRestaurantes.QueryHandler listarHandler)
        {
            Restaurantes = listarHandler.Handle();
        }
    }
}