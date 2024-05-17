using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace DoAn1_10122390
{
    public partial class MUA : UserControl
    {
        public MUA()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.MUA_Load);
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

        public void LoadDataIntoComboBox()
        {
            DataTable dataTable = BUS1.getData1();
            cbbmanhanvien.DataSource = dataTable;
            cbbmanhanvien.DisplayMember = "MaNhanVien";
            cbbmanhanvien.ValueMember = "MaNhanVien";

            DataTable dataTable2 = BUS1.getData2();
            cbbmagiamgia.DataSource = dataTable2;
            cbbmagiamgia.DisplayMember = "MaGiamGia";
            cbbmagiamgia.ValueMember = "MaGiamGia";
        }

        public void MUA_Load(object sender, EventArgs e)
        {
            if (dgvSanpham != null)
            {
                loaddgv();
            }

            LoadDataIntoComboBox();
            dgvGioHang.CellValueChanged += dgvGioHang_CellValueChanged;
        }

        public void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanpham.Columns[e.ColumnIndex].Name == "Column5")
            {
                them.Enabled = true;

                dgvSanpham.Columns["Column5"].Visible = false;
                dgvGioHang.Rows.Add(dgvSanpham.Rows[e.RowIndex].Cells["Column1"].Value.ToString(),
                    dgvSanpham.Rows[e.RowIndex].Cells["Column2"].Value.ToString(),
                    dgvSanpham.Rows[e.RowIndex].Cells["Column3"].Value.ToString(), 0);
            }

            if (e.RowIndex >= 0 && e.RowIndex < dgvSanpham.Rows.Count)
            {
                DataGridViewRow hang = dgvSanpham.Rows[e.RowIndex];
                tbsLtrongkho.Text = hang.Cells["Column4"].Value.ToString();
                tbmasp.Text = hang.Cells["Column2"].Value.ToString();
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
        private int i;
        public void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "Column10")
            {
                dgvGioHang.Rows.RemoveAt(e.RowIndex);
                dgvSanpham.Columns["Column5"].Visible = true;
                them.Enabled = false;
                tbsLtrongkho.Text = string.Empty;
                tbmasp.Text = string.Empty;
                soluongmua = Convert.ToInt32(dgvSanpham[3, i].Value.ToString());
            }
            

        }
        public int TinhTongTien()
        {
            int tongTien = 0;

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (!row.IsNewRow)
                {
                    int giaTriSanPham = Convert.ToInt32(row.Cells["Column8"].Value);
                    int soLuong = Convert.ToInt32(row.Cells["Column9"].Value);

                    if (soLuong > 0)
                    {
                        tongTien += giaTriSanPham * soLuong;
                    }
                }
            }

            tbTong.Text = tongTien.ToString();
            return tongTien;
        }



        public void tbSoluong_ValueChanged(object sender, EventArgs e)
        {
            int giaTriMoi = (int)NUDSoluong.Value;

            int soLuongHienTai = dgvGioHang.CurrentRow.Cells["Column9"].Value == null
                ? 0
                : Convert.ToInt32(dgvGioHang.CurrentRow.Cells["Column9"].Value);
            if (giaTriMoi > soLuongHienTai)
            {
                dgvGioHang.CurrentRow.Cells["Column9"].Value = soLuongHienTai + 1;
            }
            else if (giaTriMoi < soLuongHienTai)
            {
                dgvGioHang.CurrentRow.Cells["Column9"].Value = soLuongHienTai - 1;
            }
        }





        public void guna2Button4_Click(object sender, EventArgs e)
        {
            string result = BUS2.ThemDonHang(dh);
            if (result == "1")
            {
                string maDonHangMoi = BUS2.LayMaDonHangMoi();
                MessageBox.Show("Đã thêm đơn hàng thành công. Mã đơn hàng mới là: " + maDonHangMoi, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbhoadon.Text = maDonHangMoi;
                dgvGioHang.Columns["Column10"].Visible = true;
                dgvSanpham.Columns["Column5"].Visible = true;
                p.Visible = true;
                them.Visible = true;
                cbbmagiamgia.Enabled = true;
                tbhoadon.Enabled = true;
                cbbmanhanvien.Enabled = true;

                btIn.Enabled = true;
                btThanhToan.Enabled = true;

                bttaomoi.Enabled = false;
            }
            else
            {
                MessageBox.Show("Thêm đơn hàng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int soluongmua;

        public void guna2Button2_Click(object sender, EventArgs e)
        {
            them.Enabled = false;
            DonHangDTO dh = new DonHangDTO();
            dgvSanpham.Columns["Column5"].Visible = true;
            dh.MaGiamGia = cbbmagiamgia.Text;
            dh.MaDonHang = tbhoadon.Text;
            int rowIndex = dgvGioHang.CurrentCell.RowIndex;
            dh.MaSanPham = dgvGioHang.Rows[rowIndex].Cells["Column7"].Value.ToString();
            dh.SoLuong = dgvGioHang.Rows[rowIndex].Cells["Column9"].Value.ToString();
            dh.MaNhanVien = cbbmanhanvien.Text;
            dh.Gia = tbTong.Text;

            SanPhamDTO sp = new SanPhamDTO();
            int sltrongkho;
            int soluongmua;
            int.TryParse(tbsLtrongkho.Text, out sltrongkho);
            int.TryParse(dh.SoLuong, out soluongmua);

            if (soluongmua > sltrongkho) 
            {
                DialogResult dialogResult = MessageBox.Show("Số lượng mua vượt quá số lượng trong kho!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    dgvGioHang.Rows.Clear();
                }

                return;
            }

            string result = BUS2.ThemChiTiet(dh);
            if (result == "2")
            {
                MessageBox.Show("Thông tin sản phẩm vào Giỏ Hàng Thành Công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dgvGioHang.Rows.Clear();
            }

            int slmoi = sltrongkho - soluongmua;
            sp.SoLuong = slmoi.ToString();
            sp.Masp = tbmasp.Text;
            string result1 = BUS2.Suasoluong(sp);
            if (result1 == "1")
            {
                MessageBox.Show($"Số Lượng Sản Phẩm Trong Kho Hiện Tại LÀ: {slmoi}");
                loaddgv();
                tbsLtrongkho.Text = string.Empty;
                tbmasp.Text = string.Empty;
            }
        }


        public void dgvGioHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvGioHang.Columns["Column9"].Index)
            {
                TinhTongTien();
                soluongmua = Convert.ToInt32(dgvGioHang.Rows[e.RowIndex].Cells["Column9"].Value);
            }
        }

   
       
    }

}
                                                                                                                                                        