using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NetB.Models.Entidades;

namespace NetB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var session = (Usuarios)Session["usuario"];
            if (session != null)
            {
                try
                {
                    var ListaTarefas = await new TarefasRepositorio().TarefasDoUsuario(session.id);
                    return View(ListaTarefas);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }            
            }

            return RedirectToAction("Login", "Index");
            
        }
    }
}