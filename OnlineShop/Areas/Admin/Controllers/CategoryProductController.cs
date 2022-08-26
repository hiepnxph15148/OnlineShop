using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryProductController : Controller
    {
        // GET: Admin/CategoryProduct
        //public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        //{
        //    var dao = new CategoryProductDao();
        //    var model = dao.ListAllPagingcate(searchString, page, pageSize);
        //    ViewBag.SearchString = searchString;
        //    return View(model);
        //}
        //[HttpGet]
        //public ActionResult Create()

        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(ProductCategory productCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new CategoryDao();

        //        long id = dao.Insert(productCategory);
        //        if (id > 0)
        //        {
        //            return RedirectToAction("Index", "Category");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm danh mục  thành công");

        //        }
        //    }
        //    return View("Index");

        //}
        //public ActionResult Edit(int id)
        //{
        //    var category = new CategoryDao().ViewDetailcate(id);
        //    return View(category);
        //}
        //[HttpPost]
        //public ActionResult Edit(ProductCategory productCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new CategoryProductDao();
        //        bool result = dao.Updatecate(productCategory);
        //        if (result)
        //        {
        //            return RedirectToAction("Index", "User");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Cập nhật cate thành công");

        //        }
        //    }
        //    return View("Index");

        //}
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new CategoryProductDao().Deletecate(id);
        //    return RedirectToAction("Category");
        //}
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)

        {
            var dao = new CategoryProductDao();
            var model = dao.ListAllPagingcate(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new CategoryProductDao();
            //ViewBag.CategoriID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
            List<SelectListItem> CList = new List<SelectListItem>();
            foreach (var item in dao.ListAll())
            {
                CList.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Name.ToString()
                });
            }
            ViewBag.CategoriID = CList;
        }
        [HttpPost]
        public ActionResult Create(ProductCategory Product)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryProductDao();

                long id = dao.Insert(Product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thành công");

                }
            }
            SetViewBag();
            return View();

        }


        public ActionResult Edit(int id)
        {
            var dao = new CategoryProductDao();
            var product = dao.GetByID(id);
            SetViewBag();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryProductDao();
                bool result = dao.Updatecate(model);
                if (result)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Content thành công");

                }
            }
            SetViewBag();
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryProductDao().Deletecate(id);
            return RedirectToAction("Content");
        }
    }
}