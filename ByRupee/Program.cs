using Cadastro.Dominio;
using Cadastro.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByRupee
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CompraAplicacao appCompra = new CompraAplicacao();
            Loja loja = new Loja();
            Compra compra = new Compra();
            var db = new Contexto();

            //compra.Nome = "Compra 01";
            //compra.DataCompra = DateTime.Now;
            //compra.Quantidade = 15;
            //db.Compras.Add(compra);

            compra.Nome = "Compra 02";
            compra.DataCompra = DateTime.Now;
            compra.Quantidade = 60;
            compra.Loja = db.Lojas.FirstOrDefault(x => x.Id == 1); // Para referenciar id_loja na tabela compra.
            db.Compras.Add(compra);


            //var compras = db.Compras.FirstOrDefault(x => x.Id == 2); Update
            //compras.Nome = "Compra01";

            //var comprasDelete = db.Compras.FirstOrDefault(x => x.Id == 8);
            //db.Compras.Remove(comprasDelete);

            //var compras = db.Compras.FirstOrDefault(x => x.Id == 2);
            //compras.Quantidade = 100;

            //var comprasDeletadas = db.Compras.FirstOrDefault(x => x.Id == 5);
            //db.Compras.Remove(comprasDeletadas);
            //Loja lojas = new Loja();
            //lojas.Nome = "Big";
            //db.Lojas.Add(lojas);
          
            
            
            //var loja = db.Lojas.FirstOrDefault(x => x.Id == 1);
            //db.Lojas.Remove(loja);

            //var compras = (from x in db.Compras
            //              where x.Id == 2
            //              select x).First();

            db.SaveChanges();
            Console.ReadKey();
            //hweuyfoaio
        }
    }
}
