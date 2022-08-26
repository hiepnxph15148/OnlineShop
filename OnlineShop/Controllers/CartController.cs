using Model.Dao;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.EF;
using System.Configuration;
using System.IO;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSeesion = "CartSeesion";
        // GET: Cart
        public ActionResult Index()
        {
           
            var cart = Session[CartSeesion];
            var list = new List<CartItem>();
          
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ViewBag.Cart = list;
                return View();
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSeesion];

            foreach(var item in sessionCart)
            {
               var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if(jsonItem != null)
                {
                    item.Quantyli = jsonItem.Quantyli;
                }
            }
            Session[CartSeesion] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSeesion] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSeesion];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSeesion] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem (long productId,int quantyli)
        {
            var product = new ProductDao().ViewDetail2(productId);
            var cart = Session[CartSeesion];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantyli += quantyli;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product; 
                    item.Quantyli = quantyli;
                    list.Add(item);
                }
                Session[CartSeesion] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product; 
                item.Quantyli = quantyli;
                var list = new List<CartItem>();
                list.Add(item);
                // gán vào session
                Session[CartSeesion] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSeesion];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ViewBag.Cart = list;
            return View();
        }
        [HttpPost]
        public ActionResult Payment(string shipName,string mobile,string address, string email)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipAndress = address;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSeesion];
                var detailDao = new OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantyli = item.Quantyli;
                    detailDao.Insert(orderDetail);

                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantyli);
                }
            }
            catch (Exception)
            {
                //ghi-log
                return Redirect("/loi-thanh-thoan");
            }
         
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}