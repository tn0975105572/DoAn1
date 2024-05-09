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
    public class NhanvienDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
        public DataTable getData()
        {
            string sql = "Select * from NhanVien";
            return csdl.getData(sql);

        }
        public int LayMaNhanVienTiepTheo()
        {
            string sql = "SELECT ISNULL(MAX(MaNhanVien), 0) FROM NhanVien";
            int maNhanVienHienTai = csdl.LayGiaTri(sql);
            int maNhanVienMoi = maNhanVienHienTai + 1;
            return maNhanVienMoi;
        }


        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from NhanVien where MaNhanVien='" + ma.Trim() + "'";
            return csdl.KiemTraMaTrung(ma, sql);
        }
        public bool Themnv(NhanVienDTO nv) 
        {
            //string sql = string.Format("Insert into NhanVien values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", nv.Manv, nv.Tennv, nv.Gioitinh, nv.Ngaysinh.ToString("yyyy-MM-dd"), nv.Diachi, nv.Sodienthoai, nv.Email);
            //csdl.chaycodesql(sql);
            //return true;
            int maNhanVienMoi = LayMaNhanVienTiepTheo();
            string sql = string.Format("Insert into NhanVien values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", maNhanVienMoi, nv.Tennv, nv.Gioitinh, nv.Ngaysinh.ToString("yyyy-MM-dd"), nv.Diachi, nv.Sodienthoai, nv.Email);
            csdl.chaycodesql(sql);
            return true;


        }
        public bool Suavn(NhanVienDTO nv)
        {
            string sql = string.Format("UPDATE NhanVien SET HoTen = '{0}', GioiTinh = '{1}', NgaySinh = '{2}', DiaChi = '{3}', SoDienThoai = '{4}', Email = '{5}' WHERE MaNhanVien = '{6}'", nv.Tennv, nv.Gioitinh, nv.Ngaysinh.ToString("yyyy-MM-dd"), nv.Diachi, nv.Sodienthoai, nv.Email, nv.Manv);
            csdl.chaycodesql(sql);
            return true;
        }
        public bool Xoanv(string ma)
        {
            string sql = string.Format("DELETE FROM NhanVien WHERE MaNhanVien = '{0}'", ma);
            csdl.chaycodesql(sql);
            return true;
        }

        public DataTable TimKiemNhanVien(string keyword)
        {
            string sql = string.Format("SELECT * FROM NhanVien WHERE MaNhanVien LIKE '%{0}%' OR HoTen LIKE '%{0}%'", keyword);
            return csdl.getData(sql);
        }



    }
}
