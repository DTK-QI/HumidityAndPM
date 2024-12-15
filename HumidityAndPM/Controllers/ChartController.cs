using Microsoft.AspNetCore.Mvc;

namespace HumidityAndPM.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Air()
        {
            return View();
        }
        public IActionResult Weather()
        {
            return View();
        }
    }
}
