using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()     
        {
            var contentDao = new ContentDao();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(4);
            ViewBag.ListFeatureProduct = productDao.ListFeatureProduct(4);
            ViewBag.ListFeatureContent = contentDao.ListFeatureContent(4);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}