using Microsoft.AspNetCore.Mvc;
using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Classes;
using SimpleMvcCRUDApp.Repositories.Interfaces;
using System.Dynamic;
using System.Threading.Tasks;

namespace SimpleMvcCRUDApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }


        [BindProperty]
        public Product Product { get; set; }

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Products = _unitOfWork.ProductRepository.GetAllProducts();
            return View("Index", model);
        }

        public IActionResult Upsert(int? id)
        {
            Product = new Product();
            if (id == null)
            {
                //create
                return View(Product);
            }
            Product = _unitOfWork.ProductRepository.GetById((int)id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Product.Id == 0)
                {
                    _unitOfWork.ProductRepository.Add(Product);
                }
                else
                {
                    _unitOfWork.ProductRepository.Update(Product);
                }
                await _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(Product);
        }
    }
}