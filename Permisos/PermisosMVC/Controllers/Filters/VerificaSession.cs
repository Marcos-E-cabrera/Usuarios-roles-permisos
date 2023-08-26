using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PermisosMVC.Models.DB;

namespace PermisosMVC.Controllers.Filters
{
	public class VerificaSession : ActionFilterAttribute
    {

		/// <summary>
		/// Este es el mismo obj que se usa en AccesoController - oUser 
		/// </summary>
		public Usuario oUsuario;

		private readonly IHttpContextAccessor _contextAccessor;

		public VerificaSession(IHttpContextAccessor context)
		{
			_contextAccessor = context;
		}

		
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			try
			{
				base.OnActionExecuted(filterContext);

				oUsuario = JsonConvert.DeserializeObject<Usuario>(_contextAccessor.HttpContext?.Session.GetString("User"));
				if (oUsuario == null) 
				{
					if (filterContext.Controller is AccesoController == false)
					{
						filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
					}
				}

			}
			catch (Exception) 
			{
				filterContext.Result = new RedirectResult("~/Acceso/Login");
			}
		}
	}
}
