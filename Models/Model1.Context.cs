﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoldenPet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GoldenPetEntities : DbContext
    {
        public GoldenPetEntities()
            : base("name=GoldenPetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Advertisement> tb_Advertisement { get; set; }
        public virtual DbSet<tb_Contact> tb_Contact { get; set; }
        public virtual DbSet<tb_Img> tb_Img { get; set; }
        public virtual DbSet<tb_Menu> tb_Menu { get; set; }
        public virtual DbSet<tb_Product> tb_Product { get; set; }
        public virtual DbSet<tb_ProductCategory> tb_ProductCategory { get; set; }
        public virtual DbSet<tb_Service> tb_Service { get; set; }
        public virtual DbSet<tb_Package> tb_Package { get; set; }
        public virtual DbSet<tb_PackageFeature> tb_PackageFeature { get; set; }
        public virtual DbSet<tb_News> tb_News { get; set; }
        public virtual DbSet<tb_NewsImages> tb_NewsImages { get; set; }
        public virtual DbSet<tb_MenuCategory> tb_MenuCategory { get; set; }
    }
}
