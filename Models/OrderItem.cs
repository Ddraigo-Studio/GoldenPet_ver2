//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public int OrderItemID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual tb_Product tb_Product { get; set; }
    }
}