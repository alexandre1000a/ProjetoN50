using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class StatusFornecedorController : Controller
    {
        //
        // GET: /StatusFornecedor/

        public ActionResult Index(Fornecedor fornecedor)
        {
            var negocios = new Negocios();
            ObjectResult<pc_status_fornecedor2_Result> retornaFornecedor = negocios.PcStatusFornecedor();
            

            return View(retornaFornecedor);
        }

        public ActionResult RecebeStatusFornecedor(Fornecedor fornecedor)
        {
            var negocios = new Negocios();
            var statusFornecedor = new Status_Usuario_Fornecedor();
            List<Status_Usuario_Fornecedor> retornaStatusFornecedor = negocios.BuscaStatusFornecedor(fornecedor);

            foreach (var item in retornaStatusFornecedor)
            {
                statusFornecedor.id_status = item.id_status;
                statusFornecedor.status_Ativo_Inativo = item.status_Ativo_Inativo;

            }
            negocios.EditarStatusFornecedor(fornecedor);

            retornaStatusFornecedor = null;
            Response.Redirect("~/StatusFornecedor/Index");
            return View(fornecedor);

        }

    }
}
