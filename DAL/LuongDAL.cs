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
using System.Net.NetworkInformation;

namespace DAL
{
    public  class LuongDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
        public DataTable getData()
        {
            string sql = "Select * from BangLuong";
            return csdl.getData(sql);

        }
        public DataTable getData1()
        {
            string sql = "select MaNhanVien from NhanVien";
            return csdl.getData(sql);
        }


        public int LayMaLuongTiepTheo()
        {
            string sql = "SELECT ISNULL(MAX(MaBangLuong), 0) FROM BangLuong";
            int maBangLuonght = csdl.LayGiaTri(sql);
            int maBangLuongMoi = maBangLuonght + 1;
            return maBangLuongMoi;
        }

        public bool ThemLuong(NhanVienDTO nv)
        {
            int maBangLuongMoi = LayMaLuongTiepTheo();
            string sql = string.Format("INSERT INTO BangLuong  VALUES ('{0}', '{1}', '{2}', '{3}')", maBangLuongMoi, nv.Manv, nv.Luong, nv.NgayNhanLuong.ToString("yyyy-MM-dd"));
            csdl.chaycodesql(sql);
            return true;
        }

        public bool SuaLuong(NhanVienDTO nv)
        {
            string sql = string.Format("UPDATE BangLuong SET ThoiGian = '{0}', TongLuong = '{1}' WHERE MaBangLuong = '{2}'", nv.NgayNhanLuong.ToString("yyyy-MM-dd"), nv.Luong, nv.MaBangLuong);
            csdl.chaycodesql(sql);
            return true;

        }

        public bool XoaLuong(NhanVienDTO nv)
        {
            string sql = string.Format("DELETE FROM BangLuong WHERE MaBangLuong = '{0}'", nv.MaBangLuong);
            csdl.chaycodesql(sql);
            return true;
        }
        public DataTable TimKiemLuong(string keyword)
        {
            string sql = string.Format("SELECT * FROM BangLuong WHERE MaNhanVien LIKE '%{0}%' ", keyword);
            return csdl.getData(sql);
        }
    }
}
