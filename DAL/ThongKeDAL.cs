using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DAL
{
   
    public class ThongKeDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
        public DataTable getData()
        {
            string sql = "SELECT MAX(MaKhachHang) AS MaxMaKhachHang FROM KhachHang";
            return csdl.getData(sql);


        }
        public DataTable getData1()
        {
            string sql = "SELECT MAX(MaNhanVien) AS MaxMaNhanVien FROM NhanVien";
            return csdl.getData(sql);


        }
        public DataTable getData2()
        {
            string sql = "SELECT MAX(MaSanPham) AS MaxMaSanPham FROM SanPham";
            return csdl.getData(sql);


        }
    }
}
