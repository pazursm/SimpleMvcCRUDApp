using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcCRUDApp.Repositories.Classes;
using SimpleMvcCRUDApp.Repositories.Interfaces;
using System.Dynamic;

namespace SimpleMvcCRUDApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Suppliers = _unitOfWork.SupplierRepository.GetAll();
            return View("Index", model);
        }
    }
}