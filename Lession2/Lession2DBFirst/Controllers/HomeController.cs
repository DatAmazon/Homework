using Lession2DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lession2DBFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        //public ActionResult ProductList() {
        //    Lession2DBEntities db = new Lession2DBEntities();
        //    List<Product> product = db.Products.ToList();
        //    return View(db);
        //}
    }
}