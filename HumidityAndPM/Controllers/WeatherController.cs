using Microsoft.AspNetCore.Mvc;
using Hangfire;

namespace HumidityAndPM.Controllers
{
    public class weatherController : Controller
    {
        //[HttpGet]
        //public void Get()
        //{
        //    //單次10秒後執行
        //    BackgroundJob.Schedule(() => Pine, TimeSpan.FromHours(1));

        //}


        public IActionResult Index()
        {
            return View();
        }

    }
}
