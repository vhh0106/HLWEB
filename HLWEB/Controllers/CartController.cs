using HLWEB.DAO;
using HLWEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HLWEB.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";
        [HttpGet]
        public ActionResult CartIndex()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long ProductId, int Quantity)
        {
            var Product = new ProductDAO().ViewDetail(ProductId);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x=>x.Product.id == ProductId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.id == ProductId)
                        {
                            item.Quantity += Quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = Product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = Product;
                item.Quantity = Quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("CartIndex");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var SessionCart = (List<CartItem>)Session[CartSession];
            foreach(var item in SessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.id == item.Product.id);
                if(jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = SessionCart;
            return Json(new
            {
                status = true
            });
        }
         
        public JsonResult Delete()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteOne(long id)
        {
            var SessionCart = (List<CartItem>)Session[CartSession];
            SessionCart.RemoveAll(x => x.Product.id == id);
            Session[CartSession] = SessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Pay()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Pay(string ShipName,string ShipMobile, string ShipAddress, string ShipEmail)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipName = ShipName;
            order.ShipMobile = ShipMobile;
            order.ShipAddress = ShipAddress;
            order.ShipEmail = ShipEmail;

            try
            {
                var id = new OrderDAO().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var DetailDAO = new OrderDetailDAO();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.id;
                    orderDetail.OrderID = id;
                    orderDetail.ID = id;
                    orderDetail.Price = item.Product.price;
                    orderDetail.Quantity = item.Quantity;
                    DetailDAO.Insert(orderDetail);

                    total += (item.Product.price.GetValueOrDefault(0) * item.Quantity);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/home/neworder.html"));

                content = content.Replace("{{CustomerName}}", ShipName);
                content = content.Replace("{{Phone}}", ShipMobile);
                content = content.Replace("{{Email}}", ShipEmail);
                content = content.Replace("{{Address}}", ShipAddress);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new Maill().SendMail(ShipEmail, "Đơn hàng mới từ HLWEB", content);

                new Maill().SendMail(toEmail, "Đơn hàng mới từ HLWEB", content);

            }
            catch(Exception e)
            {
                return Redirect("/loi");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Done()
        {
            return View();
        }

        public ActionResult ER()
        {
            return View();
        }
    }
}