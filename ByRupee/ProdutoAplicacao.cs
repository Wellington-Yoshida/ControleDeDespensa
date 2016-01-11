using Cadastro.Dominio;
using Cadastro.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByRupee
{
    public class ProdutoAplicacao
    {
        public Contexto banco { get; set; }

        public ProdutoAplicacao()
        {
            banco = new Contexto();
        }

        public void Salvar(Produto produto)
        {
            banco.Produtos.Add(produto);
        }

        public IEnumerable<Produto> Lista()
        {
            return banco.Produtos.ToList();
        }

        public void Alterar(Produto produto)
        {
            Produto produtoSalvar = banco.Produtos.Where(x => x.Id == produto.Id).First();
            produtoSalvar.Nome = produto.Nome;
            produtoSalvar.Marca = produto.Marca;
            produtoSalvar.QuantidadeDoItem = produto.QuantidadeDoItem;
            produtoSalvar.DataValidade = produto.DataValidade;
            banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Produto produtoExcluir = banco.Produtos.Where(x => x.Id == Id).First();
            banco.Set<Produto>().Remove(produtoExcluir);
            banco.SaveChanges();
        }
    }
}
