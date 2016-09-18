using NetB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetB.Controllers
{
    public class CalendarioController : Controller
    {
        // GET: Calendario
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Eventos()
        {
            List<evento> eventos = new List<evento>();
            eventos.Add(new evento
            {
                id = 293,
                title = "This is warning class event with very long title to check how it fits to evet in day view",
                url = "http://www.example.com/",
                classe = "event-warning",
                start = "1362938400000",
                end = "1363197686300"
            });
            var retorno = new { success = 1, result = eventos };
            return Json(retorno,JsonRequestBehavior.AllowGet);
        }
    }
}