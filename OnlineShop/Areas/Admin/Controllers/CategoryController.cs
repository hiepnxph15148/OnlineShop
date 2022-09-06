using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPagingcate(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Creates()

        {
            return View();
        }
        [HttpPost]
        public ActionResult Creates(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
 
                long id = dao.Insert(category);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục  thành công");

                }
            }
            return View("Index");

        }
        public ActionResult Edit(int id)
        {
            var category = new CategoryDao().ViewDetailcate(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                bool result = dao.Updatecate(category);
                if (result)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thành công");

                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryDao().Deletecate(id);
            return RedirectToAction("Category");
        }
    }
}