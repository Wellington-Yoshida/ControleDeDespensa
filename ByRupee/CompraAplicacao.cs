using Cadastro.Dominio;
using Cadastro.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByRupee
{
    public class CompraAplicacao
    {
        public Contexto banco { get; set; }

        public CompraAplicacao()
        {
            banco = new Contexto();
        }

        public void Salvar(Compra compra)
        {
            banco.Compras.Add(compra);
            banco.SaveChanges();
        }

        public IEnumerable<Compra> Lista()
        {
            return banco.Compras.ToList();
        }

        public void Alterar(Compra compra)
        {
            Compra compraSalvar = banco.Compras.Where(x => x.Id == compra.Id).First();
            compraSalvar.Nome = compra.Nome;
            compraSalvar.Quantidade = compra.Quantidade;
            compraSalvar.DataCompra = compra.DataCompra;
            banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Compra compraExcluir = banco.Compras.Where(x => x.Id == Id).First();
            banco.Set<Compra>().Remove(compraExcluir);
            banco.SaveChanges();
        }
    }
}
