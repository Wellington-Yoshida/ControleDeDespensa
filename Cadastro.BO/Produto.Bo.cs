using Cadastro.BO.Interface;
using Cadastro.Dominio;
using Cadastro.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.BO
{
    public class ProdutoBo : IProdutoBo
    {
        #region Propriedade

        public Contexto db = new Contexto();

        #endregion 

        /// <summary>
        /// Metodo para cadastrar um produto somente se sua quantidade for maior que zero
        /// </summary>
        /// <param name="produto">O produto inserido no formulario para ser gravado a base de dados</param>
        /// <returns></returns>
        public void Adicionar(Produto produto)
        {
            if (IsValidacao(produto))
			{
                db.Produtos.Add(produto);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Metodo para obter quantidade e Nome dos produtos para o gráfico
        /// </summary>
        /// <returns></returns>
        public List<GraficoProduto> ObterProdutos()
        {
            var result = from i in db.Produtos
                         select new GraficoProduto { Produto = i.Nome, Quantidade = i.QuantidadeDoItem };

            return result.ToList();
        }
      


        /// <summary>
        /// Metodo para Editar os Produtos
        /// </summary>
        /// <param name="produto"></param>
        public void Editar(Produto produto)
        {
            var objProduto = db.Produtos.Find(produto.Id);
            objProduto.Nome = produto.Nome;
            objProduto.DataValidade = produto.DataValidade;
            objProduto.QuantidadeDoItem = produto.QuantidadeDoItem;
            objProduto.Compra = produto.Compra;
            db.SaveChanges();
        }




        /// <summary>
        /// Metodo para excluir o produto
        /// </summary>
        /// <param name="Id"></param>
        public void Deletar(int Id)
        {
            var objProduto = db.Produtos.Find(Id);
            db.Produtos.Remove(objProduto);
            db.SaveChanges();
        }


        /// <summary>
        /// Metodo de Validação do Campos obrigatorios.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public bool IsValidacao(Produto domain)
        {

            if (!String.IsNullOrEmpty(domain.Marca))
            {
                return true;
            }

            if (!String.IsNullOrEmpty(domain.Nome))
            {
                return true;
            }

            if (domain.QuantidadeDoItem > 0)
            {
                return true;
            }

            return false;
        }
    }
}
