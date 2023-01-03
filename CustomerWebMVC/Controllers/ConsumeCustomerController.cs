using CustomerWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomerWebMVC.Controllers
{
    public class ConsumeCustomerController : Controller
    {
        public object JsonConvert { get; private set; }

        public async Task<ActionResult> Index()
        {
            HttpClient httpClient = new HttpClient(); 
            httpClient.BaseAddress = new Uri("https://localhost:44307/");
            httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync("api/customer");
            var jsonString = await response.Content.ReadAsStringAsync();
            //var objData = Newtonsoft.JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonString); 
            
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomModel>>(jsonString);
            
            List<CustomModel> listmodel = new List<CustomModel>();
            foreach(var cust in result)
            {
                CustomModel customModel = new CustomModel();
                customModel.Id = cust.Id;
                customModel.CustomerName = cust.CustomerName;
                customModel.CustomAge = cust.CustomAge;
                customModel.CustomerAddress = cust.CustomerAddress;
                customModel.CustomerPhone = cust.CustomerPhone;

                listmodel.Add(customModel);
            }

            return View(listmodel);
        }
    }
}
