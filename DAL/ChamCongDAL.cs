using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using DocumentFormat.OpenXml.Math;

namespace DAL
{
    public class ChamCongDAL
    {
        CSDL_DAL csdl = new CSDL_DAL();
        public DataTable getData()
        {
            
            string sql = "Select * from ChiTietChamCong";
            return csdl.getData(sql);

        }
        public DataTable getData1()
        {
            
            string sql = "SELECT MaNhanVien FROM NhanVien"; 
            return csdl.getData(sql);
        }

        public int kiemtramatrung(string ma, DateTime ngayChamCong)
        {
            string sql = $"SELECT COUNT(*) FROM ChiTietChamCong WHERE MaNhanVien = '{ma}' AND NgayChamCong = '{ngayChamCong.ToString("yyyy-MM-dd")}'";
            return csdl.KiemTraMaTrung(ma, sql);
        }
        public bool ThemCC(ChamCongDTO cc)
        {
            string sql = string.Format("Insert into ChiTietChamCong values('{0}','{1}', '{2}')", cc.Macc, cc.Mavn,  cc.Ngaycc.ToString("yyyy-MM-dd"));
            csdl.chaycodesql(sql);
            return true;

        }
        public bool XoaCC(ChamCongDTO cc)
        {
            string sql = string.Format("DELETE FROM ChiTietChamCong WHERE MAcc = '{0}'", cc.Macc);
            csdl.chaycodesql(sql);
            return true;
        }
       
        public DataTable TimKiemNhanVien(string keyword, DateTime ngayChamCong)
        {
            string sql = string.Format("SELECT * FROM ChiTietChamCong WHERE MaNhanVien LIKE '%{0}%' AND NgayChamCong = '{1}'", keyword, ngayChamCong.ToString("yyyy-MM-dd"));
            return csdl.getData(sql);
        }
        
       


    }
}
