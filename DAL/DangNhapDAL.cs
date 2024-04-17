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
namespace DAL
{
    public class DAL_DangNhap : CSDL_DAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";


            csdl.ketnoi();
            csdl.cm = new SqlCommand(query, csdl.kn);
            csdl.cm.Parameters.AddWithValue("@TaiKhoan", tenDangNhap);
            csdl.cm.Parameters.AddWithValue("@MatKhau", matKhau);

            int kqtrave = (int)csdl.cm.ExecuteScalar();
            

            csdl.ngatketnoi();

            return kqtrave > 0;
        }
        public DataTable getData()
        {
            string sql = "Select * from TaiKhoan";
            return csdl.getData(sql);
        }
        public int Check(string ma)
        {
            string sql = "Select count(*) from TaiKhoan where TaiKhoan='" + ma.Trim() + "'";
            return csdl.KiemTraMaTrung(ma, sql);
        }



    }
}

