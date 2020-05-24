using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleMvcCRUDApp.Models;
using System.Collections.Generic;
using System.IO;

namespace SimpleMvcCRUDApp.Controllers
{
    public class JsonProductsController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Product> productList = GetAllFromFile("WarehouseWM.json");
            return View(productList);
        }

        //GET
        public IEnumerable<Product> GetAllFromFile(string filePath)
        {
            IEnumerable<Product> productList;
            try
            {
                using (StreamReader jsonStreamReader = new StreamReader(filePath))
                {
                    var rawData = jsonStreamReader.ReadToEnd();
                    productList = JsonConvert.DeserializeObject<List<Product>>(rawData);
                }
            }
            catch
            {
                return null;
            }
            return productList;
        }
    }
}