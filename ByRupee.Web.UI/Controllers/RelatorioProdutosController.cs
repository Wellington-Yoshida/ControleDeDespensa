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
    public class RelatorioProdutosController : Controller
    {
        Contexto db = new Contexto();

        // GET: RelatorioProdutos
        public ActionResult Index()
        {
            var result = db.Produtos.Include(x => x.Compra).ToList().OrderByDescending(x => x.Id).Take(3);

            return View(result);
        }
    }
}