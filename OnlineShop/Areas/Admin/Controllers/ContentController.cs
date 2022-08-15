using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using Model.EF;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        
        {
            var dao = new UserDao();
            var model = dao.ListAllPagingContent(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Content Content)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                long id = dao.Insert(Content);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thành công");

                }
            }
            return View("Index");

        }
        public ActionResult Edit(int id)
        {
            var content = new UserDao().ViewDetailContent(id);
            return View(content);
        }
        [HttpPost]
        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                bool result = dao.UpdateContent(content);
                if (result)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Content thành công");

                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().DeleteContent(id);
            return RedirectToAction("Content");
        }

    }
}