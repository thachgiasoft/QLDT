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
    
    public partial class ThanhToanCongNo
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public long CongNoId { get; set; }
        public Nullable<long> ThanhToan { get; set; }
        public System.DateTime NgayThanhToan { get; set; }
        public string GhiChu { get; set; }
        public Nullable<long> KhachHangId { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual CongNo CongNo { get; set; }
    }
}
