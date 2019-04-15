using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoletoNet;

namespace BoletoTeste.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GerarBoleto()
        {
            Cedente cedente = new Cedente("00.000.000/0000-00", "Cedente da Silva Sauro", "2269", "130000946");
            cedente.Codigo = "1795082";

            Sacado sacado = new Sacado("000.000.000-00", "Sacado de Tal");
            sacado.Endereco = new Endereco()
            {
                End = "SSS 154 Bloco J Casa 23",
                Bairro = "Testando",
                Cidade = "Testelândia",
                CEP = "70000000",
                UF = "DF"
            };

            Boleto boleto = new Boleto(DateTime.Now, 0.20m, "101", "566612457800", cedente);
            boleto.NumeroDocumento = "0282033";
            boleto.Sacado = sacado;

            Instrucao_Santander instrucaoSantander = new Instrucao_Santander();
            boleto.Instrucoes.Add(instrucaoSantander);

            EspecieDocumento_Santander especieSantander = new EspecieDocumento_Santander("17");
            boleto.EspecieDocumento = especieSantander;

            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 341;
            boletoBancario.Boleto = boleto;
            boletoBancario.MostrarCodigoCarteira = true;
            boletoBancario.Boleto.Valida();
            boletoBancario.MostrarComprovanteEntrega = true;

            byte[] pdf = boletoBancario.MontaBytesPDF();
            return File(pdf, "application/pdf");
        }
    }
}