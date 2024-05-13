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
using DocumentFormat.OpenXml.Drawing;

namespace BUS
{
    public class LuongBUS
    {
        LuongDAL Luong = new LuongDAL();
        public DataTable getData()
        {
            return Luong.getData();
        }
        public DataTable getData1()
        {
            return Luong.getData1();
        }
        public string Themnv(NhanVienDTO nv)

        {

            if (Luong.ThemLuong(nv))
            {
                return "1";
            }

            return "2";

        }
        public string XoaLuong(NhanVienDTO nv)
        {
            if (Luong.XoaLuong(nv))
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }

        public string SuaLuong(NhanVienDTO nv)
        {
            if (Luong.SuaLuong(nv))
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }
        public DataTable TimKiemLuong(string keyword)
        {
            return Luong.TimKiemLuong(keyword);
        }
    }
}
