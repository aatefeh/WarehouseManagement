//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Part
    {
        public long ID { get; set; }
        public string part_name { get; set; }
        public long unit_id { get; set; }

        public virtual UnitPart UnitPart { get; set; }
    }
}