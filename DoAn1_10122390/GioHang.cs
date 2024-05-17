using BUS;
using DoAn1_10122390.chucnang;
using DTO;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAn1_10122390
{
    public partial class GioHang : Form
    {
        public GioHang()
        {
            InitializeComponent();
           

        }
        DonHangBUS BUS = new DonHangBUS();
        DonHangDTO dh = new DonHangDTO();
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string result = BUS.ThemDonHang(dh);
            if (result == "1")
            {
                string maDonHangMoi = BUS.LayMaDonHangMoi();
                MessageBox.Show("Đã thêm đơn hàng thành công. Mã đơn hàng mới là: " + maDonHangMoi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thêm đơn hàng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
