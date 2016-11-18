using NetB.Infraestrutura;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace NetB.Controllers
{
    public class GraficosController : Controller
    {
        public async Task<ActionResult> GraficoHoras()
        {
            var projetos = await new ProjetosRepositorio().BuscaProjetos();
            return View(projetos);
        }

        public async Task<JsonResult> BuscaHorasProjeto(int idProjeto)
        {
            var horas = await new GraficosInfra().BuscaHoras(idProjeto);
            return Json(horas, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GraficoCusto()
        {
            var projetos = await new ProjetosRepositorio().BuscaProjetos();
            return View(projetos);
        }

        public async Task<JsonResult> BuscaCustoProjeto(int idProjeto)
        {
            var horas = await new GraficosInfra().BuscaCusto(idProjeto);
            return Json(horas, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GraficoTarefas()
        {
            var projetos = await new ProjetosRepositorio().BuscaProjetos();
            return View(projetos);
        }

        public async Task<JsonResult> BuscaTarefasProjeto(int idProjeto)
        {
            var horas = await new GraficosInfra().BuscaTarefasProjeto(idProjeto);
            return Json(horas, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> HorasGeral()
        {
            var projetos = await new ProjetosRepositorio().BuscaProjetos();
            return View(projetos);
        }

        public async Task<JsonResult> BuscaHorasGeral()
        {
            try
            {
                var retorno = await new GraficosInfra().BuscaHorasGeral();
                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                ex.ToString();
                return null;
            }
        }


    }
}
