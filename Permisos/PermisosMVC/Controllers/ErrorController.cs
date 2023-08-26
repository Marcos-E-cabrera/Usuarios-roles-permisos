using Microsoft.AspNetCore.Mvc;

namespace PermisosMVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult UnauthotizedOperation( string operacion, string modulo, string msjErrorExecpcion)
        {
            ViewBag.Operacion = operacion;
            ViewBag.Modulo = modulo;
            ViewBag.msjErrorExecption = msjErrorExecpcion;

            return View();
        }
    }
}
