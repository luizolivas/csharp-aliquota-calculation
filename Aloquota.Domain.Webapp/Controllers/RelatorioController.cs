using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Domain.Webapp.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
