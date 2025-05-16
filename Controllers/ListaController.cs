using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroCoops.Models;

namespace AgroCoops.Controllers
{
    public class ListaController : Controller
    {
        // GET: Lista

        AgroBDEntities2 bd = new AgroBDEntities2();

        public ActionResult EditarCoop()
        {
            return View();
        }

        public ActionResult ExcluirCoop()
        {
            return View();
        }

        public ActionResult ExcluirProd()
        {
            return View();
        }

        public ActionResult EditarProd()
        {
            return View();
        }


        public ActionResult ListaProd()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditarCoop(int id)
        {
            Cooperativa c = bd.Cooperativa.ToList().Find(x => x.IDCooperativa == id);


            return View(p);
        }
        public ActionResult EditarCoop(String nomecoop, long telefoneC, String emailC, long cnpjC, String cidade, char estado, String regiao)
        {

            Cooperativa c = bd.Cooperativa.ToList().Find(x => x.IDCooperativa == id);

            c.NomeCooperativa = nomecoop;
            c.Telefone = telefoneC;
            c.Email = emailC;
            c.CnpjCooperativo = cnpjC;
            c.Cidade = cidade;
            c.Estado = estado.ToString();
            c.Regiao = regiao;

            bd.SaveChanges();

            return View("ListarCoop", bd.Cooperativa.ToList());
        }

        public ActionResult ExcluirCoop(int id)

        { 
            Cooperativa c = bd.Cooperativa.ToList().Find(x => x.IDCooperativa == id);


            bd.Cooperativa.Remove(c);
            bd.SaveChanges();


            return View("ListaCoop", bd.Cooperativa.ToList());
        }

        public ActionResult ExcluirProd(int id)

        {
            Produto prod = bd.Produto.ToList().Find(x => x.IDProduto == id);


            bd.Produto.Remove(prod);
            bd.SaveChanges();


            return View("ListaProd", bd.Produto.ToList());
        }


        [HttpGet]
        public ActionResult EditarProd(int id)
        {
            Cooperativa c = bd.Cooperativa.ToList().Find(x => x.IDCooperativa == id);

            return View(p);
        }
        public ActionResult EditarProd(String descricaoP, decimal valorunit)
        {

            Produto prod = bd.Produto.ToList().Find(x => x.IDProduto == id);


            prod.DescricaoProduto = descricaoP;
            prod.ValorUnitario = valorunit;

            bd.SaveChanges();

            return View("ListarCoop", bd.Cooperativa.ToList());
        }





    }



}