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


namespace DAL
{
    public  class NhaCungCapDAL
    {
        CSDL_DAL csdl= new CSDL_DAL();
        public DataTable getData()
        {
            string sql = "Select * from NhaCungCap";
            return csdl.getData(sql);


        }
        public int LayMaNhaCungCapTiepTheo()
        {
            string sql = "SELECT ISNULL(MAX(MaNhaCungCap), 0) FROM NhaCungCap";
            int maNhaCungCapHienTai = csdl.LayGiaTri(sql);
            int maNhaCungCapMoi = maNhaCungCapHienTai + 1;
            return maNhaCungCapMoi;
        }

        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from NhaCungCap where MaNhaCungCap='" + ma.Trim() + "'";
            return csdl.KiemTraMaTrung(ma, sql);
        }
        public bool Themnhacc(NhaCungCapDTO ncc)
        {
            //string sql = string.Format("Insert into NhaCungCap values('{0}','{1}', '{2}', '{3}')", ncc.ManhaCC, ncc.Tennhacc, ncc.Diachi, ncc.SDT);
            //csdl.chaycodesql(sql);
            //return true;
            int maNhaCungCapMoi = LayMaNhaCungCapTiepTheo();
            string sql = string.Format("INSERT INTO NhaCungCap  VALUES ('{0}', N'{1}', N'{2}', '{3}')",
                maNhaCungCapMoi, ncc.Tennhacc, ncc.Diachi, ncc.SDT);
            csdl.chaycodesql(sql);
            return true;
        }
        public bool Suanhacc(NhaCungCapDTO ncc)
        {
            string sql = string.Format("UPDATE NhaCungCap SET TenNhaCungCap = N'{0}', DiaChi = N'{1}', SoDienThoai = '{2}' WHERE MaNhaCungCap = '{3}'",ncc.Tennhacc,ncc.Diachi,ncc.SDT,ncc.ManhaCC );
            csdl.chaycodesql(sql);
            return true;
        }
        public bool Xoanhacc(string ma)
        {
            string sql = string.Format("DELETE FROM NhaCungCap WHERE MaNhaCungCap = '{0}'", ma);
            csdl.chaycodesql(sql);
            return true;
        }
        public DataTable TimKiem(string keyword)
        {
            string sql = string.Format("SELECT * FROM NhaCungCap WHERE MaNhaCungCap LIKE '%{0}%' OR TenNhaCungCap LIKE '%{0}%'", keyword);
            return csdl.getData(sql);
        }
    }
}
