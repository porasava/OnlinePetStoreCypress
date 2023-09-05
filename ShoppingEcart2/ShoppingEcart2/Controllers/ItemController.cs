using ShoppingEcart2.Models;
using ShoppingEcart2.ViewModel;
using System;
using System.Collections.Generic;
//using System.Data.Objects.SqlClient;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingEcart2.Controllers
{
    public class ItemController : Controller
    {
        private ECartDBEntities objectECartDbEntities;
        public ItemController()
        {
            objectECartDbEntities = new ECartDBEntities();
        }
        // GET: Item
        public ActionResult Index()
        {
            ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem = (from objCat in objectECartDbEntities.Categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.CategoryName,
                                                           Value = SqlFunctions.StringConvert((decimal)objCat.CategoryId),
                                                           Selected = true
                                                       });
            return View(objItemViewModel);
        }
        [HttpPost]
        public JsonResult Index(ItemViewModel objItemViewModel)
        {
            //save image
            string NewImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.ImagePath.FileName);
            objItemViewModel.ImagePath.SaveAs(Server.MapPath("~/Images/" + NewImage));
            Item objItem = new Item();
            objItem.ImagePath = "~/Images/" + NewImage;
            objItem.CategoryId = objItemViewModel.CategoryId;
            objItem.Description = objItemViewModel.Description;
            objItem.ItemCode = objItemViewModel.ItemCode;
            objItem.ItemId = Guid.NewGuid();
            objItem.ItemName = objItemViewModel.ItemName;
            objItem.ItemPrice = objItemViewModel.ItemPrice;
            objectECartDbEntities.Items.Add(objItem);
            objectECartDbEntities.SaveChanges();
             
            return Json(new { Success = true, Message = "Item is added Successfully." },
                JsonRequestBehavior.AllowGet);
        }



    }
}