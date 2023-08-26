using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PermisosMVC.Models.DB;

namespace PermisosMVC.Controllers.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuario oUsuario;
        private MiSistemaContext db = new MiSistemaContext();
        private int idOperacion;

        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizeUser(IHttpContextAccessor context)
        {
            _contextAccessor = context;
        }

        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            string nombreOperacion = "";
            string nombreModulo = "";

            try
            {
                oUsuario = JsonConvert.DeserializeObject<Usuario>(_contextAccessor.HttpContext?.Session.GetString("User"));
                var lstMisOperaciones = from m in db.RolOperacions
                                        where m.Id == idOperacion
                                        && m.IdOperacion == idOperacion
                                        select m;

                if (lstMisOperaciones.ToList().Count() < 1)
                {
                    var oOpereacion = db.Operaciones.Find(idOperacion);
                    int? idModulo = oOpereacion.IdModulo;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    nombreModulo = getNombreModulo(idModulo);
                    nombreModulo = nombreModulo.Replace(' ', '+');
                    nombreOperacion = nombreOperacion.Replace(' ', '+');
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizeOperation?operacion=" + nombreOperacion);
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizeOperation?operacion=" + nombreOperacion);
            }
        }

        private string getNombreModulo(int? idModulo)
        {
            var ope = from op in db.Operaciones
                      where op.Id == idOperacion
                      select op.Nombre;

            string nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch(Exception)
            {
                nombreOperacion = "";
            }

            return nombreOperacion;
        }

        private string getNombreDeOperacion(int idModulo)
        {
            var modulo = from op in db.Modulos
                      where op.Id == idModulo
                         select op.Nombre;

            string nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }

            return nombreModulo;
        }
    }
}
