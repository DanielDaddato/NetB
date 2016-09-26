using NetB.Models.DTO;
using NetB.Models.Entidades;
using NetB.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NetB.Infraestrutura;

namespace NetB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public async Task<ActionResult> Index()
        {

                return View();           
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginDTO login)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = await new LoginInfra().ValidaLogin(login);
                    if (usuario.senha == login.Senha)
                    {
                        Session["usuario"] = usuario;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewBag.Error = "Senha não confere!";
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
            return View(login);
        }
    }
}