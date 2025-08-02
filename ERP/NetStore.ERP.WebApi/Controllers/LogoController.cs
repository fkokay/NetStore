using Microsoft.AspNetCore.Mvc;

namespace NetStore.ERP.WebApi.Controllers
{
    public class LogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
