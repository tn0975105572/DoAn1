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

        public DataTable getData2()
        {
            return cc.getData2();
        }

        public string Themcc(ChamCongDTO dto)
        {
          
           
            
                cc.ThemCC(dto);
                return "Thêm chấm công thành công!";
           

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
