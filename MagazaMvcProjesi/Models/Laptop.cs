//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazaMvcProjesi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Laptop
    {
        public int laptopId { get; set; }
        public string color { get; set; }
        public Nullable<int> screenSize { get; set; }
        public string operatingSystem { get; set; }
        public bool bluetooth { get; set; }
        public decimal laptopPrice { get; set; }
        public int dealerId { get; set; }
        public int customerId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
