using FYP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace FYP.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminRegisterController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: AdminRegister
        public ActionResult Index(string option, string search, int? i)
        {
            if (option == "C_Id")
            {
                var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info u join tbl_User_Category c on u.C_Id=c.C_Id where C_Name=@p0", search).ToList().ToPagedList(i ?? 1, 6);
                return View(data);
                
            }
            
            else
            {
                var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info").ToList().ToPagedList(i ?? 1, 6);
                return View(data);
                
            }
            
        }

        // GET: AdminRegister/Details/5
        public ActionResult Details(int id)
        {
            var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info where U_Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: AdminRegister/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminRegister/Create
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

        // GET: AdminRegister/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info where U_Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: AdminRegister/Edit/5
        [HttpPost]
        public ActionResult Edit( tbl_User_info obj, HttpPostedFileBase[] files)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    string ImageName = null;
                    string physicalPath = null;
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            ImageName = Path.GetFileName(file.FileName);
                            physicalPath = Path.Combine(Server.MapPath("~/Images/") + ImageName);
                            file.SaveAs(physicalPath);

                            List<object> parameters = new List<object>();
                            parameters.Add(obj.U_Image=ImageName);
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
                            return View();
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

        // GET: AdminRegister/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.tbl_User_info.SqlQuery("select * from tbl_User_info where U_Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: AdminRegister/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var userList = db.Database.ExecuteSqlCommand("delete from tbl_User_info where u_id=@p0", id);
                if (userList != 0)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
