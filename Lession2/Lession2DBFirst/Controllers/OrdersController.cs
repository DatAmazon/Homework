using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lession2DBFirst.Models;

namespace Lession2DBFirst.Controllers
{
    public class OrdersController : Controller
    {
        private Lession2DBEntities db = new Lession2DBEntities();

        public ActionResult Index(string searchString)
        {
            var ord = from o in db.Orders
                      select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                ord = ord.Where(o => o.CustomerName.Contains(searchString));
            }
            ViewBag.listOrder = new List<Order>();
            return View(ord);
        }

        [HttpPost]
        public ActionResult Index()
        {
            DateTime from = DateTime.Parse(Request.Form["dtReviewTime_from"]);
            DateTime to = DateTime.Parse(Request.Form["dtReviewTime_to"]);
            Lession2DBEntities db = new Lession2DBEntities();
            ViewBag.listOrder = db.Orders.Where(x => x.DateTime >= from && x.DateTime <= to).ToList();
            return View();
        }

        public ActionResult Details(int id)
        {
            var order_Detail = from od in db.Order_Detail
                               where od.OrderId == id
                               select od;
            return View(order_Detail);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerName,DateTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerName,DateTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
