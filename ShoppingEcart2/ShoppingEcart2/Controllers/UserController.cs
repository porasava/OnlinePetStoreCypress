using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingEcart2.Models;

namespace ShoppingEcart2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddorEdit(int id = 0)
        {
            CustomerUser userModel = new CustomerUser();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CustomerUser userModel)
        {
            using (ECartDBEntities dbModel = new ECartDBEntities())
            {
                if (dbModel.CustomerUsers.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", userModel);
                }
                dbModel.CustomerUsers.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful.";
            return View("AddOrEdit", new CustomerUser());
        }

        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(CustomerUser userModel)
        {
            using (ECartDBEntities db = new ECartDBEntities())
            {
                var userDetails = db.CustomerUsers.Where(x => x.UserName == userModel.UserName
                  && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong Username or Password";
                    return View("CustomerLogin", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.CustomerId;
                    Session["userName"]=userDetails.UserName;
                    return RedirectToAction("Index", "Shopping");
                }
            }

        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userId"];

            Session.Abandon();
            return RedirectToAction("CustomerLogin", "User");
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherizee(AdminUser Adminuser)
        {
            using (ECartDBEntities db = new ECartDBEntities())
            {
                var AdminuserDetails = db.AdminUsers.Where(x => x.AdminUsername == Adminuser.AdminUsername
                  && x.AdminPassword == Adminuser.AdminPassword).FirstOrDefault();
                if (AdminuserDetails == null)
                {
                    Adminuser.AdminLoginErrorMessage = "Wrong Username or Password";
                    return View("AdminLogin", Adminuser);
                }
                else
                {
                    Session["AdminUserID"] = AdminuserDetails.AdminId;
                    Session["AdminUserName"] = AdminuserDetails.AdminUsername;
                    return RedirectToAction("Index", "Product");
                }
            }

        }
        [HttpGet]
        public ActionResult AdminRegister(int id = 0)
        {
            AdminUser AdmindbModel = new AdminUser();
            return View(AdmindbModel);
        }

        [HttpPost]
        public ActionResult AdminRegister(AdminUser AdminuserModel)
        {
            using (ECartDBEntities AdmindbModel = new ECartDBEntities())
            {
                if (AdmindbModel.AdminUsers.Any(x => x.AdminUsername == AdminuserModel.AdminUsername))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AdminRegister", AdminuserModel);
                }
                AdmindbModel.AdminUsers.Add(AdminuserModel);
                AdmindbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful.";
            return View("AdminRegister", new AdminUser());
        }


        public ActionResult AdminLogOut()
        {
            int userId = (int)Session["AdminUserID"];

            Session.Abandon();
            return RedirectToAction("AdminLogin", "User");
        }

        // GET: Product
        public ActionResult CustomerList()
        {
            using (ECartDBEntities dbModel = new ECartDBEntities())
                return View(dbModel.CustomerUsers.ToList());
        }


        // GET: Product/Delete/5
        public ActionResult DeleteCustomer(int id)
        {
            using (ECartDBEntities dbModelCus = new ECartDBEntities())
                return View(dbModelCus.CustomerUsers.Where(x => x.CustomerId == id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult DeleteCustomer(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ECartDBEntities dbModelCus = new ECartDBEntities())
                {
                    CustomerUser Customer = dbModelCus.CustomerUsers.Where(x => x.CustomerId == id).FirstOrDefault();
                    dbModelCus.CustomerUsers.Remove(Customer);
                    dbModelCus.SaveChanges();
                }
                return RedirectToAction("CustomerList");
            }
            catch
            {
                return View("CustomerList");
            }

        }
    }
}