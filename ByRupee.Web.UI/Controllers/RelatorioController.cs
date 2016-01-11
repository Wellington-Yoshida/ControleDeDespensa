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
    public class RelatorioController : Controller
    {
        Contexto db = new Contexto();
        // GET: Relatorio
        public ActionResult Index()
        {

            var result = db.Compras.Include(x => x.Loja).ToList().OrderByDescending(x => x.Id).Take(3);

            return View(result);
        }
    }
}