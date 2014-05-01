using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class CadastrarEnderecoClienteController : Controller
    {
        //
        // GET: /CadastrarEnderecoCliente/

        public ActionResult Index(Cliente cliente)
        {
            var negocios = new Negocios();
           IEnumerable<Cliente> retornaCliente = negocios.SelectTodosClientes();
           ViewBag.verificaEndereco = "";
         
           

            return View(retornaCliente);
        }


      
        public ActionResult CadastrarEndereco(Cliente cliente)
        {

            var negocios = new Negocios();
            var endereco = new Endereco();
            Session["RecebeIdCliente"] = cliente.id_cliente;
            
            string recebeVerificacao = negocios.VerificaEnderecoCLiente(cliente);

            if (recebeVerificacao == null)
            {
                return View(endereco);     
            }
            
            else
            {
            ViewBag.verificaEndereco = recebeVerificacao;
            Response.Redirect("Index");
            }

            return View("CadastrarEndereco",endereco);
           
        
        
        }

        public ActionResult CadastroEnderecoEfetuado(Endereco endereco)
        {
            var cliente = new Cliente();
            var negocios = new Negocios();
            cliente.id_cliente =(int)Session["RecebeIdCliente"];
            negocios.InserirTableEndereco(endereco);
            negocios.VincularIdEnderecoTabelaCliente(endereco, cliente);  

            return View(endereco);
        
        
        }





    }
}
