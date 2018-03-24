using fp_web_aula_1.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace fp_web_aula_1.Controllers
{
    public class TimeController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Time time)
        {
            //TODO: salvar
            return View();
        }
    }
}
