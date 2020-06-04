using Microsoft.AspNetCore.Mvc;
using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Classes;
using SimpleMvcCRUDApp.Repositories.Interfaces;
using System.Dynamic;
using System.Threading.Tasks;

namespace SimpleMvcCRUDApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        [BindProperty]
        public Category Category { get; set; }

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Categories = _unitOfWork.CategoryRepository.GetAll();
            return View("Index", model);
        }

        public IActionResult Upsert(int? id)
        {
            Category = new Category();
            if (id == null)
            {
                //create
                return View(Category);
            }
            Category = _unitOfWork.CategoryRepository.GetById((int)id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Category.Id == 0)
                {
                    _unitOfWork.CategoryRepository.Add(Category);
                }
                else
                {
                    _unitOfWork.CategoryRepository.Update(Category);
                }
                await _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(Category);
        }
    }
}