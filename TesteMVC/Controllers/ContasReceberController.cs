using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class ContasReceberController : Controller
    {
        //
        // GET: /ContasReceber/

        public ActionResult Index(Contas_a_Receber contasreceber)
        {
            var negocios = new Negocios();
            var cliente = new Cliente();
            cliente.id_cliente =(int) contasreceber.id_cliente;
            negocios.SelectTodosClientesporID(cliente);
            Session["guardaObjtoContasReceber"] = contasreceber;
            return View(contasreceber);
        }

        [HttpPost]
        public ActionResult ContasAReceber(Contas_a_Receber contasreceber)
        {
            var recuperaId = new Contas_a_Receber();
            var negocios = new Negocios();
            recuperaId =(Contas_a_Receber) Session["guardaObjtoContasReceber"];
            contasreceber.id_cliente = recuperaId.id_cliente;
            negocios.InserirTableContasAReceber(contasreceber);

            return View(contasreceber);
        
        }

    }
}
