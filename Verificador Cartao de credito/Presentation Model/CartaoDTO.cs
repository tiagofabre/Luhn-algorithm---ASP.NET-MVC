using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verificador_Cartao_de_credito.Presentation_Model
{
    public class CartaoDTO
    {
        public int id;
        //bandeira do cartão de crédito
        public string bandeira { get; set; }
        //numero do cartao de crédito
        public string numero { get; set; }
        //validade do cartao de crédito
        public string validade { get; set; }
        //codigo de verificação do cartão localizado na parte trazeira
        public string verificador { get; set; }
        //diz se o cartao e valido ou nao
        public bool valido { get; set; }
    }
}
