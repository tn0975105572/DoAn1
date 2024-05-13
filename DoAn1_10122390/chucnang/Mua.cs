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
    public partial class MUA : UserControl
    {
        public MUA()
        {
            InitializeComponent();
        }
        SanPhamBUS BUS = new SanPhamBUS();
        ChamCongBUS BUS1 = new ChamCongBUS();
        DonHangBUS BUS2 = new DonHangBUS();
        DonHangDTO dh = new DonHangDTO();
        void loaddgv()
        {
           

            dgvSanpham.DataSource = BUS.Lay();
            dgvSanpham.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14);
            foreach (DataGridViewColumn column in dgvSanpham.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Arial", 14);
            }



            dgvGioHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvGioHang.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            foreach (DataGridViewColumn column in dgvGioHang.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Arial", 10);
            }


        }
        private void LoadDataIntoComboBox()
        {

            DataTable dataTable = BUS1.getData1();


            cbbnhanvien.DataSource = dataTable;
            cbbnhanvien.DisplayMember = "MaNhanVien";
            cbbnhanvien.ValueMember = "MaNhanVien";
            DataTable dataTable1 = BUS1.getData2();





            cbbkhachhang.DataSource = dataTable1;
            cbbkhachhang.DisplayMember = "MaKhachHang";
            cbbkhachhang.ValueMember = "MaKhachHang";
        }

        public void MUA_Load(object sender, EventArgs e)
        {
            if (dgvSanpham != null)
            {
                loaddgv();
            }

            LoadDataIntoComboBox();


        }

        public void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanpham.Columns[e.ColumnIndex].Name == "Column4")
            {


                dgvGioHang.Rows.Add(dgvSanpham.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvSanpham.Rows[e.RowIndex].Cells[2].Value.ToString(), dgvSanpham.Rows[e.RowIndex].Cells["Column9"].Value.ToString());
            }
            
        }



        public void guna2Button1_Click(object sender, EventArgs e)
        {
            dgvGioHang.Rows.Clear();
        }


        public void guna2Button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); 
            HoaDon hd = new HoaDon();
            
            hd.ShowDialog();
        }

        public void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "Column8")
            {
                dgvGioHang.Rows.RemoveAt(e.RowIndex);
            }
          
        }
        public int TinhTongTien()
        {
            int tongTien = 0;

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (!row.IsNewRow)
                {
                    int giaTriSanPham = Convert.ToInt32(row.Cells["Column6"].Value); 
                    int soLuong = Convert.ToInt32(row.Cells["Column7"].Value); 

                    tongTien += giaTriSanPham * soLuong;
                }
            }

            return tongTien;
        }

        public void tbSoluong_ValueChanged(object sender, EventArgs e)
        {
            int giaTriMoi = (int)NUDSoluong.Value;

            int soLuongHienTai = dgvGioHang.CurrentRow.Cells["Column7"].Value == null ? 0 : Convert.ToInt32(dgvGioHang.CurrentRow.Cells["Column7"].Value);
            if (giaTriMoi > soLuongHienTai)
            {
                dgvGioHang.CurrentRow.Cells["Column7"].Value = soLuongHienTai + 1;
            }
            else if (giaTriMoi < soLuongHienTai)
            {
                dgvGioHang.CurrentRow.Cells["Column7"].Value = soLuongHienTai - 1;
            }
        }

     

   

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string result = BUS2.ThemDonHang(dh);
            if (result == "1")
            {
                string maDonHangMoi = BUS2.LayMaDonHangMoi();
                MessageBox.Show("Đã thêm đơn hàng thành công. Mã đơn hàng mới là: " + maDonHangMoi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbhoadon.Text = maDonHangMoi;
                dgvGioHang.Columns["Column8"].Visible = true;
                dgvSanpham.Columns["Column4"].Visible = true;
                p.Visible = true;
                them.Visible = true;

                tbmachitiethoadon.Enabled = true;
                tbhoadon.Enabled = true;
                dtpkngaydat.Enabled = true;
                cbbnhanvien.Enabled = true;
                cbbkhachhang.Enabled = true;
                btIn.Enabled = true;
                btThanhToan.Enabled = true;
                them.Enabled = true;
                bttaomoi.Enabled= false;
            }
            else
            {
                MessageBox.Show("Thêm đơn hàng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int tongTien = TinhTongTien();
            tbTong.Text = tongTien.ToString("N0");
           
        }
    }
}
                                                                                                                                                     