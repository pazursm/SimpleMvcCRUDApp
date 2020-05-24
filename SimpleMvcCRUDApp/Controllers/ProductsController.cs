using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimpleMvcCRUDApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMvcCRUDApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Product Product { get; set; }


        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.Products.ToListAsync());
        }

        public IActionResult IndexFromJson()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Product = new Product();
            if (id == null)
            {
                //create
                return View(Product);
            }
            Product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Product.Id == 0)
                {
                    _db.Products.Add(Product);
                }
                else
                {
                    _db.Products.Update(Product);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _db.Products.FindAsync(id);
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = GetAllFromFile("WarehouseWM.json") });
        }

        public IEnumerable<Product> GetAllFromFile(string filePath)
        {
            IEnumerable<Product> productList;

            if(!System.IO.File.Exists(filePath))
            {
                return new List<Product>();
            }
            using (StreamReader jsonStreamReader = new StreamReader(filePath))
            {
                var rawData = jsonStreamReader.ReadToEnd();
                productList = JsonConvert.DeserializeObject<List<Product>>(rawData);
            }
            return productList;
        }
    }
}
