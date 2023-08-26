using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PermisosMVC.Controllers.Filters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace PermisosMVC.Controllers
{
    public class AccesoController : Controller
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public AccesoController(IHttpContextAccessor context)
		{
			_contextAccessor = context;
		}


        public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
        [TypeFilter(typeof(VerificaSession))]
        public ActionResult Login( string User, string Pass)
		{
			try
			{
				using ( Models.DB.MiSistemaContext db = new Models.DB.MiSistemaContext())
				{
					var oUser = (from u in db.Usuarios
								where u.Email == User.Trim() && u.Password == Pass.Trim()
								select u).FirstOrDefault();

					if (oUser == null)
					{
						ViewBag.Error = "Usuario o Password Incorrecto";
						return View();
					}

					var userString = JsonConvert.SerializeObject(oUser);
					_contextAccessor.HttpContext.Session.SetString("User", userString);
				}

				return RedirectToAction("Index", "Home");
			}
			catch (Exception ex) 
			{
				ViewBag.Error = ex.Message;
				return View();
			}
		}

	}
}
