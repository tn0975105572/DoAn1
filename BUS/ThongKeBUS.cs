using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Security.Policy;
using System.Data.SqlClient;


namespace BUS
{
    public class ThongKeBUS
    {
        private ThongKeDAL tk = new ThongKeDAL();
     
        public int getMaxMaKhachHang()
        {
            DataTable dt = tk.getData();
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMaKhachHang"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["MaxMaKhachHang"]);
            }
            return 0;
        }

        public int getMaxMaNhanVien()
        {
            DataTable dt = tk.getData1();
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMaNhanVien"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["MaxMaNhanVien"]);
            }
            return 0;
        }

        public int getMaxMaSanPham()
        {
            DataTable dt = tk.getData2();
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMaSanPham"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["MaxMaSanPham"]);
            }
            return 0;
        }
    }
}
