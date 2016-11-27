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
                    foreach (var item in ListaTarefas)
                    {
                        if (item.conclusao != null)
                        {
                            item.statusCor = "Green";
                        }
                        else if (item.previsao == null)
                        {
                            continue;
                        }
                        else if (item.previsao.Value < DateTime.Now)
                        {
                            item.statusCor = "Red";
                        }
                        else if (DateTime.Now >= item.previsao.Value.AddDays(-7) && DateTime.Now <= item.previsao.Value)
                        {
                            item.statusCor = "Orange";
                        }
                        else
                        {
                            item.statusCor = "Blue";
                        }
                    }
                    return View(ListaTarefas);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }            
            }

            return RedirectToAction("Index", "Login");
            
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}