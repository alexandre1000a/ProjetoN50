using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class ReceberPagamentoController : Controller
    {
        //
        // GET: /ReceberPagamento/

        public ActionResult Index(Cliente cliente)
        {
            var negocios = new Negocios();

            IEnumerable<Cliente> recebeCliente = negocios.SelectTodosClientes();


            return View(recebeCliente);
        }

        public ActionResult RecebePagamentoCliente(Cliente cliente)
        {
            var contasreceber = new Contas_a_Receber();
            var negocios = new Negocios();
            Session["RecebePagamnentoCliente"] = cliente.id_cliente;

            IList<Contas_a_Receber> recebedados = negocios.RecuperaPagamentoCliente(cliente);
            if (recebedados.Count == 0 )
            {
                return Redirect("index");
            }
            else
            {
                foreach (var item in recebedados)
                {
                    contasreceber.id_contas_a_receber = item.id_contas_a_receber;
                    contasreceber.id_cliente = item.id_cliente;
                    contasreceber.data_a_receber = item.data_a_receber;
                    contasreceber.data_recebimento = item.data_recebimento;
                    contasreceber.valor_a_receber = item.valor_a_receber;
                    contasreceber.valor_recebido = item.valor_recebido;

                    Session["RecebePagamnentoCliente"] = contasreceber;
                    return View(contasreceber);

                }
            }

            return View("index");
        }

        [HttpPost]
        public ActionResult BaixaPagamentoRecebido(Contas_a_Receber contasreceber)
        {
            Contas_a_Receber recebedadosSession = (Contas_a_Receber)Session["RecebePagamnentoCliente"];
            contasreceber.id_cliente = recebedadosSession.id_cliente;
            contasreceber.id_contas_a_receber = recebedadosSession.id_contas_a_receber;
            contasreceber.valor_a_receber = recebedadosSession.valor_a_receber;

            var negocios = new Negocios();

            negocios.EditarContasAReceber(contasreceber);

            negocios.CalculaValorJurosDecontoContasReceber(contasreceber);


            return View(contasreceber);
        }

    }
}
