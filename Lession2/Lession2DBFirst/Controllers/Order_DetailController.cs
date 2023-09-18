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
    public class Order_DetailController : Controller
    {
        private Lession2DBEntities db = new Lession2DBEntities();

        // GET: Order_Detail
        public ActionResult Index()
        {
            var order_Detail = db.Order_Detail.Include(o => o.Order).Include(o => o.Product);
            return View(order_Detail.ToList());
        }

        // GET: Order_Detail/Details/5
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

        // GET: Order_Detail/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        // POST: Order_Detail/Create
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

        // GET: Order_Detail/Edit/5
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

        // POST: Order_Detail/Edit/5
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

        // GET: Order_Detail/Delete/5
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

        // POST: Order_Detail/Delete/5
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
