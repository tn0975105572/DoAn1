//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn1_10122390
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDonHang
    {
        public int MaDonHang { get; set; }
        public int MaSanPham { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> Gia { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public Nullable<int> MaGiamGia { get; set; }
        public int MaChiTietHoaDon { get; set; }
    
        public virtual DonHang DonHang { get; set; }
    }
}