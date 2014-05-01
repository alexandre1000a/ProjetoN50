using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class CadastroFornecedorController : Controller
    {
        //
        // GET: /CadastroFornecedor/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarFornecedor(Fornecedor fornecedor)
        {
            var negocios = new Negocios();
            var guardastatusIdFornecedor = negocios.InserStatusFornecedor(fornecedor);
            fornecedor.id_status_fornecedor = guardastatusIdFornecedor;
            negocios.InserirTableFornecedor(fornecedor);


            return View(fornecedor);


        }

    }
}
