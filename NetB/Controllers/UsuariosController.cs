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
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            ViewBag.Departamento = await new DepartamentoRepositorio().BuscaDepartamentos();
            var usuarios = await new UsuariosRepositorio().PegarUsuarios();
            usuarios.Where(x => x.id == x.departamento_id).FirstOrDefault();
            return View(usuarios);
        }

        public async Task<JsonResult> Editar(int id)
        {
            var usuario = await new UsuariosRepositorio().BuscaUsuario(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> Gravar(Usuarios usuario)
        {
            var usuariosRepositorio = new UsuariosRepositorio();
            int retorno = 0;
            if (usuario.id == 0)
            {
                usuario.status = true;
                retorno = await usuariosRepositorio.AdicionarUsuario(usuario);
            }
            else
            {
                retorno = await usuariosRepositorio.EditarUsuario(usuario);
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Deletar(int id)
        {
            var retorno = await new UsuariosRepositorio().DeletarUsuario(id);
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
    }
}