//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FYP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_Hostel_Booking
    {
        public int B_Id { get; set; }
        [DisplayName("User Id")]
        [Required(ErrorMessage = "Required")]
        public Nullable<int> U_Id { get; set; }
        public Nullable<int> H_Id { get; set; }
        [DisplayName("Laste Date of Booking")]
        [Required(ErrorMessage = "Required")]
        public Nullable<System.DateTime> B_Date { get; set; }
        public string B_Email { get; set; }
    
        public virtual tbl_Hostel_Detail tbl_Hostel_Detail { get; set; }
        public virtual tbl_User_info tbl_User_info { get; set; }
    }
}
