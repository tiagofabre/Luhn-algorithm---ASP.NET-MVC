using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verificador_Cartao_de_credito.Utils;
using Aplicacao.Enumeradores;

namespace Verificador_Cartao_de_credito.Tests.Utils
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidaInicio()
        {
            ValidadorCartao validador = new ValidadorCartao();

            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("1"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("2"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("3"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Visa, validador.ValidaInicio("4"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("5"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("6"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("7"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("8"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("9"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("10"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Visa, validador.ValidaInicio("4408041234567893"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Visa, validador.ValidaInicio("4408041234567893"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.MasterCard, validador.ValidaInicio("5105105105105106"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.MasterCard, validador.ValidaInicio("5105105105105100"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("9111111111111111"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.AMEX, validador.ValidaInicio("378282246310005"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.AMEX, validador.ValidaInicio("378282246310005"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.AMEX, validador.ValidaInicio("34"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("33"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("32"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Discover, validador.ValidaInicio("6011"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("6012"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("6010"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.MasterCard, validador.ValidaInicio("51"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.MasterCard, validador.ValidaInicio("52"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.MasterCard, validador.ValidaInicio("53"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.MasterCard, validador.ValidaInicio("54"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.MasterCard, validador.ValidaInicio("55"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("56"));
            Assert.AreEqual(BandeirasCartao.Bandeiras.Desconhecido, validador.ValidaInicio("50"));
            
             
        }

        [TestMethod]
        public void ValidaCartoes()
        {
            ValidadorCartao validador = new ValidadorCartao();

            //Assert.AreEqual(true, validador.ValidaNumero("5105105105105100"));
            //Assert.AreEqual(true, validador.ValidaNumero("4408 0412 3456 7893"));
            //Assert.AreEqual(false, validador.ValidaNumero("4111111111111 "));
            //Assert.AreEqual(true, validador.ValidaNumero("4111111111111111 "));
            Assert.AreEqual(true, validador.ValidaNumero("378282246310005 "));
            Assert.AreEqual(true, validador.ValidaNumero("6011111111111117"));
            Assert.AreEqual(true, validador.ValidaNumero("5105105105105100 "));
            Assert.AreEqual(false, validador.ValidaNumero("5105105105105106 "));
            Assert.AreEqual(false, validador.ValidaNumero("9111111111111111 "));
        }
    }
}
