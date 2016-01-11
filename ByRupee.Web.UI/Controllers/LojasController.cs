using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cadastro.Dominio;
using Cadastro.ORM;
using Cadastro.BO.Interface;
using Cadastro.BO;

namespace ByRupee.Web.UI.Controllers
{
    public class LojasController : Controller
    {
        private Contexto db = new Contexto();
        
        

        // GET: Lojas
        public ActionResult Index()
        {
            return View(db.Lojas.ToList());
        }

        [HttpGet]
        public ActionResult RetornaAjax(string param)
        {
            return Json(new { Resultado = "Ajax OK!!", Parametro = param + " AJAX " },JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Valida Campo Endereço
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Alerta caso o endereço já exista no Banco de Dados</returns>
        [HttpGet]
        public ActionResult ValidaNome(string endereco)
        {
            Loja loja = new Loja();
            var valorFiltrado = endereco.Trim();
            if (!String.IsNullOrEmpty(valorFiltrado))
            {
                loja = db.Lojas.FirstOrDefault(x => x.Endereco == valorFiltrado);
                if (loja!= null && loja.Id > 0)
                {
                    return Json(new { loja.Endereco }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Id = 1 }, JsonRequestBehavior.AllowGet);
        }


        
        public ActionResult Apresentacao()
        {
            return View("Apresentacao");
        }

        // GET: Lojas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // GET: Lojas/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Lojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Endereco,Nome")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                //db.Lojas.Add(loja);
                //db.SaveChanges();

                var lojaBo = new LojaBo();
                lojaBo.Adicionar(loja);
                //_lojaBo.Adicionar(loja);

                return RedirectToAction("Index");
            }

            return View(loja);
        }


        // GET: Lojas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }


        // POST: Lojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Endereco,Nome")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(loja).State = EntityState.Modified;
                //db.SaveChanges();
                var lojaBo = new LojaBo();
                lojaBo.Editar(loja);
                //_lojaBo.Editar(loja);

                return RedirectToAction("Index");
            }
            return View(loja);
        }

        // GET: Lojas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Loja loja = db.Lojas.Find(id);
            //db.Lojas.Remove(loja);
            //db.SaveChanges();
            var lojaBo = new LojaBo();
            lojaBo.Deletar(id);
            //_lojaBo.Deletar(id);

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
