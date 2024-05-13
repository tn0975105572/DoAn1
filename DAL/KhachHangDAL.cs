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
    public class KhachHangDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
        public DataTable getData()
        {
            string sql = "Select * from KhachHang";
            return csdl.getData(sql);


        }
        public int LayMaKhachHangTiepTheo()
        {
            string sql = "SELECT ISNULL(MAX(MaKhachHang), 0) FROM KhachHang";
            int maKhachHangHienTai = csdl.LayGiaTri(sql);
            int maKhachHangMoi = maKhachHangHienTai + 1;
            return maKhachHangMoi;
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from KhachHang where MaKhachHang='" + ma.Trim() + "'";
            return csdl.KiemTraMaTrung(ma, sql);
        }
        public bool ThemKhachHang(KhachHangDTO HK)
        {
            int maKhachHangMoi = LayMaKhachHangTiepTheo();
            string sql = string.Format("INSERT INTO KhachHang  VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                maKhachHangMoi, HK.TenKH, HK.DiaChi, HK.SDT, HK.Email);
            csdl.chaycodesql(sql);
            return true;

        }
        public bool SuanKhachHang(KhachHangDTO hk)
        {
            string sql = string.Format("UPDATE KhachHang SET HoTen = '{0}', DiaChi = '{1}', SoDienThoai = '{2}',Email='{3}' WHERE MaKhachHang = '{4}'", hk.TenKH,hk.DiaChi,hk.SDT,hk.Email,hk.MaKH);
            csdl.chaycodesql(sql);
            return true;
        }
        public bool XoaKhachHang(string ma)
        {
            string sql = string.Format("DELETE FROM KhachHang WHERE MaKhachHang = '{0}'", ma);
            csdl.chaycodesql(sql);
            return true;
        }
        public DataTable TimKiem(string keyword)
        {
            string sql = string.Format("SELECT * FROM KhachHang WHERE MaKhachHang LIKE '%{0}%' OR HoTen LIKE '%{0}%'", keyword);
            return csdl.getData(sql);
        }
    }
}
