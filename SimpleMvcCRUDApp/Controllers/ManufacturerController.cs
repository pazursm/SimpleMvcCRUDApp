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
    public class ManufacturerController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Manufacturers = _unitOfWork.ManufacturerRepository.GetAll();
            return View("Index", model);
        }
    }
}