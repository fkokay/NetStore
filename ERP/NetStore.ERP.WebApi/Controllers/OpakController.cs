using Microsoft.AspNetCore.Mvc;

namespace NetStore.ERP.WebApi.Controllers
{
    public class OpakController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
