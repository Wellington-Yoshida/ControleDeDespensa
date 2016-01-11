using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cadastro.BO;
using Cadastro.Dominio;

namespace ByRupee.Test
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Exemplo de teste unit
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var valor1 = 10;
            var valor2 = 5;
            var result = valor1 + valor2;
            Assert.AreEqual(15, result);
        }


        /// <summary>
        /// Testando o campo Nome da Compra
        /// </summary>
        [TestMethod]
        public void DeveCriarNovaCompra()
        {
            var compra = new Compra();
            var nome = compra.Nome;
            var result = compra.Nome;
            Assert.AreEqual(nome, result);
            Assert.IsNotNull(compra);//Conferindo se o valor não é null.
        }
    }
}
