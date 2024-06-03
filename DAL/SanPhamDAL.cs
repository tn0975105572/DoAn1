using System;
using DTO;
using System.Data;


namespace DAL
{
    public class SanPhamDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
        public DataTable getData()
        {
            string sql = "Select MaSanPham,TenSanPham,Gia,MoTa,MaNhaCungCap,SoLuong from SanPham";
            return csdl.getData(sql);

        }
        public DataTable Lay()
        {
            string sql = "Select TenSanPham,MaSanPham,Gia,SoLuong from SanPham";
            return csdl.getData(sql);

        }

        public DataTable getData1()
        {
            string sql = "select MaNhaCungCap from NhaCungCap";
            return csdl.getData(sql);
        }
        public DataTable LayDanhSachMaVaTenSanPham()
        {
            string sql = "SELECT MaSanPham, TenSanPham,SoLuong,Gia FROM SanPham";
            return csdl.getData(sql);
        }

        public int LayMaSanPhamTiepTheo()
        {
            string sql = "SELECT ISNULL(MAX(MaSanPham), 0) FROM SanPham";
            int maSanPhamHienTai = csdl.LayGiaTri(sql);
            int maSanPhamMoi = maSanPhamHienTai + 1;
            return maSanPhamMoi;
        }

        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from SanPham where MaSanPham='" + ma.Trim() + "'";
            return csdl.KiemTraMaTrung(ma, sql);
        }

        public bool Themsp(SanPhamDTO sp)
        {
            int maSanPhamMoi = LayMaSanPhamTiepTheo();
            string sql = string.Format("INSERT INTO SanPham (MaSanPham, TenSanPham, Gia, MoTa, MaNhaCungCap, SoLuong) VALUES ('{0}', N'{1}', '{2}', N'{3}', '{4}', '{5}')",
                maSanPhamMoi, sp.Tensp, sp.Gia, sp.Mota, sp.Mancc, sp.SoLuong);
            csdl.chaycodesql(sql);
            return true;
        }


        public bool Suasp(SanPhamDTO sp)
        {
            string sql = string.Format("Update SanPham Set TenSanPham = N'{0}', Gia = '{1}', MoTa = N'{2}', MaNhaCungCap = '{3}', SoLuong = '{4}' Where MaSanPham = '{5}'", sp.Tensp, sp.Gia, sp.Mota, sp.Mancc, sp.SoLuong, sp.Masp);
            csdl.chaycodesql(sql);
            return true;
        }

        public bool Xoanv(SanPhamDTO sp)
        {
            string sql = string.Format("Delete from SanPham Where MaSanPham = '{0}'", sp.Masp);
            csdl.chaycodesql(sql);
            return true;
        }

        public DataTable TimKiemSP(string keyword)
        {
            string sql = string.Format("Select * from SanPham Where MaSanPham like '%{0}%'",  keyword);
            return csdl.getData(sql);
        }
        public bool Suasoluong(int olodo, int olodo1)
        {
            string sql1 = string.Format("UPDATE SanPham SET SoLuong =  {0} WHERE MaSanPham = '{1}'", olodo1, olodo);
            csdl.chaycodesql(sql1);
            return true;
        }
    }
}
