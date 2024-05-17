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
        public DataTable getData2()
        {

            string sql = "SELECT MaGiamGia FROM MaGiamGia";
            return csdl.getData(sql);
        }
        public int LayMaCCTiepTheo()
        {
            string sql = "SELECT ISNULL(MAX(Macc), 0) FROM ChiTietChamCong";
            int maBangLuonght = csdl.LayGiaTri(sql);
            int mamoi = maBangLuonght + 1;
            return mamoi;
        }

        public bool ThemCC(ChamCongDTO cc)
        {
            int mamoi = LayMaCCTiepTheo();
            string sql = string.Format("Insert into ChiTietChamCong values('{0}','{1}', '{2}')", mamoi, cc.Mavn,  cc.Ngaycc.ToString("yyyy-MM-dd"));
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
