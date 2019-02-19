using FYP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.Controllers
{
    public class UserProfileController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: UserProfile
        public ActionResult Index()
        {
            var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info where U_Email=@p0 ", User.Identity.Name).ToList();
            return View(data);
        }


        public ActionResult Details(int id)
        {
            var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info where U_Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info where U_Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: AdminRegister/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_User_info obj, HttpPostedFileBase[] files)
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

                            List<object> parameters = new List<object>();
                            parameters.Add(obj.U_Image = ImageName);
                            parameters.Add(obj.U_Name);
                            parameters.Add(obj.U_Gender);
                            parameters.Add(obj.U_Mobile);
                            parameters.Add(obj.U_Email);
                            parameters.Add(obj.U_Password);
                            parameters.Add(obj.U_CNIC);
                            parameters.Add(obj.C_Id);
                            parameters.Add(obj.U_Id);
                            object[] objectarray = parameters.ToArray();
                            int output = db.Database.ExecuteSqlCommand("update tbl_User_info set u_image=@p0,u_name=@p1,u_gender=@p2,u_mobile=@p3,u_email=@p4,u_password=@p5,u_cnic=@p6,c_id=@p7 where u_id=@p8", objectarray);
                            if (output > 0)
                            {
                                ViewBag.Itemmsg = "Your User id " + obj.U_Id + "is Updated successfully";
                            }

                        }
                    }
                }
                // TODO: Add update logic here

                return View();
            }
            catch
            {
                return View();
            }
        }



    }
}