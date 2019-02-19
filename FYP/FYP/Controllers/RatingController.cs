using FYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.Controllers
{
    public class RatingController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(tbl_Rating obj,int id)
        {
            try
            {

                // TODO: Add insert logic here
                List<object> lst = new List<object>();
                lst.Add(obj.R_Name);
                lst.Add(obj.H_Id=id);


                object[] allitems = lst.ToArray();
                int output = db.Database.ExecuteSqlCommand("insert into tbl_Rating (r_name,H_id)values(@p0,@p1)", allitems);
                if (output > 0)
                {
                    ViewBag.msg = "Hostel is Rated";
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