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
    public class NhanVienBUS
    {
        NhanvienDAL them = new NhanvienDAL();
        public DataTable getData()
        {
            return them.getData();
        }
        public int kiemtramatrung(string ma)
        {
            return them.kiemtramatrung(ma);
        }
        public int LayMaNhanVienTiepTheo()
        {
            return them.LayMaNhanVienTiepTheo();
        }
        public string  Themnv(NhanVienDTO nv)

        {
            //if (kiemtramatrung(nv.Manv) > 0)
            //{
            //    return "Nhân Viên này đã có!";
            //}
            if (them.Themnv(nv))
            {
                return "Đăng kí thành công";
            }

            return "Đăng kí thất bại";

        }
        public string Xoanv(string ma)
        {
            if (them.Xoanv(ma))
            {
                return "Xóa nhân viên thành công";
            }
            else
            {
                return "Xóa nhân viên thất bại";
            }
        }

        public string Suanv(NhanVienDTO nv)
        {
            if (them.Suavn(nv))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public DataTable TimKiemNhanVien(string keyword)
        {
            return them.TimKiemNhanVien(keyword);
        }




    }
}
