using ShoppingEcart2.Models;
using ShoppingEcart2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ShoppingEcart2.Controllers
{
    public class ShoppingController : Controller
    {
        private ECartDBEntities objECartDbEntities;
        private List<ShoppingCartModel> listOfShoppingCartModels;
        public ShoppingController()
        {
            objECartDbEntities = new ECartDBEntities();
            //create list of shopping cart model
            listOfShoppingCartModels = new List<ShoppingCartModel>();
        }
        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> listOfShoppingViewModels =
                (from objItem in objECartDbEntities.Items
                 join
                 objCate in objECartDbEntities.Categories
                 on objItem.CategoryId equals objCate.CategoryId
                 select new ShoppingViewModel()
                 {
                     ImagePath = objItem.ImagePath,
                     ItemName = objItem.ItemName,
                     Description = objItem.Description,
                     ItemPrice = objItem.ItemPrice,
                     ItemId = objItem.ItemId,
                     Category = objCate.CategoryName,
                     ItemCode = objItem.ItemCode,
                 }
                 ).ToList();
            return View(listOfShoppingViewModels);
        }

        [HttpPost]
        public JsonResult Index(string ItemId)
        {
            ShoppingCartModel objShoppingCartModel = new ShoppingCartModel();
            //ItemId ใน DB = ตัวแปรใหม่ที่สร้างขึ้น ItemId
            //Item objItem = objECartDbEntities.Items.Single(model => model.ItemId == new Guid(ItemId));

            Item objItem = objECartDbEntities.Items.Single(model => model.ItemId.ToString().Equals(ItemId));
            if (Session["CartCounter"] != null)
            {
                listOfShoppingCartModels = Session["CartItem"] as List<ShoppingCartModel>;
            }
            //ItemId จาก ShoppingCartModel = ตัวแปรใหม่ที่สร้างขึ้น ItemId
            if (listOfShoppingCartModels.Any(model => model.ItemId == ItemId))
            {//ถ้ามีของอยู่ในตระกร้าแล้ว แล้วอยากจะเพิ่มอีก ก็เพิ่มทีละ 1
                objShoppingCartModel = listOfShoppingCartModels.Single(model => model.ItemId == ItemId);
                objShoppingCartModel.Quantity = objShoppingCartModel.Quantity + 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.UnitPrice;
            }
            else
            {//ถ้ายังไม่มีของอยู่ในตระกร้า ของที่อยู่ในโมเดล = ขของที่อยู่ใน DB
                objShoppingCartModel.ItemId = ItemId;
                objShoppingCartModel.ImagePath = objItem.ImagePath;
                objShoppingCartModel.ItemName = objItem.ItemName;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Total = objItem.ItemPrice;
                objShoppingCartModel.UnitPrice = objItem.ItemPrice;
                listOfShoppingCartModels.Add(objShoppingCartModel);
            }
            Session["CartCounter"] = listOfShoppingCartModels.Count;
            Session["CartItem"] = listOfShoppingCartModels;

            return Json(new { Success = true, Counter = listOfShoppingCartModels.Count}, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult Index(string itemNamee, string url)
        //{
        //    //ShoppingCartModel objShoppingCartModel = new ShoppingCartModel();
        //    ECartDBEntities ctx = new ECartDBEntities();
        //    //Item objItem = objECartDbEntities.Items.Single(model => model.ItemId.ToString() == itemId.ToString());
        //    if (Session["cart"] == null)
        //    {
        //        List<ShoppingCartModel> cart = new List<ShoppingCartModel>();
        //        var item = ctx.Items.Find(itemNamee);
        //        cart.Add(new ShoppingCartModel()
        //        {
        //            ItemDB = item,
        //            Quantity = 1,
        //            //ItemName = cart.,
        //            //UnitPrice = ShoppingCartModel.item.ItemPrice,
        //    });
        //        Session["cart"] = cart;
        //    }
        ////    else
        ////    {
        ////        List<ShoppingCartModel> cart = (List<ShoppingCartModel>)Session["cart"];
        ////        var count = cart.Count();
        ////        var item = ctx.Items.Find(itemId);
        ////        for (int i = 0; i < count; i++)
        ////        {
        ////            //string v = cart[i].ItemDB.ItemId;
        ////            if (cart[i].ItemId == itemId)
        ////            {
        ////                int prevQty = (int)cart[i].Quantity;
        ////                cart.Remove(cart[i]);
        ////                cart.Add(new ShoppingCartModel()
        ////                {
        ////                    ItemDB = item,
        ////                    Quantity = prevQty + 1,
        ////                    //ItemName = item.ItemName,
        ////                    //UnitPrice = item.ItemPrice,
        ////                });
        ////                break;
        ////            }
        ////            else
        ////            {
        ////                var prd = cart.Where(x =>
        ////                {
        ////                    //string v1 = x.ItemDB.ItemId2;
        ////                    return x.ItemId == itemId;
        ////                }).SingleOrDefault();
        ////                if (prd == null)
        ////                {
        ////                    cart.Add(new ShoppingCartModel()
        ////                    {
        ////                        ItemDB = item,
        ////                        Quantity = 1,
        ////                        //ItemName = item.ItemName,
        ////                        //UnitPrice = item.ItemPrice,
        ////                    });
        ////                }
        ////            }
        ////        }
        ////Session["cart"] = cart;
        ////    }
        //    return Redirect(url);
        //}

        public ActionResult ShoppingCart()
        {
            listOfShoppingCartModels = Session["CartItem"] as List<ShoppingCartModel>;
            return View(listOfShoppingCartModels);
        }
    }
}