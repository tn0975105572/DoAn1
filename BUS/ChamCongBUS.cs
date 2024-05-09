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
using System.Data.SqlTypes;

namespace BUS
{
    public class ChamCongBUS
    {
        ChamCongDAL cc = new ChamCongDAL();
        public DataTable getData()
        {
            return cc.getData();
        }
        public DataTable getData1()
        {
            return cc.getData1();
        }


        public int kiemtramatrung(string ma, DateTime ngayChamCong)
        {
            
            return cc.kiemtramatrung(ma, ngayChamCong);
        }
        public string Themcc(ChamCongDTO dto)
        {
            int count = cc.kiemtramatrung(dto.Mavn, dto.Ngaycc);

            if (count > 0)
            {
                return "Mã nhân viên và ngày chấm công đã tồn tại!";
            }
            else
            {
                cc.ThemCC(dto);
                return "Thêm chấm công thành công!";
            }

        }
        public string Xoacc(ChamCongDTO dto)
        {
            cc.XoaCC(dto);
            return "Xóa chấm công thành công!";
        }
       
        public DataTable TimKiemCC(string maNhanVien, DateTime ngayChamCong)
        {
            return cc.TimKiemNhanVien(maNhanVien, ngayChamCong);
        }

    }
}
