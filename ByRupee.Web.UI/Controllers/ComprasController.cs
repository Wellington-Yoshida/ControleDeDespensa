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
    public class ComprasController : Controller
    {
        private Contexto db = new Contexto();
        //private ICadastroBo _compraBo;

       

        //GET: Compras:
        public ActionResult Index()
        {
            
            //Incluindo nome das lojas na lista de compras.
            var result = db.Compras.Include(x => x.Loja).ToList();

            return View(result);
        }



        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }



        // GET: Compras/Create
        public ActionResult Create()
        {

            ViewBag.Lojas = new SelectList(db.Lojas, "Id", "Nome");
            return View();
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataCompra,Quantidade,Nome,LojaId")] Compra compra)
        {
            if (ModelState.IsValid)
            {

                var compraBo = new CadastroBo();
                compraBo.Adicionar(compra);
             
                //_compraBo.Adicionar(compra);
                                              
                return RedirectToAction("Index");
            }
            ViewBag.Lojas = new SelectList(db.Lojas, "Id", "Nome", compra.Loja.Nome);
            return View(compra);
        }



        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var compra = db.Compras.Find(id);          
            
            
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lojas = new SelectList(db.Lojas, "Id", "Nome");
            return View(compra);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataCompra,Quantidade,Nome,LojaId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(compra).State = EntityState.Modified;
                var cadastroBo = new CadastroBo();
                cadastroBo.Editar(compra);
                //_compraBo.Editar(compra);
                return RedirectToAction("Index");
            }
            ViewBag.Lojas = new SelectList(db.Lojas, "Id", "Nome");
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete([Bind(Include = "Id,DataCompra,Quantidade,Nome,LojaId")] Compra compra, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra = db.Compras.Find(id);

            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cadastroBO = new CadastroBo();
            cadastroBO.Deletar(id);

            //_compraBo.Deletar(id);

            return RedirectToAction("Index");
        }



        /// <summary>
        /// Lista de Produtos Comprados na determinada Compra.
        /// </summary>
        /// <returns>Todos os produtos cadastrados na compra</returns>
        public ActionResult ListaDeCompra(Compra compra)
        {
            var lista = db.Produtos.Where(x => x.CompraId == compra.Id).Include(x => x.Compra).ToList();
            return View(lista);
        }
        

        /// <summary>
        /// Metodo para conferir se este Nome já existe no banco de dados
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ValidaNomeCompra(string nome)
        {
            var compra = new Compra();
            var filtraNome = nome.Trim();
            if (!String.IsNullOrEmpty(filtraNome))
            {
                compra = db.Compras.FirstOrDefault(x => x.Nome == filtraNome);
                if (compra!= null && compra.Id > 0)
                {
                    return Json(new { compra.Nome }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { Id = 1 }, JsonRequestBehavior.AllowGet);
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
