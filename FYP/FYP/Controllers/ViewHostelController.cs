using FYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace FYP.Controllers
{
    [AllowAnonymous]
    public class ViewHostelController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: ViewHostel

        public ActionResult Index(string option, string search, int? i)
        {
            List<HostelModel> hostelList = new List<HostelModel>();
            hostelList.Add(new HostelModel());
            float avr = 0;
            foreach (var item in db.tbl_Hostel_Images.ToList())
            {
                tbl_Hostel_Detail hostel_Detail = db.tbl_Hostel_Detail.Where(x => x.H_Id == item.H_Id).FirstOrDefault();
                List<tbl_Rating> ratings = db.tbl_Rating.Where(x => x.H_Id == hostel_Detail.H_Id).ToList();
                if (ratings.Count != 0)
                {
                    avr = (int)(ratings.Sum(x => x.R_Name)) / ratings.Count;

                }
                if (!(hostelList.Any(x => x.H_Id == hostel_Detail.H_Id)))
                {
                    HostelModel hostel = new HostelModel();
                    hostel.H_Id = hostel_Detail.H_Id;
                    hostel.H_Name = hostel_Detail.H_Name;
                    hostel.H_Address = hostel_Detail.H_Address;
                    hostel.I_Name = item.I_Name;
                    hostel.Rating = avr;
                    hostel.H_Near_University = hostel_Detail.H_Near_University;
                    hostel.H_Area = hostel_Detail.H_Area;
                    hostelList.Add(hostel);

                }
            }
            List<HostelModel> nearUni = new List<HostelModel>();
            if (option == "H_Near_University")
            {
                foreach (HostelModel item in hostelList)
                {
                    if(item.H_Near_University == search)
                    {
                        nearUni.Add(item);
                    }
                }
                return View(nearUni.ToPagedList(i ?? 1, 6));
            }
           
            else if (option == "H_Area")
            {
                List<HostelModel> nearAre = new List<HostelModel>();
                foreach (HostelModel item in hostelList)
                {
                    if (item.H_Area == search)
                    {
                        nearAre.Add(item);
                    }
                }
                return View(nearAre.ToPagedList(i ?? 1, 6));
            }

            else
            {
                return View(hostelList.ToPagedList(i ?? 1, 6));

            }

            //if (option == "H_Near_University")
            //{
            //    var data = db.tbl_Hostel_Images.SqlQuery("select * from tbl_Hostel_Images d join tbl_Hostel_Detail i on d.H_Id = i.H_Id where H_Near_University=@p0", search).ToList().ToPagedList(i ?? 1, 9);
            //    return View(data);
            //}
            //else if (option == "H_Area")
            //{
            //    var data = db.tbl_Hostel_Images.SqlQuery("select * from tbl_Hostel_Images d join tbl_Hostel_Detail i on d.H_Id = i.H_Id where H_Area=@p0", search).ToList().ToPagedList(i ?? 1, 9);
            //    return View(data);
            //}
            //else
            //{
            //    var data = db.tbl_Hostel_Images.SqlQuery("select * from tbl_Hostel_Images d join tbl_Hostel_Detail i on d.H_Id = i.H_Id ").ToList().ToPagedList(i ?? 1, 9);
            //    return View(data);
            //}



        }

        public ActionResult Details(int id)
        {
            
            var data = db.tbl_Hostel_Images.SqlQuery("select * from tbl_Hostel_Images where H_Id = @p0", id).ToList();
            return View(data);
        }


        
    }
}