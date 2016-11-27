using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using NetB.Infraestrutura;
using NetB.Repositorios;
using NetB.Models.Entidades;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System;
using NetB.Models;

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
            var tarefas = await  new TarefasRepositorio().TarefasPorProjeto(idProjeto);
            return Json(tarefas, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ListaTarefas()
        {
            var projetos = await new ProjetosRepositorio().BuscaProjetos();
            return View(projetos);
        }

        public async Task<ActionResult> BuscaListaTarefas(int IdProjeto)
        {
            ViewBag.responsavel = await new ResponsavelRepositorio().BuscaResponsaveis();
            var tarefas = await new TarefasRepositorio().ListaTarefasProjeto(IdProjeto);
            return View(tarefas);
        }

        public async Task<JsonResult> BuscaTarefa(int id)
        {
            var tarefa = await  new TarefasRepositorio().BuscaTarefa(id);
            return Json(tarefa, JsonRequestBehavior.AllowGet);
        }
        [System.Web.Mvc.HttpPost]
        public async Task<JsonResult> GravarTarefas(TarefaDTO tarefa)
        {
            var resultado = await new TarefasRepositorio().GravaTarefa(tarefa);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}
