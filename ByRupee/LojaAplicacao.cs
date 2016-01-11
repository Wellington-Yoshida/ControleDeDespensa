using Cadastro.Dominio;
using Cadastro.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByRupee
{
    public class LojaAplicacao
    {
        public Contexto banco { get; set; }

        public LojaAplicacao()
        {
            banco = new Contexto();
        }

        public void Salvar(Loja loja)
        {
            banco.Lojas.Add(loja);
            banco.SaveChanges();
        }

        public IEnumerable<Loja> Lista()
        {
            return banco.Lojas.ToList();
        }

        public void Alterar(Loja loja)
        {
            Loja lojaSalvar = banco.Lojas.Where(x => x.Id == loja.Id).First();
            lojaSalvar.Nome = loja.Nome;
            lojaSalvar.Endereco = loja.Endereco;
            banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Loja lojaExcluir = banco.Lojas.Where(x => x.Id == Id).First();
            banco.Set<Loja>().Remove(lojaExcluir);
            banco.SaveChanges();
        }
    }
}
