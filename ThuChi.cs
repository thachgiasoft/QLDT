//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLDT
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThuChi
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public System.DateTime NgayLap { get; set; }
        public string Loai { get; set; }
        public Nullable<long> SoTien { get; set; }
        public long NoiDungId { get; set; }
        public string GhiChu { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
