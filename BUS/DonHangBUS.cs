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
    public class DonHangBUS
    {
        private DonHangDAL dh = new DonHangDAL();
        public string ThemDonHang(DonHangDTO dto)
        {
            dh.ThemDonHang(dto);
            return "1";
        }
        public string ThemChiTietDonHang(DonHangDTO dto)
        {
            dh.ThemChiTietDonHang(dto);
            return "1";
        }

        public DataTable GetData()
        {
            return dh.getData();
        }
        public string LayMaDonHangMoi()
        {
            DataTable dt = GetData();
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["MaxMaDonHang"].ToString();
            }
            return "1";
        }
    }
}
