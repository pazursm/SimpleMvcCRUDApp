using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcCRUDApp.Repositories.Classes;
using SimpleMvcCRUDApp.Repositories.Interfaces;

namespace SimpleMvcCRUDApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Products = _unitOfWork.ProductRepository.GetAllProducts();
            return View("Index", model);
        }

        public IActionResult Upsert(int id)
        {
            return View();
        }
    }
}