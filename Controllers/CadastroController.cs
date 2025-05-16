using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroCoops.Models;

namespace AgroCoops.Controllers
{
    public class CadastroController : Controller
    {

        AgroBDEntities2 bd = new AgroBDEntities2();
        // GET: Cadastro
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
        public ActionResult CadastroPessoa()
        {
            return View();
        }

        public ActionResult CadastroPessoaF()
        {
            return View();
        }

        public ActionResult CadastroPessoaJ()
        {
            return View();
        }
      
        public ActionResult CadastroProd()
        {
            return View();
        }
        public ActionResult CadastroPessoaP()
        {
            return View();
        }

        public ActionResult CadastroCoop()
        {
            return View();
        }

        [HttpGet]
         public ActionResult CadastroPessoaF(int id)
        {
           
            Pessoa p = bd.Pessoa.ToList().Find(x => x.IDPessoa == id);
                
            return View();
        }

        [HttpPost]
        public ActionResult CadastroPessoa(String nome, long telefone, String email, String senha, string tipoPessoa)
        {

            Pessoa p = new Pessoa();

            p.Nome = nome;
            p.Telefone = telefone;
            p.Email = email;
            p.Senha= senha;
            p.TipoPessoa = tipoPessoa;


            bd.Pessoa.Add(p);
            bd.SaveChanges();

            if(p.TipoPessoa == "F")
            {
                return View("CadastroPessoaF");
            }


            if (p.TipoPessoa == "J")
            {
                return View("CadastroPessoaJ");
            }

            if (p.TipoPessoa == "P")
            {
                return View("CadastroPessoaP");
            }


            return View("Listar", bd.Pessoa.ToList());
        }

        [HttpGet]
        public ActionResult EditarPessoa(int id)
        {
            Pessoa p = bd.Pessoa.ToList().Find(x => x.IDPessoa == id);

            
            return View(p);
        }
        public ActionResult EditarPessoa(int id, String nome, long telefone, String email, String senha, String tipoPessoa)
        {
            Pessoa p = bd.Pessoa.ToList().Find(x => x.IDPessoa == id);

            p.Nome = nome;
            p.Telefone = telefone;
            p.Email = email;
            p.Senha = senha;
            p.TipoPessoa = tipoPessoa;

            bd.SaveChanges();

            return View("Listar", bd.Pessoa.ToList());
        }


        [HttpPost]
        public ActionResult CadastroPessoaF(int id,long cpf, DateTime datanasc, char sexo)
        {
           

            PessoaFisica f = new PessoaFisica();

            Pessoa p = bd.Pessoa.ToList().Find(x => x.IDPessoa == id);


            f.Cpf = cpf;
            f.DataNascimento = datanasc;
             
            f.Sexo = sexo.ToString();

            bd.PessoaFisica.Add(f);
            bd.SaveChanges();



            return View("Listar", bd.PessoaFisica.ToList());
        }

        [HttpPost]
        public ActionResult CadastroPessoaJ(long cnpj, string nomeFantasia)
        {
            PessoaJuridica j = new PessoaJuridica();


            j.Cnpj = cnpj;
            j.NomeFantasia = nomeFantasia;

            bd.PessoaJuridica.Add(j);
            bd.SaveChanges();



            return View("Listar", bd.PessoaJuridica.ToList());
        }


        [HttpPost]
        public ActionResult CadastroCoop(String nomecoop, long telefoneC, String emailC, long cnpjC, String cidade, string estado, String regiao)
        {

            Cooperativa c = new Cooperativa();

            c.NomeCooperativa = nomecoop;
            c.Telefone = telefoneC;
            c.Email = emailC;
            c.CnpjCooperativo = cnpjC;
            c.Cidade = cidade;
            c.Estado = estado;
            c.Regiao = regiao;


            bd.Cooperativa.Add(c);
            bd.SaveChanges();



            return View("ListaCoop", bd.Cooperativa.ToList());
        }

        public ActionResult ExcluirPessoa(int id)

        {

            Pessoa p = bd.Pessoa.ToList().Find(x => x.IDPessoa == id);


            bd.Pessoa.Remove(p);
            bd.SaveChanges();


            return View("Listar", bd.Pessoa.ToList());
        }

         [HttpPost]
        public ActionResult CadastroPessoaP(long carteiraP)
        {
            Produtor pr = new Produtor();

            pr.CarteiraProdutor = carteiraP;


            bd.Produtor.Add(pr);
            bd.SaveChanges();

            return View("Listar", bd.Produtor.ToList());
        }

        [HttpPost]
        public ActionResult CadastroProd(String descricaoP, decimal valorunit)
        {
            Produto prod = new Produto();

            prod.DescricaoProduto = descricaoP;
            prod.ValorUnitario = valorunit;

            bd.Produto.Add(prod);
            bd.SaveChanges();

            return View("Listar", bd.Produto.ToList());
        }


    }
}