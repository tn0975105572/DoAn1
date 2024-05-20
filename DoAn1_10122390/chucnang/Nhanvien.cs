using BUS;
using DoAn1_10122390.chucnang;
using DTO;
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
using static System.Net.WebRequestMethods;

namespace DoAn1_10122390
{
    public partial class Nhanvien : UserControl
    {


        /*  _____     __  __     __  __     ______   __  __     ______     __   __    */
        /* /\  __-.  /\ \/\ \   /\ \_\ \   /\__  _\ /\ \/\ \   /\  __ \   /\ "-.\ \   */
        /* \ \ \/\ \ \ \ \_\ \  \ \____ \  \/_/\ \/ \ \ \_\ \  \ \  __ \  \ \ \-.  \  */
        /*  \ \____-  \ \_____\  \/\_____\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\\"\_\ */
        /*   \/____/   \/_____/   \/_____/     \/_/   \/_____/   \/_/\/_/   \/_/ \/_/ */


        public Nhanvien()
        {
            InitializeComponent();
        }


       
        NhanVienBUS BUS = new NhanVienBUS();
       

        void loaddgv()
        {
           
            dgvNhanvien.DataSource = BUS.getData();
            dgvNhanvien.Columns[0].HeaderText = "Mã NV ";
            dgvNhanvien.Columns[1].HeaderText = "Tên NV";
            dgvNhanvien.Columns[2].HeaderText = "GioiTinh";
            dgvNhanvien.Columns[3].HeaderText = "NgaySinh";
            dgvNhanvien.Columns[4].HeaderText = "Địa Chỉ";
            dgvNhanvien.Columns[5].HeaderText = "SĐT";
            dgvNhanvien.Columns[6].HeaderText = "Email";

            dgvNhanvien.Columns[0].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvNhanvien.Columns[1].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvNhanvien.Columns[2].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvNhanvien.Columns[3].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvNhanvien.Columns[4].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvNhanvien.Columns[5].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvNhanvien.Columns[6].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);
        }



        private void Nhanvien_Load(object sender, EventArgs e)
        {
            loaddgv();

            tbMa.ReadOnly = true;



        }

  

        public void bttThem_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(tbTen.Text) || cbGioiTinh.SelectedItem == null || string.IsNullOrEmpty(tbDiachi.Text) || string.IsNullOrEmpty(tbSDT.Text) || string.IsNullOrEmpty(tbEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int count = dgvNhanvien.Rows.Count;

                if (count > 0)
                {
                    int lastEmployeeID = Convert.ToInt32(dgvNhanvien.Rows[count - 1].Cells[0].Value);
                    int nextEmployeeID = lastEmployeeID + 1;
                    tbMa.Text = nextEmployeeID.ToString();
                }
                else
                {
                    tbMa.Text = "1";
                }

                NhanVienDTO nv = new NhanVienDTO();

               
                nv.Tennv = tbTen.Text;
                nv.Gioitinh = cbGioiTinh.SelectedItem.ToString();
                nv.Ngaysinh = dtNgay.Value;
                nv.Diachi = tbDiachi.Text;
                nv.Sodienthoai = tbSDT.Text;
                nv.Email = tbEmail.Text;

                string result = BUS.Themnv(nv);
                if (result == "Đăng kí thành công")
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanvien.DataSource = BUS.getData();
                    ClearFields();
                    loaddgv();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ClearFields()
        {
            tbMa.Text = "";
            tbTen.Text = "";
            cbGioiTinh.SelectedIndex = -1;
            dtNgay.Value = DateTime.Now;
            tbDiachi.Text = "";
            tbSDT.Text = "";
            tbEmail.Text = "";
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.Manv = tbMa.Text;
            nv.Tennv = tbTen.Text;
            nv.Gioitinh = cbGioiTinh.SelectedItem.ToString();
            nv.Ngaysinh = dtNgay.Value;
            nv.Diachi = tbDiachi.Text;
            nv.Sodienthoai = tbSDT.Text;
            nv.Email = tbEmail.Text;

            string result = BUS.Suanv(nv);
            if (result == "Sửa thành công")
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNhanvien.DataSource = BUS.getData();
                ClearFields();
                loaddgv();
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string maNV = tbMa.Text;
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string result = BUS.Xoanv(maNV);
                if (result == "Xóa nhân viên thành công")
                {
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanvien.DataSource = BUS.getData();
                    ClearFields();
                    loaddgv();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = tbtimkiem.Text;
           

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataTable searchResult = BUS.TimKiemNhanVien(keyword);

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvNhanvien.DataSource = searchResult;
                }
            }
        }

        private void btchamcong_Click(object sender, EventArgs e)
        {
           
        }

       

        private void btMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            loaddgv();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            ChamCong cc = new ChamCong();
            cc.Show();
        }

        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanvien.Rows.Count)
            {
                int i = e.RowIndex;
                tbMa.Text = dgvNhanvien[0, i].Value.ToString();
                tbTen.Text = dgvNhanvien[1, i].Value.ToString();
                cbGioiTinh.Text = dgvNhanvien[2, i].Value.ToString();
                dtNgay.Text = dgvNhanvien[3, i].Value.ToString();
                tbDiachi.Text = dgvNhanvien[4, i].Value.ToString();
                tbSDT.Text = dgvNhanvien[5, i].Value.ToString();
                tbEmail.Text = dgvNhanvien[6, i].Value.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LuongNhanVien l = new LuongNhanVien();
            l.Show();
        }
    }
}

