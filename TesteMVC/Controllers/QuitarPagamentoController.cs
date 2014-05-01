using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class QuitarPagamentoController : Controller
    {
        //
        // GET: /QuitarPagamento/

        public ActionResult Index(Fornecedor fornecedor)
        {
            var negocios = new Negocios();
            
            IEnumerable<Fornecedor> recebeFornecedor = negocios.SelectTodosFornecedores();

            return View(recebeFornecedor);
        }

        public ActionResult RecebePagamento(Fornecedor fornecedor)
        {
            var contaspagar = new Contas_a_Pagar();
            var negocios = new Negocios();
            Session["RecebePagamento"] = fornecedor.id_fornecedor;

            IList<Contas_a_Pagar> recebedados =  negocios.RecuperaPagamentoFornecedor(fornecedor);
            if (recebedados.Count == 0)
            {
                ViewBag.AvisoQuitaPagamento = "Não existe Compra gerada para este Fornecedor";
                Response.Redirect("~/QuitarPagamento/index");
            }
            else
            {
                foreach (var item in recebedados)
                {
                    contaspagar.data_pagamento = item.data_pagamento;
                    contaspagar.data_valor_pago = item.data_valor_pago;
                    contaspagar.id_contas_a_pagar = item.id_contas_a_pagar;
                    contaspagar.valor_a_pagar = item.valor_a_pagar;
                    contaspagar.valor_pago = item.valor_pago;
                    Session["recebeContasPagar"] = contaspagar;
                    return View(contaspagar);

                }
            }
          
            return View("index");

        }

        [HttpPost]
        public ActionResult BaixaPagamento(Contas_a_Pagar contasPagar)
        {
            Contas_a_Pagar recebedadosSession = (Contas_a_Pagar)Session["recebeContasPagar"];
            contasPagar.id_contas_a_pagar = recebedadosSession.id_contas_a_pagar;
            contasPagar.valor_a_pagar = recebedadosSession.valor_a_pagar;

            var negocios = new Negocios();

            negocios.EditarContasAPagar(contasPagar);

            negocios.CalculaValorJurosDecontoContasPagar(contasPagar);


            return View(contasPagar);
        }

    }
}
