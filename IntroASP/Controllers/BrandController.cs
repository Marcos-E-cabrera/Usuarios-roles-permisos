using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BrandController : Controller
    {
        // vamos a regresar los datos de la bdd por inyeccion de independencia
        private readonly PubContext _context;
        
        // El constructor asignara la inyeccion 
        public BrandController(PubContext context)
        {
             _context = context;
        }
        public async Task<IActionResult> Index() => View(await _context.Brands.ToListAsync());
        


    }
}
