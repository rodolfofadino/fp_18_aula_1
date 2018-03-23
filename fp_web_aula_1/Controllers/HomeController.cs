using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace fp_web_aula_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Mensagem = "Hello";
            ViewData["Mensagem2"] = "Hello2";

            return View();
        }

        //public string Index()
        //{
        //    return "Hello Fiap";
        //}
    }
}
