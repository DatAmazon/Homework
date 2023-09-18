using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Lession2DBFirst.Models;

namespace Lession2DBFirst.Controllers
{
    public class Order_DetailController : Controller
    {
        private Lession2DBEntities db = new Lession2DBEntities();

        public ActionResult Index(string search)
        {

            var order_Detail = from od in db.Order_Detail
                               select od;
            
            if (!string.IsNullOrEmpty(search) && int.TryParse(search, out int num))
            {
                order_Detail = order_Detail.Where(od => od.OrderId == num);

            }
            return View(order_Detail);

            //var order_Detail = db.Order_Detail.Include(o => o.Order).Include(o => o.Product);
            //var order_Detail = db.Order_Detail.Include(o => o.Order).Include(o => o.Product);
            //return View(order_Detail.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderDetailId,OrderId,ProductId,Quantity,UnitPrice")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Order_Detail.Add(order_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", order_Detail.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Name", order_Detail.ProductId);
            return View(order_Detail);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", order_Detail.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Name", order_Detail.ProductId);
            return View(order_Detail);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailId,OrderId,ProductId,Quantity,UnitPrice")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", order_Detail.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Name", order_Detail.ProductId);
            return View(order_Detail);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            db.Order_Detail.Remove(order_Detail);
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
