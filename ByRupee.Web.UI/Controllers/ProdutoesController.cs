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
using Cadastro.BO;

namespace ByRupee.Web.UI.Controllers
{
    public class ProdutoesController : Controller
    {
        private Contexto db = new Contexto();
        //private IProdutoBo _produtoBo;

       

        // GET: Produtoes
        public ActionResult Index()
        {
            return View(db.Produtos.Include(x => x.Compra).ToList());
                  
        }

      
        // GET: Produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            
            ViewBag.Compras = new SelectList(db.Compras, "Id", "Nome");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataValidade,Marca,QuantidadeDoItem,Nome,CompraId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                var produtoBo = new ProdutoBo();
                produtoBo.Adicionar(produto);
                //_produtoBo.Adicionar(produto);
                return RedirectToAction("Index");
            }
           
            ViewBag.Compras = new SelectList(db.Compras, "Id", "Nome");
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
         
            ViewBag.Compras = new SelectList(db.Compras, "Id", "Nome");
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataValidade,Marca,QuantidadeDoItem,Nome, LojaId,IdCompra")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(produto).State = EntityState.Modified;
                //db.SaveChanges();
                var produtoBo = new ProdutoBo();
                produtoBo.Editar(produto);

                //_produtoBo.Editar(produto);

                return RedirectToAction("Index");
            }
    
            ViewBag.Compras = new SelectList(db.Compras, "Id", "Nome");
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Produto produto = db.Produtos.Find(id);
            //db.Produtos.Remove(produto);
            //db.SaveChanges();

            var produtoBo = new ProdutoBo();
            produtoBo.Deletar(id);

            //_produtoBo.Deletar(id);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Validando quantidade de Item no estoque
        /// </summary>
        /// <returns>Retorne um alerta quanto determinado produto estiver com apenas 1 item no estoque</returns>
        [HttpGet]
        public ActionResult ValidaQuantidade()
        {
            var produto = new Produto();

            produto = this.db.Produtos.FirstOrDefault(x => x.QuantidadeDoItem == 1);

            return Json(produto, JsonRequestBehavior.AllowGet);
            
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
