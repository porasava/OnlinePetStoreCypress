using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingEcart2.Models;

namespace ShoppingEcart2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (ECartDBEntities dbModel = new ECartDBEntities())
                //var newList = newList.OrderBy(x => x.Items.ItemName).ToList();
            return View(dbModel.Items.OrderBy(x => x.ItemName).ToList());
        }


      

        // GET: Product/Delete/5
        public ActionResult DeleteItem(string id)
        {
            using(ECartDBEntities dbModel = new ECartDBEntities())
                return View(dbModel.Items.Where(x => x.ItemId.ToString() == id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult DeleteItem(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ECartDBEntities dbModel=new ECartDBEntities())
                {
                    Item item = dbModel.Items.FirstOrDefault(x => x.ItemId.ToString() == id);
                    dbModel.Items.Remove(item);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }

        }
    }
}
