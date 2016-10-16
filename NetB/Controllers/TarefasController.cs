using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using NetB.Infraestrutura;
using NetB.Repositorios;

namespace NetB.Controllers
{
    public class TarefasController : Controller
    {
        public async Task<ActionResult> TarefasPorUsuarios()
        {
            var listaTarefas = await new TarefasInfra().BuscaTarefasPorUsuario();

            return View(listaTarefas);
        }

        public async Task<ActionResult> TarefasPorProjeto()
        {
            var projetos = await new ProjetosRepositorio().BuscaProjetos();
            return View(projetos);
        }

        public async Task<JsonResult> BuscaTarefas(int idProjeto)
        {
            var projetos = await  new TarefasRepositorio().TarefasPorProjeto(idProjeto);
            return Json(projetos, JsonRequestBehavior.AllowGet);
        }
    }
}
