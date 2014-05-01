using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class CadastrarEnderecoFornecedorController : Controller
    {
        //
        // GET: /CadastrarEnderecoFornecedor/

        public ActionResult Index(Fornecedor fornecedor)
        {
            var negocios = new Negocios();
            IEnumerable<Fornecedor> retornaFornecedor = negocios.SelectTodosFornecedores();

            return View(retornaFornecedor);
        }

        public ActionResult CadastradoFornecedorEndereco(Fornecedor fornecedor)
        {
            var negocios = new Negocios();
            var endereco = new Endereco();
            Session["RecebeIdFornecedor"] = fornecedor.id_fornecedor;

            string recebeVerificacao = negocios.VerificaEnderecoFornecedor(fornecedor);

            if (recebeVerificacao == null)
            {
                return View(endereco);
            }

            else
            {
                ViewBag.verificaEndereco = recebeVerificacao;
                Response.Redirect("Index");
            }
            return View(endereco);


        }

        public ActionResult CadastroEnderecoFornecedorEfetuado(Endereco endereco)
        {
            var fornecedor = new Fornecedor();
            var negocios = new Negocios();
            fornecedor.id_fornecedor = (int)Session["RecebeIdFornecedor"];
            negocios.InserirTableEndereco(endereco);
            negocios.VincularIdEnderecoTabelaFornecedor(endereco, fornecedor);

            return View(endereco);


        }

    }
}
