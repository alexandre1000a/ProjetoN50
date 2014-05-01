using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class RelatorioRecebimentoController : Controller
    {
        //
        // GET: /RelatorioRecebimento/

        public ActionResult Index()
       {
         
         

            return View();
        }

        public ActionResult RetornaRelatorio()
        {
            var negocios = new Negocios();

            ObjectResult<pc_Relatorio_inadimplente_1_Result> retorna = negocios.ProcedureInadimplentes();

            return View(retorna);

        }
        
    

      

    }
}
