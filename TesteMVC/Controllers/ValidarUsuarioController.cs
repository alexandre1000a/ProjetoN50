using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class ValidarUsuarioController : Controller
    {
        //
        // GET: /ValidarUsuario/

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ValidaUsuario(Usuarios usuarios)
        {
            var negocios = new Negocios();
            
            IEnumerable<Usuarios> retornaUsuario = negocios.Listar(usuarios);

            foreach (var item in retornaUsuario)
            {
                if (item.senha == usuarios.senha)
                {
                    Session["Usuarios"] = usuarios;
                    Response.Redirect("~/HomeLogin/Index");

                }

                else if(item.senha != usuarios.senha || item.email_usuario != usuarios.email_usuario)
                {
                    return View("Index");
                }
                
            }
            return View("Index", usuarios);
           
        }
        


    }
}
