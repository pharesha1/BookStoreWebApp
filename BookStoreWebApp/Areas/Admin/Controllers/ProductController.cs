using BookStoreWebApp.DataAccess.Data;
using BookStoreWebApp.DataAccess.Repository.IRepository;
using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace BookStoreWebApp.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: CategoriesController
        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypeList = _unitOfWork.CoverType.GetAll();

            return View(coverTypeList);
        }

        // GET: CategoriesController/Edit/5
        public IActionResult Upsert(int? id)
        {
            Product product = new();

            IEnumerable<SelectListItem> categoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            IEnumerable<SelectListItem> coverTypeList = _unitOfWork.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            if (id == null || id == 0)
            {
                ViewBag.CategoryList = categoryList;
                ViewBag.CoverTypeList = coverTypeList;

                return View(product);
            }
            else
            {

            }

            return View(product);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type Edited Successfuly";
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

            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

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

            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type Deleted Successfuly";
            return RedirectToAction("Index");
        }
    }
}
