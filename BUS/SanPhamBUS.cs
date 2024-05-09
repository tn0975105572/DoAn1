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
    public class SanPhamBUS
    {
        SanPhamDAL sp = new SanPhamDAL();
        public DataTable getData()
        {
            return sp.getData();
        }
        public DataTable getData1()
        {
            return sp.getData1();
        }

        public DataTable Laydulieu()
        {
            return sp.LayDanhSachMaVaTenSanPham();
        }

        public int kiemtramatrung(string ma)
        {
            return sp.kiemtramatrung(ma);
        }
        public string Themsp(SanPhamDTO them)

        {
            if (sp.Themsp(them))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string Suasp(SanPhamDTO sua)
        {
            if (sp.Suasp(sua))
            {
                return "Sửa thành công";
            }
            return "Sửa thất bại";
        }

        public string Xoasp(SanPhamDTO xoa)
        {
            if (sp.Xoanv(xoa))
            {
                return "Xóa thành công";
            }
            return "Xóa thất bại";
        }

        public DataTable Timso(SanPhamDTO tk)
        {
            return sp.TimKiemSP(tk);
        }
        public string Suasoluong(int olodo, int olodo2)
        {
            if (sp.Suasoluong(olodo, olodo2))
            {
                return "Nhập kho thành công";
            }
            return "Nhập kho thất bại";
        }


    }
}
