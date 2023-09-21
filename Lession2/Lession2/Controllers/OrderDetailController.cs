using DB.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace Lession2.Controllers
{
    public class OrderDetailController : Controller
    {
        public ActionResult Index(int? search)
        {
            List<Order_Detail> listOd = new List<Order_Detail>();
            listOd = DB.DbAccess.SqlDbHelper.GetOrderDetails();
            if (search != null)
            {
                listOd = DB.DbAccess.SqlDbHelper.searchOrderDetailByID(search);
            }
            return View(listOd);
        }
        public ActionResult Create(int? id)
        {
            if(id != null)
            {
                ViewBag.SelectedProductID = id;
            }
            var od = new Order_Detail();
            List<DB.DbAccess.Order> orders = DB.DbAccess.SqlDbHelper.GetOrders();
            List<DB.DbAccess.Product> pros = DB.DbAccess.SqlDbHelper.GetProducts();
            ViewBag.Orders = new SelectList(orders, "OrderId", "OrderId", od.OrderId);
            ViewBag.Products = new SelectList(pros, "ProductID", "Name", od.ProductId);

            foreach (var item in pros)
            {
                if(item.ProductID == id)
                {
                    ViewBag.PricePro = item.Price;
                }
            }
            return View(od);
        }
    
        [HttpPost]
        public ActionResult Create(int orderId, int productId, int quantity, int price)
        {
            DB.DbAccess.SqlDbHelper.CreateOrderDetail(orderId, productId, quantity, price);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var od = new Order_Detail();
            od = DB.DbAccess.SqlDbHelper.GetOrderDetailById(id);
            return View(od);
        }
    }
}