using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1_10122390
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //SqlConnection cn;
        //SqlCommand cm;
        //SqlDataReader dtrd;
        //SqlDataAdapter dtadt;
        //DataTable dttb;

        //string diachi = @"Data Source=DUYTUAN;Initial Catalog=olodo;Integrated Security=True;";

        //void ketnoi()
        //{
        //    cn = new SqlConnection(diachi);
        //    if (cn.State == ConnectionState.Closed)
        //    {
        //        cn.Open();
        //    }
        //}

        //void ngatketnoi()
        //{
        //    cn = new SqlConnection(diachi);
        //    if (cn.State == ConnectionState.Open)
        //    {
        //        cn.Close();
        //    }
        //}

        //void taidulieupkn()
        //{
        //    ketnoi();
        //    string chon = "SELECT DonHang.MaDonHang, DonHang.MaKhachHang, DonHang.NgayDat, DonHang.TongTien, ChiTietDonHang.MaSanPham, ChiTietDonHang.SoLuong, ChiTietDonHang.Gia, ChiTietDonHang.MaNhanVien, \r\n                  ChiTietDonHang.MaChiTietHoaDon\r\nFROM     ChiTietDonHang INNER JOIN\r\n                  DonHang ON ChiTietDonHang.MaDonHang = DonHang.MaDonHang";
        //    dtadt = new SqlDataAdapter(chon, cn);
        //    dttb = new DataTable();
        //    dttb.Clear();
        //    dtadt.Fill(dttb);
        //    ngatketnoi();
        //}

        //void chaylenhsql(string querysql)
        //{
        //    ketnoi();
        //    cm = new SqlCommand(querysql, cn);
        //    cm.ExecuteNonQuery();
        //    ngatketnoi();
        //}
        private void Form2_Load(object sender, EventArgs e)
        {
            //taidulieupkn();
            //if (dttb.Rows.Count > 0)
            //{
            //    CrystalReport1 rp = new CrystalReport1();
            //    rp.SetDataSource(dttb);


            //    crystalReportViewer1.ReportSource = rp;
            //    crystalReportViewer1.Refresh();
            //}
            //else
            //{
            //    MessageBox.Show("No data available to display in the report.");
            //}
   

        }
    }
}
