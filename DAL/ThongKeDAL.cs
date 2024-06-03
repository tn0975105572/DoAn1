using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Bibliography;

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
        public object GetTongDoanhThu(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT SUM(TongTien) AS TongDoanhThu FROM DonHang WHERE NgayDat >= @StartDate AND NgayDat <= @EndDate";
            SqlParameter[] parameters = {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };
            return csdl.ExecuteScalar(sql, parameters);
        }
        public DataTable GetTopSanPhamBanChay(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT TOP 5 SP.TenSanPham AS ProductName, SUM(CTDH.SoLuong) AS QtySold " +
                         "FROM ChiTietDonHang CTDH " +
                         "JOIN SanPham SP ON CTDH.MaSanPham = SP.MaSanPham " +
                         "JOIN DonHang DH ON CTDH.MaDonHang = DH.MaDonHang " +
                         "WHERE DH.NgayDat >= @StartDate AND DH.NgayDat <= @EndDate " +
                         "GROUP BY SP.TenSanPham " +
                         "ORDER BY SUM(CTDH.SoLuong) DESC";
            SqlParameter[] parameters = {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };
            return csdl.getData(sql, parameters);
        }
    }
}
