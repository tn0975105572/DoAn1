﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Security.Policy;

namespace BUS
{
    public class BUS_DangNhap
    {

        DAL_DangNhap DAL_DangNhap = new DAL_DangNhap();
    
        public DataTable getData(string sql)
        {
            return DAL_DangNhap.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_DangNhap.Check(ma);
        }

        public string KiemTraDangNhap(string Taikhoan, string Matkhau)
        {
            if (string.IsNullOrEmpty(Taikhoan) || string.IsNullOrEmpty(Matkhau))
            {
                throw new Exception("Tên đăng nhập và mật khẩu không được để trống.");
            }
            else
            {
                bool isAuthenticated = DAL_DangNhap.KiemTraDangNhap(Taikhoan, Matkhau);

                if (!isAuthenticated)
                {
                    return "Thông tin đăng nhập không chính xác!";
                }

                return "Đăng nhập thành công.";
            }
        }


    }
}
