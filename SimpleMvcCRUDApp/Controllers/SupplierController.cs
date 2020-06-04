using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcCRUDApp.Repositories.Classes;
using SimpleMvcCRUDApp.Repositories.Interfaces;
using System.Dynamic;
using SimpleMvcCRUDApp.Data.Models;

namespace SimpleMvcCRUDApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Suppliers = _unitOfWork.SupplierRepository.GetAll();
            return View("Index", model);
        }

        public IActionResult Upsert(int? id)
        {
            Supplier = new Supplier();
            if (id == null)
            {
                //create
                return View(Supplier);
            }
            Supplier = _unitOfWork.SupplierRepository.GetById((int)id);
            if (Supplier == null)
            {
                return NotFound();
            }
            return View(Supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Supplier.Id == 0)
                {
                    _unitOfWork.SupplierRepository.Add(Supplier);
                }
                else
                {
                    _unitOfWork.SupplierRepository.Update(Supplier);
                }
                await _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(Supplier);
        }
    }
}