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
    
    public partial class tb_Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public Nullable<bool> isRead { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> modifidedDate { get; set; }
        public string modifidedBy { get; set; }
    }
}
