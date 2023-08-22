using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

		public IActionResult Create()
		{
			ViewData["Brands"] = new SelectList(_context.Brands, "BranId", "Name");
		
			return View();
		}


		// guardado de informacion
		[HttpPost]
		// lo que hace es que la informacion la va a esperar del form
		// que esta en el mismo domiño. Para evitar que nos manden informacion de fuera de nuestro domiño
		[ValidateAntiForgeryToken] 
		public async Task<IActionResult> Create(BeerViewModel model)
		{
			// esto dice si a pasada o no tomando encuenta las validaciones 
			// de la clase BeerViewModel.
			if (ModelState.IsValid)
			{
				// CON ESTO HACEMOS EL AGREGADO POR ENTITYFRAMEWORK
				var beer = new Beer()
				{
					Name = model.Name,
					BrandId = model.BrandId
				};
				_context.Add(beer); // ACA SE GUARDA EN ENTITYFRAMEWORK
				await _context.SaveChangesAsync(); // ACA MANDA LAS QUERYS A LA BASE DE DATOS. OSE LO GUARDA EN LA BDD
				return RedirectToAction(nameof(Index));  // SI TODO ES EXITOSO TE DEVUELVE AL INDICE	
			}

			ViewData["Brands"] = new SelectList(_context.Brands, "BranId", "Name",model.BrandId);

			return View(model);
		}






	}
}
