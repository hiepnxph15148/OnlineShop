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
            var dao = new ContentDao();
            var model = dao.ListAllPagingContent(searchString, page, pageSize);
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
            var dao = new CategoryDao();
            //ViewBag.CategoriID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
            List<SelectListItem> CList = new List<SelectListItem>();
            foreach (var item in dao.ListAll())
            {
                CList.Add(new SelectListItem { Text = item.Name.ToString(), Value = item.Name.ToString() });
            }
            ViewBag.CategoriID = CList;
        }
        [HttpPost]
        public ActionResult Create(Content Content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();

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
            SetViewBag();
            return View();

            }


        public ActionResult Edit(int id)
        {
            var dao = new ContentDao();
            var content = dao.GetByID(id);
            SetViewBag();
            return View(content);
        }
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                bool result = dao.UpdateContent(model);
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
            new ContentDao().DeleteContent(id);
            return RedirectToAction("Content");
        }

    }
}