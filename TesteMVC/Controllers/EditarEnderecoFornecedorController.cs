using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class EditarEnderecoFornecedorController : Controller
    {
        //
        // GET: /EditarEnderecoFornecedor/

        public ActionResult Index(Fornecedor fornecedor)
        {
            try
            {
                var negocios = new Negocios();
                var retornaObjetoFornecedor = negocios.SelectFornecedorEndereco(fornecedor);
                List<Endereco> retornaEnderecoPreenchido = negocios.BuscarEnderecoFornecedor(retornaObjetoFornecedor);
                 if (retornaEnderecoPreenchido != null)
                {
                Session["RetornaObjetoFornecedor"] = retornaObjetoFornecedor;
                foreach (var item in retornaEnderecoPreenchido)
                {

                    Endereco ConverteListParaEndereco = new Endereco();
                    ConverteListParaEndereco.rua = item.rua;
                    ConverteListParaEndereco.numero = item.numero;
                    ConverteListParaEndereco.cep = item.cep;
                    ConverteListParaEndereco.cidade = item.cidade;
                    ConverteListParaEndereco.estado = item.estado;
                    ConverteListParaEndereco.pais = item.pais;

                    return View(ConverteListParaEndereco);
                }

                }

                 else
                 {
                     Response.Redirect("~/CadastrarEnderecoFornecedor/index");
                 }
            }

            catch (Exception)
            {

                throw;
            }



            return View("Index");
        }




        [HttpPost]
        public ActionResult EnderecoFornecedorEditado(Endereco endereco)
        {
            Fornecedor capturaObjto = (Fornecedor)Session["RetornaObjetoFornecedor"];

            endereco.id = (int)capturaObjto.id_endereco;




            var negocios = new Negocios();

            negocios.EditarEndereco(endereco);


            return View();



        }

    }
}
