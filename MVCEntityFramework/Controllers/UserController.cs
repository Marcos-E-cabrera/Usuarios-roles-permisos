using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Models.DB;

namespace MVCEntityFramework.Controllers
{
	public class UserController : Controller
	{

		public IActionResult Index()
		{
			List<MVCEntityFramework.Models.User> lst = new List<MVCEntityFramework.Models.User>();
			using (var db = new Models.DB.IntoMvcContext())
			{
				lst = (from user in db.Users
					  select new MVCEntityFramework.Models.User
					  {
						  Id = user.Id,
						  Email = user.Email
					  }).ToList();
						
			}

			return View(lst);
		}


	}
}
