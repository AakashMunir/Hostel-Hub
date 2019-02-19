using FYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FYP.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    public class CreateHostelController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        
     
        // GET: CreateHostel
        public ActionResult Index()
        {
            
            var data = db.tbl_Hostel_Detail.SqlQuery("select * from tbl_Hostel_Detail d join tbl_User_info u on d.U_id=u.U_id where U_Email=@p0 ", User.Identity.Name).ToList();
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }

        // POST: AdminHostel/Create
        [HttpPost]
        public ActionResult Create(tbl_Hostel_Detail collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    List<object> lst = new List<object>();
                    lst.Add(collection.H_Name);
                    lst.Add(collection.H_Address);
                    lst.Add(collection.H_Mobile);
                    lst.Add(collection.H_Description);
                    lst.Add(collection.H_Near_University);
                    lst.Add(collection.H_Area);
                    lst.Add(collection.H_Total_Room);
                    lst.Add(collection.H_Avail_Room);
                    lst.Add(collection.H_Security);
                    lst.Add(collection.H_Wifi_Charges);
                    lst.Add(collection.HC_Id);
                    lst.Add(collection.HF_Id);
                    lst.Add(collection.U_Id);

                    object[] allitems = lst.ToArray();
                    int output = db.Database.ExecuteSqlCommand("insert into tbl_Hostel_Detail (h_name,h_address,h_mobile,h_description,h_near_university,h_area,h_total_room,h_avail_room,h_security,h_wifi_charges,hc_id,hf_id,u_id)values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", allitems);
                    if (output > 0)
                    {
                        ViewBag.msg = "Hostel is Add";
                    }
                    return View();
                }
                else
                {
                    return View();
                }
                // TODO: Add insert logic here
               
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var data = db.tbl_Hostel_Detail.SqlQuery("select * from tbl_Hostel_Detail where H_Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: AdminHostel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_Hostel_Detail obj)
        {
            try
            {
                // TODO: Add update logic here
                List<object> parameters = new List<object>();
                parameters.Add(obj.H_Name);
                parameters.Add(obj.H_Address);
                parameters.Add(obj.H_Mobile);
                parameters.Add(obj.H_Description);
                parameters.Add(obj.H_Near_University);
                parameters.Add(obj.H_Area);
                parameters.Add(obj.H_Total_Room);
                parameters.Add(obj.H_Avail_Room);
                parameters.Add(obj.H_Security);
                parameters.Add(obj.H_Wifi_Charges);
                parameters.Add(obj.HC_Id);
                parameters.Add(obj.HF_Id);
                parameters.Add(obj.U_Id);
                parameters.Add(obj.H_Id);
                object[] objr = parameters.ToArray();
                int ar = db.Database.ExecuteSqlCommand("update tbl_Hostel_Detail set h_name=@p0,h_address=@p1,h_mobile=@p2,h_description=@p3,h_near_university=@p4,h_area=@p5,h_total_room=@p6,h_avail_room=@p7,h_security=@p8,h_wifi_charges=@p9,hc_id=@p10,hf_id=@p11,u_id=@p12 where h_id=@p13", objr);
                if (ar > 1)
                {
                    ViewBag.Itemmsg = "Your Hostel id " + obj.H_Id + "is Updated successfully";
                }
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
            var data = db.tbl_Hostel_Detail.SqlQuery("select * from tbl_Hostel_Detail where H_Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: AdminRegister/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tbl_Hostel_Detail collection)
        {
            try
            {
                // TODO: Add delete logic here
                var userList = db.Database.ExecuteSqlCommand("delete from tbl_Hostel_Detail where H_Id=@p0", id);
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