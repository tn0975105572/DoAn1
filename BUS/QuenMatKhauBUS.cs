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
    public class QuenMatKhauBUS
    {
        QuenMatKhauDAL quen = new QuenMatKhauDAL();
        public DataTable getData()
        {
            return quen.getData();
        }
        public bool KiemTraTonTai(string tenDangNhap, string email)
        {
            return quen.KiemTraTonTai(tenDangNhap, email);
        }
        public string KiemTraTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            if (KiemTraTonTai(taiKhoan.Taikhoan, taiKhoan.Email))
            {
                return "Xác thực thành công";
            }
            
            else
            {
                return "Tài khoản không tồn tại hoặc thông tin không chính xác";
            }
        }
        public string SuaTaiKhoan(TaiKhoanDTO tk)
        {
        
            bool result = quen.Sua(tk);
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
