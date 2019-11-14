using LauroCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LauroCRUD.Controllers
{
    public class PessoaController : Controller
    {

        CrudDBEntities1 bd = new CrudDBEntities1();

        [HttpGet]
        public ActionResult CriarPessoa()
        {
            var cargo = bd.cargo.ToList();
            ViewBag.cargo = new SelectList(cargo, "id", "nome");
            return View();
        }

                       
        [HttpPost]
        // Para aceitar o código html vindo do campo Descrição
        public ActionResult CriarPessoa(Pessoa pessoa)
        {
            if (bd.Pessoa.FirstOrDefault(x => x.cpf == pessoa.cpf || x.email == pessoa.email) != null) return RedirectToAction("ListarPessoa");
            bd.Pessoa.Add(pessoa);
            bd.SaveChanges();
            return RedirectToAction("ListarPessoa");
        }

        [HttpGet]
        public ActionResult EditarPessoa(int id)
        {
            var pessoa = bd.Pessoa.FirstOrDefault(x => x.id == id);
            ViewBag.data = pessoa.data.ToString("yyyy-MM-dd");            
            var cargo = bd.cargo.ToList();
            ViewBag.cargo = new SelectList(cargo, "id", "nome");
            return View(pessoa);
        }

        [HttpPost]     
        public ActionResult EditarPessoa(Pessoa pessoa)
        {
            var p = bd.Pessoa.FirstOrDefault(x => x.id == pessoa.id);
            p.nome = pessoa.nome;
            p.cargoId = pessoa.cargoId;
            p.email = pessoa.email;
            p.data = pessoa.data;
            p.celular = pessoa.celular;
            bd.Entry(p).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
            return RedirectToAction("ListarPessoa");
        }

        [HttpPost]
        public ActionResult RemoverPessoa(int id)
        {
            var p = bd.Pessoa.FirstOrDefault(x => x.id == id);
            bd.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            bd.SaveChanges();
            return RedirectToAction("ListarPessoa");
        }

        public ActionResult ListarPessoa(string Mensagem)
        {
            var list = bd.Pessoa.ToList();
            return View(list);
        }

        public ActionResult DetalhePessoa(int id)
        {
            var pessoa = bd.Pessoa.FirstOrDefault(x => x.id == id);
            return View(pessoa);
        }        


    }
}