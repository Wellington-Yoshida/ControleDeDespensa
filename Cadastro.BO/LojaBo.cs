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
    public class LojaBo : ILojaBo
    {

        #region Propriedade
        Contexto db = new Contexto();
        #endregion


        /// <summary>
        /// Metodo para add Lojas
        /// </summary>
        /// <param name="loja"></param>
        public void Adicionar(Loja loja)
        {
            if (IsValidacao(loja))
            {
                 db.Lojas.Add(loja);
                 db.SaveChanges();
            }
        }



        /// <summary>
        /// Metodo para Editar Lojas
        /// </summary>
        /// <param name="loja"></param>
        public void Editar(Loja loja)
        {
            var objLoja = db.Lojas.Find(loja.Id);
            objLoja.Endereco = loja.Endereco;
            objLoja.Nome = loja.Endereco;
            db.SaveChanges();
        }


        /// <summary>
        /// Metodo para Deletar Lojas
        /// </summary>
        /// <param name="Id"></param>
        public void Deletar(int Id)
        {
            var objLoja = db.Lojas.Find(Id);
            db.Lojas.Remove(objLoja);
            db.SaveChanges();
        }


        /// <summary>
        /// Metodo para validar os campos
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public bool IsValidacao(Loja domain)
        {
            if (!String.IsNullOrEmpty(domain.Endereco))
            {
                return true;
            }

            if (!String.IsNullOrEmpty(domain.Nome))
            {
                return true;
            }

            return false;
        }
    }
}
