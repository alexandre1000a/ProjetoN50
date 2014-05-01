using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(Usuarios usuarios)
        {
                        

            return View(usuarios);
        }
        [HttpPost]
        public ActionResult Resultado(Usuarios usuarios)
        {
            var negocios = new Negocios();

            negocios.InserirTableUsuarios(usuarios);

            return View();
        
        
        }

    }
}
