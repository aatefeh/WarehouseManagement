//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VoucherProcessing.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FactorItem
    {
        public long ID { get; set; }
        public long warehouse_id { get; set; }
        public long part_id { get; set; }
        public long part_number { get; set; }
    
        public virtual Factor Factor { get; set; }
    }
}
