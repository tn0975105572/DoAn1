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
    public class SuaBUS
    {
        SuaTaiKhoanDAL sua = new SuaTaiKhoanDAL();
        public DataTable getData()
        {
            return sua.getData();
        }
        public string DoiTaiKhoan(TaiKhoanDTO tk)
        {

            bool result = sua.Doi(tk);
            if (result)
            {
                return "Sửa tài khoản thành công";
            }
            else
            {
                return "Sửa tài khoản không thành công";
            }
        }
    }
}
