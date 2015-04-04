using Verificador_Cartao_de_credito.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Verificador_Cartao_de_credito.Utils;
using Aplicacao.Enumeradores;

namespace Verificador_Cartao_de_credito.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CartaoDTO());
        }

        [HttpPost]
        public ActionResult Index(CartaoDTO cartao)
        {
            return View(cartao);
        }

        [HttpPost]
        public ActionResult ValidaCartao(CartaoDTO data)
        {
            ValidadorCartao val = new ValidadorCartao();
            CartaoValido valido = new CartaoValido();

            valido = val.Validar(data);

            CartaoDTO cartaoDTO = new CartaoDTO();
            cartaoDTO.numero = valido.numero;
            cartaoDTO.valido = valido.valido;
            cartaoDTO.bandeira = valido.bandeira.ToString();

            return View("Index", cartaoDTO);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicação de validação de Cartão de credito utilizando o algoritimo Luhn";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Meus dados para contato";

            return View();
        }
    }
}