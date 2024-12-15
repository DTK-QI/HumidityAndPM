using Microsoft.AspNetCore.Mvc;
using Hangfire;
using HumidityAndPM.Function;

namespace HumidityAndPM.Controllers
{
    public class weatherController : Controller
    {
        [HttpGet]
        public void Get()
        {
            var HumidityAndPMData = new CallHumidityAndPMData();
            //每一小時執行一次
            BackgroundJob.Schedule(() => HumidityAndPMData.SaveHumidityAndPMData(), TimeSpan.FromHours(1));

        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
