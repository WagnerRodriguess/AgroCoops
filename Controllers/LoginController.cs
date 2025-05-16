using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroCoops.Models;

namespace AgroCoops.Controllers
{


    public class LoginController : Controller
    {
        AgroBDEntities2 bd = new AgroBDEntities2();

        // GET: Login
        public ActionResult LoginPessoa()
        {
            return View();
        }

        public ActionResult Index() 
        {
            {
                if (Session["sessao"] != null)
                {
                    return View(bd.Pessoa.ToList());
                }
                else
                {
                    return RedirectToAction("LoginPessoa", "Login");
                }

            }

        }

        public ActionResult Listar()
        {
            {
                if (Session["sessao"] != null)
                {
                    return View(bd.Pessoa.ToList());
                }
                else
                {
                    return RedirectToAction("LoginPessoa", "Login");
                }

            }

        }


        [HttpPost]
        public ActionResult LoginPessoa(String email, string senha)
        {
            foreach (var item in bd.Pessoa.ToList())
            {
                if ((item.Email == email) && (item.Senha == senha))
                {
                    Session["sessao"] = "Logado";
                    return RedirectToAction("Listar", "Cadastro");
                }
            }

            ViewBag.errologin = "LOGIN INVÁLIDO!!";
            return View();
        }


    }
}