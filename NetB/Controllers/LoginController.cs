using NetB.Models.Entidades;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            try
            {
                IEnumerable<Usuarios> retorno = new UsuariosRepositorio().Usuarios;
                return View(retorno.FirstOrDefault());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            
        }
    }
}