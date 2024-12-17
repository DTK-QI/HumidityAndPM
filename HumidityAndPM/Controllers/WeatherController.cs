using Microsoft.AspNetCore.Mvc;
using Hangfire;
using HumidityAndPM.Function;
using HumidityAndPMDataConnect.Models;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace HumidityAndPM.Controllers
{
    public class weatherController : Controller
    {
        private WeatherContext context;
        public weatherController()
        {
            context = new WeatherContext();
        }

        //[HttpGet]
        //public string GetPM25()
        //{
        //    var values = context.WeatherValues.Where(x=>x.ValueId == "33").Select(x=> new { value = x.Value, time = x.RecordTime }).ToList();
        //    var json = JsonSerializer.Serialize(values);
        //    return json;
        //}
        //[HttpGet]
        //public string GetTemperature()
        //{
        //    var values = context.WeatherValues.Where(x => x.ValueId == "14").Select(x => new { value = x.Value, time = x.RecordTime }).ToList();
        //    var json = JsonSerializer.Serialize(values);
        //    return json;
        //}
        //[HttpGet]
        //public string GetHumidity()
        //{
        //    var values = context.WeatherValues.Where(x => x.ValueId == "38").Select(x => new { value = x.Value, time = x.RecordTime }).ToList();
        //    var json = JsonSerializer.Serialize(values);
        //    return json;
        //}
        [HttpGet]
        public string GetData(string label)
        {
            var values = context.WeatherValues.Where(x => x.ValueId == label).Select(x => new {id = x.WeatherIndex, value = x.Value, time = x.RecordTime }).ToList();
            var json = JsonSerializer.Serialize(values);
            return json;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string GetDataValue(int id)
        {
            var value = context.WeatherValues.Where(x => x.WeatherIndex == id).FirstOrDefault();
            var json = JsonSerializer.Serialize(value);
            return json;
        }


        [HttpPost]
        public string updateValue([FromBody]  WeatherValue value)
        {
            var data = context.WeatherValues.Where(x => x.WeatherIndex == value.WeatherIndex).FirstOrDefault();
            data.Value = value.Value;
            context.SaveChanges();

            var values = context.WeatherValues.Where(x => x.ValueId == data.ValueId).Select(x => new { ValueId = x.ValueId, id = x.WeatherIndex, value = x.Value, time = x.RecordTime }).ToList();
            var json = JsonSerializer.Serialize(values);
            return json;
        }

        [HttpDelete]
        public string DeleteDataValue(int id)
        {
            var data = context.WeatherValues.Where(x => x.WeatherIndex == id).FirstOrDefault();
            if(data == null)
            {
                return "Error";
            }

            context.WeatherValues.Remove(data);
            context.SaveChanges();
            var values = context.WeatherValues.Where(x => x.ValueId == data.ValueId).Select(x => new { ValueId = x.ValueId, id = x.WeatherIndex, value = x.Value, time = x.RecordTime }).ToList();
            var json = JsonSerializer.Serialize(values);
            return json;
        }

    }
}
