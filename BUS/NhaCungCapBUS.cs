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
    public class NhaCungCapBUS
    {
        NhaCungCapDAL ncc = new NhaCungCapDAL();
        public DataTable getData()
        {
            return ncc.getData();
        }
        public int kiemtramatrung(string ma)
        {
            return ncc.kiemtramatrung(ma);
        }
        public string Themnhacc(NhaCungCapDTO Them)
        {
            //if (kiemtramatrung(Them.ManhaCC) > 0)
            //{
            //    return "Mã nhà cung cấp đã được đăng kí.";
            //}
            /*else*/ if (ncc.Themnhacc(Them))
            {
                return "Thêm nhà cung cấp thành công.";
            }
            return "Thêm Nhà Cung Cấp Thất Bại";
        }

        public string Suanhacc(NhaCungCapDTO nccDTO)
        {
            if (ncc.Suanhacc(nccDTO) )
            {
                return "Sửa thông tin nhà cung cấp thành công.";
            }
            else
            {
                return "Sửa thông tin nhà cung cấp thất bại.";
            }
        }

        public string Xoanhacc(NhaCungCapDTO nccDTO)
        {
            if (ncc.Xoanhacc(nccDTO.ManhaCC))
            {
                return "Xóa nhà cung cấp thành công.";
            }
            else
            {
                return "Xóa nhà cung cấp thất bại.";
            }
        }
        public DataTable TimKiemNhanVien(string keyword)
        {
            return ncc .TimKiem(keyword);
        }
    }
}
