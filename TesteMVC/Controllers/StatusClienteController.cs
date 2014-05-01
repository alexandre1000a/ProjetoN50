using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class StatusClienteController : Controller
    {
        //
        // GET: /StatusCliente/

        public ActionResult Index(Cliente cliente)
        {
            var negocios = new Negocios();
            
            ObjectResult<pc_status_cliente4_Result> recebeStatusCliente = negocios.PcRetornaStatusCliente();
          
            return View(recebeStatusCliente);
        }

        public ActionResult RecebeStatusCliente(Cliente cliente)
        {
            var negocios = new Negocios();
            var statusUsuario = new Status_Usuario_Fornecedor();
            List<Status_Usuario_Fornecedor>retornaStatusCliente = negocios.BuscaStatusCliente(cliente);
            
            foreach (var item in retornaStatusCliente)
	{
		statusUsuario.id_status = item.id_status;
        statusUsuario.status_Ativo_Inativo = item.status_Ativo_Inativo;
      
	}
            negocios.EditarStatusCliente(cliente);

            retornaStatusCliente = null;
            Response.Redirect("~/StatusCliente/Index");
            return View();

        }

    }
}
