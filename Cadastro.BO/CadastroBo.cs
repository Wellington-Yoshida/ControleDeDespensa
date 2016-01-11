using Cadastro.Dominio;
using Cadastro.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.BO
{
    public class CadastroBo : ICadastroBo
    {
        #region Propriedade
        private Contexto db = new Contexto();
        #endregion
        
        /// <summary>
        /// Metodo para adicionar compras
        /// </summary>
        /// <param name="compra"></param>
        public void Adicionar(Compra compra)
        {
            if (IsValidacao(compra))
            {
                db.Compras.Add(compra);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Metodo para obter quantidade e Nome das Compras para o gráfico.
        /// </summary>
        /// <returns></returns>
        public List<GraficoCompra> ObterCompra()
        {
            var resultado = from i in db.Compras
                            select new GraficoCompra { Compra = i.Nome, QuantidadeItem = i.Quantidade };

            return resultado.ToList();
        }


        /// <summary>
        /// Metodo para Editar a compra
        /// </summary>
        /// <param name="compra"></param>
        public void Editar(Compra compra)
        {
            var objCompra = db.Compras.Find(compra.Id);
            objCompra.Nome = compra.Nome;
            objCompra.DataCompra = compra.DataCompra;
            objCompra.Quantidade = compra.Quantidade;
            objCompra.Loja = compra.Loja;
            db.SaveChanges();
        }


        /// <summary>
        /// Metodo para excluir a compra
        /// </summary>
        /// <param name="Id"></param>
        public void Deletar(int Id)
        {
            var objCompra = db.Compras.Find(Id);
            db.Compras.Remove(objCompra);
            db.SaveChanges();
        }


        /// <summary>
        /// Metodo de Validação do Campos obrigatorios.
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public bool IsValidacao(Compra domain)
        {
            if (!String.IsNullOrEmpty(domain.Nome))
            {
                return true;
            }

            if (domain.DataCompra <= DateTime.Now)
            {
                return true;
            }

            if (domain.Quantidade > 0)
            {
                return true;
            }


            return false;
        }

    }
}
