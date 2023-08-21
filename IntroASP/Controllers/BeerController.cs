using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
	public class BeerController : Controller
	{
		// vamos a regresar los datos de la bdd por inyeccion de independencia
		private readonly PubContext _context;

		// El constructor asignara la inyeccion 
		public BeerController(PubContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			// Traer informacion de 2 tablas relacionadas con entityframework	
			var beers = _context.Beers.Include(b=>b.BeerNavigation);
			return View(await beers.ToListAsync());
		}
	}
}
