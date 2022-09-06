using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)

        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag()
        {
            var dao = new CategoryProductDao();
            //ViewBag.CategoriID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
            List<SelectListItem> CList = new List<SelectListItem>();
            foreach (var item in dao.ListAll())
            {
                CList.Add(new SelectListItem { Text = item.Name.ToString(), Value = item.Name.ToString() });
            }
            ViewBag.CategoriID = CList;
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                long id = dao.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
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
            var dao = new ProductDao();
            var product = dao.GetByID(id);
            SetViewBag();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                bool result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
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
            new ProductDao().Delete(id);
            return RedirectToAction("Product");
        }
        [HttpGet]
        public JsonResult ChangeStatus(int id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
      
    }
}