using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace DoAn1_10122390
{
    public partial class MUA : UserControl
    {

        /*  _____     __  __     __  __     ______   __  __     ______     __   __    */
        /* /\  __-.  /\ \/\ \   /\ \_\ \   /\__  _\ /\ \/\ \   /\  __ \   /\ "-.\ \   */
        /* \ \ \/\ \ \ \ \_\ \  \ \____ \  \/_/\ \/ \ \ \_\ \  \ \  __ \  \ \ \-.  \  */
        /*  \ \____-  \ \_____\  \/\_____\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\\"\_\ */
        /*   \/____/   \/_____/   \/_____/     \/_/   \/_____/   \/_/\/_/   \/_/ \/_/ */



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

            dtNgay.Value = DateTime.Now;

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

            DataTable dataTable3 = BUS2.hienKh();
            cbbkh.DataSource = dataTable3;
            cbbkh.DisplayMember = "MaKhachHang";
            cbbkh.ValueMember = "MaKhachHang";

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
                int soLuongTrongKho = Convert.ToInt32(dgvSanpham.Rows[e.RowIndex].Cells["Column4"].Value);
                if (soLuongTrongKho == 0)
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                them.Enabled = true;
                NUDSoluong.Enabled=true;

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

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            DonHangDTO dh = new DonHangDTO();
                            dh.MaChiTietHoaDon = tbhoadon.Text; 

                            DataTable dataTable = BUS2.Hien(dh); 
                            string sheetName = tbhoadon.Text; 
                            workbook.Worksheets.Add(dataTable, sheetName);
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Lưu thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred: " + ex.Message);
                    }
                }
            }
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

            
            string maGiamGia = cbbmagiamgia.SelectedValue.ToString();
            switch (maGiamGia)
            {
                case "1":
                    tongTien -= 10000;
                    break;
                case "2":
                    tongTien -= 25000;
                    break;
                case "3":
                    tongTien -= 50000;
                    break;
                case "4":
                    tongTien -= 100000;
                    break;
                default:
                    break;
            }
            if (tongTien < 0)
            {
                tongTien = 0;
            }
            tbTong.Text = tongTien.ToString();
            return tongTien;
        }

        public void tbSoluong_ValueChanged(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null && dgvGioHang.CurrentRow.Cells["Column9"].Value != null)
            {
                int giaTriMoi = (int)NUDSoluong.Value;

                int soLuongHienTai = Convert.ToInt32(dgvGioHang.CurrentRow.Cells["Column9"].Value);
                if (giaTriMoi > soLuongHienTai)
                {
                    dgvGioHang.CurrentRow.Cells["Column9"].Value = soLuongHienTai + 1;
                }
                else if (giaTriMoi < soLuongHienTai)
                {
                    dgvGioHang.CurrentRow.Cells["Column9"].Value = soLuongHienTai - 1;
                }
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
                dtNgay.Enabled = true;
                tbhoadon.Enabled = true;
                cbbmanhanvien.Enabled = true;
                btIn.Enabled = true;
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
            if (NUDSoluong.Value == 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng sản phẩm để mua.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btThanhToan.Enabled = true;
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
            dh.NgayDat = dtNgay.Value;
            dh.MaKhachHang = cbbkh.Text;
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

            string result3 = BUS2.ThemNgayDat(dh);
            string result = BUS2.ThemChiTiet(dh);
            if (result == "2")
            {
                MessageBox.Show("Thông tin sản phẩm vào Giỏ Hàng Thành Công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dgvGioHang.Rows.Clear();
                NUDSoluong.Enabled = false;
                NUDSoluong.Value = 0;
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

        private void btThanhToan_Click(object sender, EventArgs e)
        {
           
            Form2 f = new Form2();
            f.Show();

        }


        private void cbbmagiamgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }
    }

}
                                                                                                                                                        