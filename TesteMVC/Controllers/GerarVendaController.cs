using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class GerarVendaController : Controller
    {
        //
        // GET: /GerarVenda/

        public ActionResult Index()
        {
            var negocios = new Negocios();
            IEnumerable<Cliente> guardalistaCliente = negocios.SelectTodosClientes();  
            return View(guardalistaCliente);
        }

      
    }
}
