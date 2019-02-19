using FYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace FYP.Controllers
{
    
    public class HostelBookingController : Controller
    {
        Hostel_HubEntities2 db = new Hostel_HubEntities2();
        // GET: HostelBooking
        public ActionResult Index()
        {
            var data = db.tbl_Hostel_Booking.SqlQuery("select * from tbl_Hostel_Booking b join tbl_Hostel_Detail d on b.H_Id=d.H_Id join tbl_User_info u on b.U_Id=u.U_Id where u.U_Email=@p0 ",User.Identity.Name).ToList();
            return View(data);
        }
        
        public ActionResult Create()
        { 
            return View();
        }

        // POST: AdminRegister/Create
        [HttpPost]
        public ActionResult Create(tbl_Hostel_Booking collection ,int id)
        {
            try
            {
                
                if(ModelState.IsValid)
                {
                    List<object> lst = new List<object>();
                    lst.Add(collection.U_Id);
                    lst.Add(collection.H_Id = id);
                    lst.Add(collection.B_Date);
                    lst.Add(collection.B_Email);
                    object[] allitems = lst.ToArray();
                    int output = db.Database.ExecuteSqlCommand("insert into tbl_Hostel_Booking (u_id,h_id,b_date,b_email)values(@p0,@p1,@p2,@p3)", allitems);
                    using (MailMessage mm = new MailMessage("malikaakash91@gmail.com", collection.B_Email))
                    {
                        mm.Subject = "Room Booking";
                        mm.Body = "Dear Customer Your Hostel Booking Last Date is " + collection.B_Date + "\n\nThankx For Booking";
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("malikaakash91@gmail.com", "malik03136326900");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                    if (output > 0)
                    {
                        ViewBag.msg = "Booking is Sucssessfull and Please Check Your Email";
                    }

                    return View();
                }
                else
                {
                    return View();
                }

                
            }
            catch
            {
                return View();
            }
        }
    }
}