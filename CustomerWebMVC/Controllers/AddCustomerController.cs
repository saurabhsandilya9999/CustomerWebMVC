using CustomerWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebMVC.Controllers
{
    public class AddCustomerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CustomModel custom)
        {
            var customer = new CustomModel()
            {
                CustomerName = custom.CustomerName,
                CustomAge = custom.CustomAge,
                CustomerAddress = custom.CustomerAddress,
                CustomerPhone = custom.CustomerPhone
            };
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44307/");
            httpClient.DefaultRequestHeaders.Clear();
            StringContent content = new StringContent(JsonConvert.SerializeObject(custom), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("api/customer", content);
            //HttpResponseMessage response = await httpClient.PostAsJsonAsync(httpClient.BaseAddress, customer);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(customer);

        }
    }
}
