using BookStoreWebApp.DataAccess.Data;
using BookStoreWebApp.DataAccess.Repository.IRepository;
using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BookStoreWebApp.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: CategoriesController
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoriesList = _unitOfWork.Category.GetAll();

            return View(objCategoriesList);
        }

        // GET: CategoriesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: CategoriesController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Edited Successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: CategoriesController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfuly";
            return RedirectToAction("Index");
        }
    }
}
