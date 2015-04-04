using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacao.Enumeradores
{
    public class BandeirasCartao
    {
        /// <summary>
        /// Enumerador de bandeiras de cartao de credito
        /// </summary>
        public enum Bandeiras { AMEX, Discover, MasterCard, Visa, Desconhecido };

        /// <summary>
        /// REcebe uma string e tenta transforma em um enumerador de bandeiras de cartao de credito
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int StringToBandeiras(string data)
        {
            data = data.ToLower();
            Bandeiras ret = Bandeiras.Desconhecido;

            switch (data)
            {
                case "amex":
                    ret = Bandeiras.AMEX;
                    break;
                case "discover":
                    ret = Bandeiras.Discover;
                    break;
                case "mastercard":
                    ret = Bandeiras.MasterCard;
                    break;
                case "visa":
                    ret = Bandeiras.Visa;
                    break;
                default:
                    ret = Bandeiras.Desconhecido;
                    break;
            }

            return (int)ret;
        }
    }
}