//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class GunlukArsiv
    {
        public int ID { get; set; }
        public Nullable<int> KayitId { get; set; }
        public string plaka { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
        public Nullable<decimal> hasilat { get; set; }
    
        public virtual kayit kayit { get; set; }
    }
}