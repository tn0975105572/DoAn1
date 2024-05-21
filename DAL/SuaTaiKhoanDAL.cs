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
    public class SuaTaiKhoanDAL
    {
        private CSDL_DAL csdl = new CSDL_DAL();
        public DataTable getData()
        {
            string sql = "SELECT * FROM TaiKhoan";
            return csdl.getData(sql);
        }
        public bool Doi(TaiKhoanDTO tk)
        {
            string  query = string.Format("UPDATE TaiKhoan SET MatKhau = '{0}', Email = N'{1}', SDT = '{2}' WHERE TaiKhoan = '{3}'", tk.Matkhau, tk.Email, tk.SDT, tk.Taikhoan);
            csdl.chaycodesql(query);
            return true;
        }
    }    

}
