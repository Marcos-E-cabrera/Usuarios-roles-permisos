using IntroMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroMVC.Controllers
{
	public class UserController1 : Controller
	{
		public IActionResult Index()
		{
			User user = new User();
			user.Id = 1;
			user.Name = "Pepe";
			user.Email = "Pepe@gmaIl.com";
			return View(user);
		}


	
	}
}
