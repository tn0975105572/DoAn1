﻿using DAL;
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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlDataAdapter dtadt;
        DataTable dttb;


        string diachi = @"Data Source=DUYTUAN;Initial Catalog=olodo;Integrated Security=True;";

        void ketnoi()
        {
            cn = new SqlConnection(diachi);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        void ngatketnoi()
        {
            cn = new SqlConnection(diachi);
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        void taidulieupkn()
        {
            ketnoi();
            string chon = "SELECT ChiTietDonHang.MaSanPham, ChiTietDonHang.SoLuong, ChiTietDonHang.Gia, ChiTietDonHang.MaNhanVien, ChiTietDonHang.MaChiTietHoaDon, DonHang.MaDonHang, DonHang.MaKhachHang, DonHang.NgayDat, \r\n                  DonHang.TongTien\r\nFROM     ChiTietDonHang INNER JOIN\r\n                  DonHang ON ChiTietDonHang.MaDonHang = DonHang.MaDonHang";
            dtadt = new SqlDataAdapter(chon, cn);
            dttb = new DataTable();
            dttb.Clear();
            dtadt.Fill(dttb);
            ngatketnoi();
            
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            taidulieupkn();
            CrystalReport1 rp = new CrystalReport1();
            rp.SetDataSource(dttb);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
        }
    }
}