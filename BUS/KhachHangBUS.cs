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
    public class KhachHangBUS
    {
       KhachHangDAL kh = new KhachHangDAL();
       public DataTable getData()
       {
           return kh.getData();
       }
       public int kiemtramatrung(string ma)
       {
           return kh.kiemtramatrung(ma);
       }
       public string Themhk(KhachHangDTO Them)
       {
           //if (kiemtramatrung(Them.MaKH) > 0)
           //{
           //    return "Mã khách hàng đã được đăng kí.";
           //}
           /*else*/ if (kh.ThemKhachHang(Them))
           {
               return "Thêm thành công.";
           }
           return "Thêm Thất Bại";
       }
       public string Suankh(KhachHangDTO Sua)
       {
           if (kh.SuanKhachHang(Sua))
           {
               return "Sửa thông tin thành công.";
           }
           return "Sửa thông tin thất bại.";
        }

       public string XoanKH(KhachHangDTO Xoa)
       {
           if (kh.XoaKhachHang(Xoa.MaKH))
           {
               return "Xóa khách hàng thành công.";
           }
           return "Xóa khách hàng thất bại.";
        }
       public DataTable TimKiemKhachHang(string keyword)
       {
           return kh.TimKiem(keyword);
       }
    }
}
