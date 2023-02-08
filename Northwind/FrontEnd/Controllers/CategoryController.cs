using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CategoryController : Controller
    {
        CategoryHelper categoryHelper;

        // GET: CategoryController
        public ActionResult Index()
        {

            categoryHelper = new CategoryHelper();
            List<CategoryViewModel> lista = categoryHelper.GetAll();

            return View(lista);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryViewModel category = categoryHelper.Get(id);    

            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            try
            {
                categoryHelper = new CategoryHelper();
                 category = categoryHelper.Create(category);

                return RedirectToAction("Details", new {id=category.CategoryID});
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryViewModel category = categoryHelper.Get(id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            try
            {
                CategoryHelper categoryHelper = new CategoryHelper();
                category=categoryHelper.Edit(category);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryViewModel category = categoryHelper.Get(id);

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel category)
        {
            try
            {
                categoryHelper = new CategoryHelper();
                categoryHelper.Delete(category.CategoryID);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
