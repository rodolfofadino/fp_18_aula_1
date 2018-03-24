using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fp_web_aula_1.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
          int total, bool noticiasUrgentes)
        {
            string view = "noticias";

            if (total > 3 && noticiasUrgentes == true)
            {
                view = "noticiasurgentes";
            }

            var items = GetItems(total);
            return View(view, items);
        }

        private IEnumerable<Noticia> GetItems(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = 1, Titulo = $"Noticia {i}", Link = $"http://{i}" };
            }
        }
    }

    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }

    }
}

