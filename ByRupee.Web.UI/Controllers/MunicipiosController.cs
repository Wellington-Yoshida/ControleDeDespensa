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

namespace ByRupee.Web.UI.Controllers
{
    [RoutePrefix("app")]
    //[Route("{action=index}")]
    public class MunicipiosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Municipios
        //[Route("Teste")]
        //[Route("Teste/{TesteId}")]
        //[Route("Teste/{testeid}/Edit")]
        //[Route("~/Teste")]
        
        [Route("municipios")]
        public ActionResult Index()
        {
            var municipios = db.Municipios.Include(m => m.Estado);
            return View(municipios.ToList());
        }

        [Route("Apresentacao")]
        public ActionResult Apresentacao()
        {

            var estados = new SelectList(db.Estados.ToList(),"EstadoId","Nome");
            ViewData["estados"] = estados;
            return View();
        }

        /// <summary>
        /// Obtem a lista de municipios atraves do identificador 
        /// </summary>
        /// <param name="estadoId">identificadorde Estado</param>
        /// <returns>Lista de municipios no formato jsom</returns>
        [HttpGet]
        [Route("municipiosAjax/{estadoId:int}")]
        public ActionResult ObterMunicipioPorEstadoId(int estadoId)
        {
            var municipios = db.Municipios.Where(x => x.EstadoId == estadoId).ToList();

            return Json(new { data = municipios }, JsonRequestBehavior.AllowGet);
        }



        // GET: Municipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome");
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MunicipioId,Nome,EstadoId")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipios.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome", municipio.EstadoId);
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome", municipio.EstadoId);
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MunicipioId,Nome,EstadoId")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome", municipio.EstadoId);
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            db.Municipios.Remove(municipio);
            db.SaveChanges();
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
