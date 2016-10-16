using NetB.Infraestrutura;
using NetB.Models;
using NetB.Models.DTO;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NetB.Controllers
{
    public class CalendarioController : Controller
    {
        // GET: Calendario
        public async Task<ActionResult> Index()
        {
            var responsavel = await new  ResponsavelRepositorio().BuscaResponsaveis();
            return View(responsavel);
        }

        public async Task<JsonResult> Eventos()
        {
            var eventos = await new CalendarioInfra().BuscaEventos();
            return Json(eventos,JsonRequestBehavior.AllowGet);
        }
        
        public async Task<JsonResult> BuscaTarefaDetalhes(int id)
        {
            var evento = await new TarefasRepositorio().BuscaTarefaDetalhe(id);
            return Json(evento, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> GravaTarefaDetalhe(TarefaCalendarioDTO tarefa)
        {
            try
            {
                var retorno = await new CalendarioInfra().AtualizaTarefa(tarefa);
                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }
    }
}