using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class GerarCompraController : Controller
    {
        //
        // GET: /GerarCompra/

        public ActionResult Index(Fornecedor fornecedor)
        {
            var negocios = new Negocios();

            IEnumerable<Fornecedor> recebeListaFornecedor = negocios.SelectTodosFornecedores();
            return View(recebeListaFornecedor);

        }

    }
}
