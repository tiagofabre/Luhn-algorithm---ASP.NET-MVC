using Aplicacao.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Verificador_Cartao_de_credito.Presentation_Model;

namespace Verificador_Cartao_de_credito.Utils
{
    public class ValidadorCartao
    {
        CartaoValido cartao = new CartaoValido();

        public CartaoValido Validar(CartaoDTO data)
        {
            cartao.valido = true;

            //trata a string para retornar para a view
            cartao.numero = TrataString(data.numero);
            ////descobre a bandeira do cartao
            cartao.bandeira = ValidaInicio(data.numero);
            //se o cartao nao e valido e pq o numero de caracteres dele esta diferento do normal
            if (cartao.valido)
                //retorna se o numero é valido ou invalido
                cartao.valido = ValidaNumero(data.numero); ;

            return cartao;
        }

        public bool ValidaNumero(string data)
        {

            //Luhn algorithm

            //tenta remover qualquer tipo de problema entre os numeros removendo caracteres
            data = TrataString(data);

            //inverte os caracters
            string inverseN = ReverteString(data);
            //dobra os numeros
            string doubled = DoubleAlternate(inverseN);
            //soma todos os numeros
            int sum = SumEachElement(doubled);
            //verifica se e divisor de 10
            bool multByTen = IsMultipleOfTen(sum);

            return multByTen;
        }

        public BandeirasCartao.Bandeiras ValidaInicio(string numeros)
        {
            BandeirasCartao.Bandeiras ret = BandeirasCartao.Bandeiras.Desconhecido;

            //se e 34 ou 37
            if (numeros.StartsWith("34") || numeros.StartsWith("37"))
            {
                ret = BandeirasCartao.Bandeiras.AMEX;
                //se o comprimento da string e de 15
                if (numeros.Length != 15)
                    cartao.valido = false;
            }


            //se começa com 6011
            if (numeros.StartsWith("6011"))
            {
                ret = BandeirasCartao.Bandeiras.Discover;
                //se o comprimento da string e de 16
                if (numeros.Length != 16)
                    cartao.valido = false;
            }

            //se esta entre 51 e 55 (51 e 55 contam)
            if (int.Parse(numeros.ToCharArray()[0].ToString()) == 5)
            {
                if (numeros.Length > 1)
                {
                    int segundo = int.Parse(numeros.ToCharArray()[1].ToString());
                    if (segundo >= 1 && segundo <= 5)
                    {
                        ret = BandeirasCartao.Bandeiras.MasterCard;
                        //se o comprimento da string e de 16
                        if (numeros.Length != 16)
                            cartao.valido = false;
                    }
                }
            }

            //se começa com 4
            if (numeros.StartsWith("4"))
            {
                ret = BandeirasCartao.Bandeiras.Visa;
                //se o comprimento da string e de 13 ou 16
                if (numeros.Length != 13)
                {
                    if (numeros.Length != 16)
                    {
                        cartao.valido = false;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// inverte as posições da string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ReverteString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// iniciando da posição zero, dobra o valor do numero alternadamenete e 
        /// se esse numero exceder 10, soma a primeira casa do numero com a segunda
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DoubleAlternate(string numero)
        {
            int i = 1;
            int j = 0;
            char[] charArray = numero.ToCharArray();

            while (i < numero.Length)
            {
                //pega o numero que deve ser dobrado da string
                int num = int.Parse(numero[i].ToString());

                if (i % 2 != 0)
                {
                    j++;
                    //se o dobro do numero for maior que 10, soma os 2 numeros ex: 16 = 1+7 = 7
                    if (num * 2 >= 10)
                    {
                        num = num * 2;
                        num = num - 9;

                        num = int.Parse(num.ToString());
                    }
                    else
                    {
                        num = num * 2;
                    }
                }

                charArray[i] = char.Parse((num).ToString());

                i++;
            }

            return new string(charArray);
        }

        /// <summary>
        /// soma cada elemento da string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int SumEachElement(string str)
        {
            int soma = 0;

            foreach (char i in str)
            {
                soma += int.Parse(i.ToString());
            }

            return soma;
        }

        /// <summary>
        /// verifica se o numero e multiplo de 10
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsMultipleOfTen(int num)
        {
            return num % 10 == 0 ? true : false;
        }

        /// <summary>
        /// remove espaços e alguns caracteres que o usuario pode ter colocado entre os numeros
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string TrataString(string str)
        {
            str = str.Trim();
            str = str.Replace(" ", string.Empty);
            str = str.Replace("-", string.Empty);
            str = str.Replace(".", string.Empty);
            str = str.Replace(",", string.Empty);
            str = str.Replace("_", string.Empty);

            return str;
        }
    }

    public class CartaoValido
    {
        public BandeirasCartao.Bandeiras bandeira { get; set; }
        public bool valido { get; set; }
        public string numero { get; set; }
    }
}