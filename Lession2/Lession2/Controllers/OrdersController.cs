using DB.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lession2.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        // cái địa chỉ action của form  nãy viết sai, sai tôi viết như nào thế: action="Index" 
        //haha loi  not, mời ôr
        public ActionResult Index(string search)
        {
            List<Order> list = new List<Order>();
            list = DB.DbAccess.SqlDbHelper.GetOrders();
            if (!String.IsNullOrEmpty(search))
            {
                list = DB.DbAccess.SqlDbHelper.searchOrderByID(search);
            }
            return View(list);
        }
        // 2 cái Index search của tôi chỉ chạy đc 1 cái thôi , dù kết quả chạy đúng
        [HttpPost]
        public ActionResult Index(DateTime timeStart, DateTime timeEnd)
        {
            List<Order> lst = new List<Order>();
            lst = DB.DbAccess.SqlDbHelper.GetOrders();
            if (timeStart != timeEnd)
            {
                lst = DB.DbAccess.SqlDbHelper.searchOrderByTime(timeStart, timeEnd);
            }
            return View(lst);
        }
        public ActionResult Detail(int id)
        {
            List<Order_Detail> lstOd = new List<Order_Detail>();
            lstOd = DB.DbAccess.SqlDbHelper.DetailAllProductInOrderId(id);
            return View(lstOd);
        }
        public ActionResult Edit(int id)
        {
            Order ord = new Order();
            ord = DB.DbAccess.SqlDbHelper.GetOrderById(id);
            return View(ord);
        }

        public ActionResult Delete(int id)
        {
            Order ord = new Order();
            ord = DB.DbAccess.SqlDbHelper.GetOrderById(id);
            return View(ord);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            DB.DbAccess.SqlDbHelper.DeleteOrder(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string customerName, DateTime dt)
        {
            DB.DbAccess.SqlDbHelper.CreateOrder(customerName, dt);
            return RedirectToAction("Index");
        }

    }
}