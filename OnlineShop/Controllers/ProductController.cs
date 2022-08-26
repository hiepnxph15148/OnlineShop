using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowAll(string searchString, int page = 1, int pageSize = 8 )

        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Category(int id)
        {
            ViewBag.Category2 = new CategoryProductDao().ViewDetailcate(id);
            ViewBag.RelatedProducts2 = new ProductDao().ListFeatureProducts2(id);
            return View();
        }
        [OutputCache(CacheProfile = "Cache1DayForProduct")]
        public ActionResult Detail(long id)      
        {
            ViewBag.ProductDetail = new ProductDao().ViewDetail(id);
            ViewBag.Category = new CategoryProductDao().ViewDetailcate2(ViewBag.ProductDetail.CategoryID);
            ViewBag.RelatedProducts = new ProductDao().ListFeatureProducts(id,4);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new CategoryProductDao().ListAll();
            
            return PartialView(model);
        }
        
    }
}