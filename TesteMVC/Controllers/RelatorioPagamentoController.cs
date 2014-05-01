using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class RelatorioPagamentoController : Controller
    {
        //
        // GET: /RelatorioPagamento/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContasAPagar()
        {
            var negocios = new Negocios();

            ObjectResult<pc_relatorio_pagamento1_Result> retorna = negocios.PcRelatorioPagamento();

            return View(retorna);



        }

    }
}
