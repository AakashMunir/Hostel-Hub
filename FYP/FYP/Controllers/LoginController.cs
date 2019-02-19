using FYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FYP.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User_info user)
        {
            try
            {
                if (Membership.ValidateUser(user.U_Email, user.U_Password))
                {
                    
                    FormsAuthentication.SetAuthCookie(user.U_Email, true);
                    var users = user.U_Id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Msg"] = "Login Failed  ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception E1)
            {
                TempData["Msg"] = "Login Failed  " + E1.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}