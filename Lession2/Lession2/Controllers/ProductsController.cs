using DB.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lession2.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(string search)
        {
            List<DB.DbAccess.Product> productList = DB.DbAccess.SqlDbHelper.GetProducts();

            if (!String.IsNullOrEmpty(search))
            {
                productList = DB.DbAccess.SqlDbHelper.SearchProByName(search);
            }
            ViewBag.Products = productList;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, float price, int quantity)
        {
            DB.DbAccess.SqlDbHelper.CreateProduct(name, price, quantity);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            DB.DbAccess.Product pro = new DB.DbAccess.Product();
            pro = DB.DbAccess.SqlDbHelper.GetProductById(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(int id, string name, float price, int quantity)
        {
            DB.DbAccess.SqlDbHelper.EditProduct(id, name, price, quantity);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            DB.DbAccess.Product pro = new DB.DbAccess.Product();
            pro = DB.DbAccess.SqlDbHelper.GetProductById(id);
            return View(pro);
        }
        public ActionResult Delete(int id)
        {
            DB.DbAccess.Product pro = new DB.DbAccess.Product();
            pro = DB.DbAccess.SqlDbHelper.GetProductById(id);
            return View(pro);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            DB.DbAccess.Product pro = new DB.DbAccess.Product();
            DB.DbAccess.SqlDbHelper.DeleteProduct(id);
            return RedirectToAction("Index");
        }



    }
}
