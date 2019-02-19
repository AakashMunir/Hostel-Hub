using FYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace FYP.Controllers
{
    [AllowAnonymous]
    public class UserRegisterController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: UserRegister
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_User_info collection, HttpPostedFileBase[] files)
        {
            try
            {

                string ImageName = null;
                string physicalPath = null;
                if (ModelState.IsValid)
                {
                    
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            ImageName = Path.GetFileName(file.FileName);
                            physicalPath = Path.Combine(Server.MapPath("~/Images/") + ImageName);
                            file.SaveAs(physicalPath);

                            List<object> lst = new List<object>();
                            lst.Add(collection.U_Image = ImageName);
                            lst.Add(collection.U_Name);
                            lst.Add(collection.U_Gender);
                            lst.Add(collection.U_Mobile);
                            lst.Add(collection.U_Email);
                            lst.Add(collection.U_Password);
                            lst.Add(collection.U_CNIC);
                            lst.Add(collection.C_Id);
                            object[] allitems = lst.ToArray();
                            int output = db.Database.ExecuteSqlCommand("insert into tbl_User_info (u_image,u_name,u_gender,u_mobile,u_email,u_password,u_cnic,c_id)values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)", allitems);
                            if (output > 0)
                            {
                                ViewBag.msg = "User is Add";
                            }
                            return View();
                        }
                    }
                }
                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        

    }
}