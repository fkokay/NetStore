using Microsoft.AspNetCore.Mvc;

namespace NetStore.ERP.WebApi.Controllers
{
    public class NetsisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
