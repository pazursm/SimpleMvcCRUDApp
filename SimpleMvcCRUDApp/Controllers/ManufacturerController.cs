using Microsoft.AspNetCore.Mvc;
using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Classes;
using SimpleMvcCRUDApp.Repositories.Interfaces;
using System.Dynamic;
using System.Threading.Tasks;

namespace SimpleMvcCRUDApp.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; }

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Manufacturers = _unitOfWork.ManufacturerRepository.GetAll();
            return View("Index", model);
        }

        public IActionResult Upsert(int? id)
        {
            Manufacturer = new Manufacturer();
            if (id == null)
            {
                //create
                return View(Manufacturer);
            }
            Manufacturer = _unitOfWork.ManufacturerRepository.GetById((int)id);
            if (Manufacturer == null)
            {
                return NotFound();
            }
            return View(Manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Manufacturer.Id == 0)
                {
                    _unitOfWork.ManufacturerRepository.Add(Manufacturer);
                }
                else
                {
                    _unitOfWork.ManufacturerRepository.Update(Manufacturer);
                }
                await _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(Manufacturer);
        }
    }
}