using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            ViewBag.ContentDetail = new ContentDao().ViewDetailContent(id);
            return View();
        }
    }
}