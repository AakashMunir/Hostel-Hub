﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hostel_HubEntities2 : DbContext
    {
        public Hostel_HubEntities2()
            : base("name=Hostel_HubEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Hostel_Booking> tbl_Hostel_Booking { get; set; }
        public virtual DbSet<tbl_Hostel_Category> tbl_Hostel_Category { get; set; }
        public virtual DbSet<tbl_Hostel_Detail> tbl_Hostel_Detail { get; set; }
        public virtual DbSet<tbl_Hostel_Facility> tbl_Hostel_Facility { get; set; }
        public virtual DbSet<tbl_Hostel_Images> tbl_Hostel_Images { get; set; }
        public virtual DbSet<tbl_Hostel_Status> tbl_Hostel_Status { get; set; }
        public virtual DbSet<tbl_Rating> tbl_Rating { get; set; }
        public virtual DbSet<tbl_User_Category> tbl_User_Category { get; set; }
        public virtual DbSet<tbl_User_info> tbl_User_info { get; set; }
    }
}