using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermisosMVC.Controllers.Filters;
using PermisosMVC.Models;
using System.Diagnostics;

namespace PermisosMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

        [AuthorizeUser(idOperacion: 2)]
        public IActionResult Privacy()
		{
			return View();
		}

        [AuthorizeUser(idOperacion: 3)]
        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}