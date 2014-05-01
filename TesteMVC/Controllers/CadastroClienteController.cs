using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class CadastroClienteController : Controller
    {
        //
        // GET: /CadastroCliente/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente)
        {
            var negocios = new Negocios();
            var guardastatusIdCliente = negocios.InserStatusCliente(cliente);
            cliente.id_status_cliente = guardastatusIdCliente;
            negocios.InserirTableCliente(cliente);
        
            
            return View(cliente);
        
        
        }

       

    }
}
