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
    public class DangKyDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();

        public bool KiemTraTonTai(string tenDangNhap)
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan";

            csdl.ketnoi();
            csdl.cm = new SqlCommand(query, csdl.kn);
            csdl.cm.Parameters.AddWithValue("@TaiKhoan", tenDangNhap);

            int result = (int)csdl.cm.ExecuteScalar();

            csdl.ngatketnoi();

            return result > 0;
        }
        public DataTable getData()
        {
            string sql = "Select * from TaiKhoan";
            return csdl.getData(sql);
        }
        public bool Them(TaiKhoanDTO tk)
        {
            string query = string.Format("INSERT INTO TaiKhoan (TaiKhoan, MatKhau, Email, SDT) VALUES ( '{0}','{1}', '{2}', '{3}')", tk.Taikhoan,tk.Matkhau,tk.Email,tk.SDT);
            csdl.chaycodesql(query);
            return true;
            

           
        }
        public int Check(string ma)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan";

            csdl.ketnoi();

            using (SqlCommand command = new SqlCommand(sql, csdl.kn))
            {
                command.Parameters.AddWithValue("@TaiKhoan", ma); 
                int result = (int)command.ExecuteScalar();
                return result;
            }
        }


    }

}
