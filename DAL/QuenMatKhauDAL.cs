using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QuenMatKhauDAL
    {
        private CSDL_DAL csdl = new CSDL_DAL();

        public bool KiemTraTonTai(string tenDangNhap, string email)
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan AND Email = @Email ";

            csdl.ketnoi();
            csdl.cm = new SqlCommand(query, csdl.kn);
            csdl.cm.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tenDangNhap;
            csdl.cm.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
            

            int result = (int)csdl.cm.ExecuteScalar();

            csdl.ngatketnoi();

            return result > 0;
        }

        public DataTable getData()
        {
            string sql = "SELECT * FROM TaiKhoan";
            return csdl.getData(sql);
        }

        public bool Sua(TaiKhoanDTO tk)
        {
            string query = string.Format("UPDATE TaiKhoan SET MatKhau = '{0}' WHERE TaiKhoan = '{1}'", tk.Matkhau, tk.Taikhoan);
            csdl.chaycodesql(query);
            return true;
        }
    }
}