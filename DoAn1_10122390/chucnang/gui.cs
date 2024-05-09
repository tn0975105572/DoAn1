using BUS;
using DoAn1_10122390.chucnang;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoAn1_10122390.chucnang
{
    public partial class SanPham : UserControl
    {
        public SanPham()
        {
            InitializeComponent();
        }
        SanPhamBUS BUS = new SanPhamBUS();
        
        private void bttThem_Click(object sender, EventArgs e)
        {
           
        }
       
        void loaddgv()
        {

            dgvSanpham.DataSource = BUS.getData();
            dgvSanpham.Columns[0].HeaderText = "Mã SP ";
            dgvSanpham.Columns[1].HeaderText = "Tên SP";
            dgvSanpham.Columns[2].HeaderText = "Giá";
            dgvSanpham.Columns[3].HeaderText = "Mô Tả";
            dgvSanpham.Columns[4].HeaderText = "Mã Cung Cấp ";
            dgvSanpham.Columns[5].HeaderText = "Số lượng ";
            dgvSanpham.Columns[6].HeaderText = "Hình ảnh";
           dgvSanpham.Columns[0].DefaultCellStyle.Font = new Font("Arial", 10);
           dgvSanpham.Columns[1].DefaultCellStyle.Font = new Font("Arial", 10);
           dgvSanpham.Columns[2].DefaultCellStyle.Font = new Font("Arial", 10);
           dgvSanpham.Columns[3].DefaultCellStyle.Font = new Font("Arial", 10);
           dgvSanpham.Columns[4].DefaultCellStyle.Font = new Font("Arial", 10);
           dgvSanpham.Columns[5].DefaultCellStyle.Font = new Font("Arial", 10);
           dgvSanpham.Columns[6].DefaultCellStyle.Font = new Font("Arial", 10);
        }
        public void SanPham_Load(object sender, EventArgs e)
        {
            loaddgv();

        }

      

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files (*.gif; *.jpg; *.jpeg; *.bmp)|*.gif;*.jpg;*.jpeg;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.ImageLocation = openFileDialog.FileName;
            }
        }

        private void dgvSanpham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
    }
}
