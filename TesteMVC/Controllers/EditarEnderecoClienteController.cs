using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class EditarEnderecoClienteController : Controller
    {
        //
        // GET: /EditarEnderecoCliente/

        public ActionResult Index(Cliente cliente)
        {
            try
            {


                var negocios = new Negocios();
                var retornaObjetoCliente = negocios.SelectClienteEndereco(cliente);
                List<Endereco> retornaEnderecoPreenchido = negocios.BuscarEnderecoCliente(retornaObjetoCliente);
                if (retornaEnderecoPreenchido != null)
                {
                    Session["RetornaObjetoCliente"] = retornaObjetoCliente;
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
                    Response.Redirect("~/CadastrarEnderecoCLiente/index");
                }
            }

            catch (Exception ex)
            {

                throw new Exception("Erro" + ex.Message.ToString());
            }



            return View("Index");
        }

        [HttpPost]
        public  ActionResult EnderecoEditado(Endereco endereco )
        {
            Cliente capturaObjto =(Cliente) Session["RetornaObjetoCliente"];

            endereco.id =(int) capturaObjto.id_endereco;
          
            var negocios = new Negocios();

            negocios.EditarEndereco(endereco);
            
            
            return View();    


        
        }



    }
}
