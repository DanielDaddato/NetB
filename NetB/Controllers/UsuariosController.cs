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
    }
}