using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fp_web_aula_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace fp_web_aula_1.Controllers
{
    public class TimesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Time time)
        {
            //Salvar no banco

            return View();
        }
    }
}