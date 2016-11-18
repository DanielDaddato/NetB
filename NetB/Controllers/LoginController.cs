using NetB.Models.DTO;
using NetB.Models.Entidades;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NetB.Infraestrutura;

namespace NetB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Index(LoginDTO login)
        {
            var retorno = false;
            if (ModelState.IsValid)
            {
                var usuario = await new LoginInfra().ValidaLogin(login);
                if (usuario == null)
                    retorno = false;
                else
                {
                    if (usuario.senha == login.Senha)
                    {
                        Session["usuario"] = usuario;
                        Session["LogId"] = await new LogRepositorio().RegistrarLogin(usuario.id);
                        retorno = true;
                    }
                    else
                        retorno = false;
                }
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public async Task<RedirectToRouteResult> Logout()
        {
            var logId = (int)Session["LogId"];            
            var retorno = await new LogRepositorio().RegistrarLogout(logId);
            Session["LogId"] = null;
            Session["usuario"] = null;

            return RedirectToRoute("Default");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}