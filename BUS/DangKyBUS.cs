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
    public class DangKyBUS
    {
        DangKyDAL dk = new DangKyDAL();

        public DataTable getData()
        {
            return dk.getData();
        }

        public int kiemtramatrung(string ma)
        {
            return dk.Check(ma);
        }

        public string KiemTraDangKy(TaiKhoanDTO taiKhoan)
        {
            if (string.IsNullOrEmpty(taiKhoan.Taikhoan))
            {
                return "Tài khoản không được để trống!";
            }

            if (string.IsNullOrEmpty(taiKhoan.Matkhau))
            {
                return "Mật khẩu không được để trống!";
            }

            if (string.IsNullOrEmpty(taiKhoan.Email))
            {
                return "Email không được để trống!";
            }

            if (string.IsNullOrEmpty(taiKhoan.SDT))
            {
                return "Số điện thoại không được để trống!";
            }

            if (kiemtramatrung(taiKhoan.Taikhoan) > 0)
            {
                return "Tài khoản đã tồn tại!";
            }

            if (dk.Them(taiKhoan))
            {
                return "Đăng kí thành công";
            }

            return "Đăng kí thất bại";
        }
    }
}