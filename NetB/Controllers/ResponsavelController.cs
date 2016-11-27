using NetB.Models.Entidades;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NetB.Controllers
{
    public class ResponsavelController : Controller
    {
        // GET: Responsavel
        public async Task<ActionResult> Index()
        {
            var responsaveis = await new ResponsavelRepositorio().BuscaResponsaveis();
            return View(responsaveis);
        }
        public async Task<JsonResult> Editar(int id)
        {
            var usuario = await new ResponsavelRepositorio().BuscaResponsavel(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> Gravar(Responsavel responsavel)
        {
            var responsavelRepositorio = new ResponsavelRepositorio();
            int retorno = 0;
            if (responsavel.id == 0)
            {
                responsavel.status = true;
                retorno = await responsavelRepositorio.AdicionarResponsavel(responsavel);
            }
            else
            {
                retorno = await responsavelRepositorio.EditarResponsavel(responsavel);
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Deletar(int id)
        {
            var retorno = await new ResponsavelRepositorio().DeletarResponsavel(id);
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}