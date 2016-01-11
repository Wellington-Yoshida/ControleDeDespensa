using Cadastro.BO;
using Cadastro.Dominio;
using Cadastro.ORM;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ByRupee.Web.UI.Controllers
{
    public class GraficosController : Controller
    {
        Contexto db = new Contexto();


        private ProdutoBo _produtoBo = new ProdutoBo();
        private CadastroBo _compraBo = new CadastroBo();


        // GET: Graficos
        public ActionResult Index()
        {
            var produto = new Produto();

            var intArray = _produtoBo.ObterProdutos().Select(x => x.Quantidade);
            var objectArray = intArray.Cast<object>().ToArray();

            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")

            .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
            .SetTitle(new Title { Text = "Quantidade de Produtos Comprados" })

        .SetXAxis(new XAxis

        {
            
            Categories = _produtoBo.ObterProdutos().Select(x => x.Produto).ToArray()
        })

         .SetYAxis(new YAxis
         {
             Min = 0,
             Title = new YAxisTitle { Text = "Total Produtos" }
         })

        .SetSeries(new Series
        {

            Name = "Produto",
            Data = new Data(objectArray)
           
        });

            ViewBag.grafico = chart;

            var intArrayCompra = _compraBo.ObterCompra().Select(x => x.QuantidadeItem);
            var objArrayCompra = intArrayCompra.Cast<object>().ToArray();

            DotNet.Highcharts.Highcharts graficoCompra = new DotNet.Highcharts.Highcharts("graficoCompra")

            .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
            .SetTitle(new Title { Text = "Quantidade de Compras" })

        .SetXAxis(new XAxis

        {

            Categories = _compraBo.ObterCompra().Select(x => x.Compra).ToArray()
        })

         .SetYAxis(new YAxis
         {
             Min = 0,
             Title = new YAxisTitle { Text = "Total de itens por Compras" }
         })

        .SetSeries(new Series
        {

            Name = "Compras",
            Data = new Data(objArrayCompra)

        });
            ViewBag.Compra = graficoCompra;
           


            return View();
            
        }

      
    }
}