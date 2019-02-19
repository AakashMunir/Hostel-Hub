using FYP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    public class ImagesController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: Images
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Hostel_Images collection, HttpPostedFileBase[] files,int id)
        {
            try
            {
                // TODO: Add insert logic here
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

                            lst.Add(collection.I_Name = ImageName);
                            lst.Add(collection.H_Id=id);



                            object[] allitems = lst.ToArray();
                            int output = db.Database.ExecuteSqlCommand("insert into tbl_Hostel_Images (i_name,h_id)values(@p0,@p1)", allitems);
                            if (output > 0)
                            {
                                ViewBag.msg = "Hostel Images is Added";
                            }
                            return View();
                        }
                    }
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