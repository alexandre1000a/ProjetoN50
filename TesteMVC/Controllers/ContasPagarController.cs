using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class ContasPagarController : Controller
    {
        //
        // GET: /ContasPagar/

        public ActionResult Index(Contas_a_Pagar contaspagar)
        {
            var negocios = new Negocios();
            var fornecedor = new Fornecedor();
            fornecedor.id_fornecedor = (int)contaspagar.id_fornecedor;
            negocios.SelectTodosFornecedoresporID(fornecedor);
            Session["guardaObjtoContasPagar"] = contaspagar;
            return View(contaspagar);
        }

        [HttpPost]
        public ActionResult ContasAPagar(Contas_a_Pagar contaspagar)
        {
            var recuperaId = new Contas_a_Pagar();
            var negocios = new Negocios();
            recuperaId = (Contas_a_Pagar)Session["guardaObjtoContasPagar"];
            contaspagar.id_fornecedor = recuperaId.id_fornecedor;
            
            negocios.InserirTableContasAPagar(contaspagar);

            return View(contaspagar);

        }

    }
}
