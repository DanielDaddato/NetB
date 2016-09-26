using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using NetB.Infraestrutura;

namespace NetB.Controllers
{
    public class TarefasController : Controller
    {
        public async Task<ActionResult> TarefasPorUsuarios()
        {
            var listaTarefas = await new TarefasInfra().BuscaTarefasPorUsuario();

            return View(listaTarefas);
        }
    }
}
