using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace DAL
{
    public class DonHangDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
  
        public int LayMaDonHangTiepTheo()
        {
            string sql = "SELECT ISNULL(MAX(MaDonHang), 0) FROM DonHang";
            int ma = csdl.LayGiaTri(sql);
            int maDonHang = ma + 1;
            return maDonHang;
        }
        public int LayMaChiTietTiepTheo()
        {
            string sql = "SELECT MAX(MaChiTietHoaDon) AS MaxMaChiTietHoaDon FROM [ChiTietDonHang];";
            int ma = csdl.LayGiaTri(sql);
            int maDonHang = ma + 1;
            return maDonHang;
        }


        public DataTable getData()
        {
            string sql = "SELECT MAX(MaDonHang) AS MaxMaDonHang FROM DonHang";
            return csdl.getData(sql);


        }
       


        public bool ThemDonHang(DonHangDTO DH)
        {
            int maDonHang = LayMaDonHangTiepTheo();
            string sql = string.Format("INSERT INTO DonHang (MaDonHang) VALUES ('{0}')", maDonHang);
            csdl.chaycodesql(sql);
            return true;

        }

        public bool ThemChiTiet(DonHangDTO DH)
        {
            int maDonHang = LayMaChiTietTiepTheo();
            string sql = string.Format("insert into ChiTietDonHang values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
              DH.MaDonHang, DH.MaSanPham, DH.SoLuong, DH.Gia, DH.MaNhanVien, DH.MaGiamGia, maDonHang);
            csdl.chaycodesql(sql);
            return true;

        }

        public bool Suasoluong(SanPhamDTO sp)
        {
            string sql = string.Format("Update SanPham Set  SoLuong = '{0}' Where MaSanPham = '{1}'",  sp.SoLuong, sp.Masp);
            csdl.chaycodesql(sql);
            return true;

        }
    }
}
