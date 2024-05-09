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
    public partial class KhachHang : UserControl
    {
        private string olodo;
        public KhachHang()
        {
            InitializeComponent();
        }
        KhachHangBUS BUS = new KhachHangBUS();
        void loaddgv()
        {

            dgvkhachhang.DataSource = BUS.getData();

            dgvkhachhang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvkhachhang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvkhachhang.Columns[2].HeaderText = "Địa chỉ";
            dgvkhachhang.Columns[3].HeaderText = "Sổ điện thoại";
            dgvkhachhang.Columns[4].HeaderText = "Email";

            dgvkhachhang.Columns[0].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvkhachhang.Columns[1].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvkhachhang.Columns[2].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvkhachhang.Columns[3].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvkhachhang.Columns[4].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvkhachhang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);

        }

       

        private void KhachHang_Load(object sender, EventArgs e)
        {
            loaddgv();
            tbMa.ReadOnly = true;


        }

        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvkhachhang.Rows.Count)
            {
                int i = e.RowIndex;
                olodo = dgvkhachhang[0, i].Value.ToString();
                tbMa.Text = dgvkhachhang[0, i].Value.ToString();
                tbTen.Text = dgvkhachhang[1, i].Value.ToString();
                tbDiachi.Text = dgvkhachhang[2, i].Value.ToString();
                tbSDT.Text = dgvkhachhang[3, i].Value.ToString();
                tbEmail.Text = dgvkhachhang[4, i].Value.ToString();
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            int count = dgvkhachhang.Rows.Count;

            if (count > 0)
            {

                int lastEmployeeID = Convert.ToInt32(dgvkhachhang.Rows[count - 1].Cells[0].Value);
                int nextEmployeeID = lastEmployeeID + 1;
                string newEmployeeID = nextEmployeeID.ToString();
                tbMa.Text = newEmployeeID;

            }
            else
            {
                tbMa.Text = "1";
            }
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = tbMa.Text;
            kh.TenKH = tbTen.Text;
            kh.DiaChi = tbDiachi.Text;
            kh.SDT = tbSDT.Text;
            kh.Email=tbEmail.Text;
            string result = BUS.Themhk(kh);
            //if (result == "Mã khách hàng đã được đăng kí.")
            //{
            //    MessageBox.Show("Mã Khách hàng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            if (result == "Thêm thành công.")
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvkhachhang.DataSource = BUS.getData();
                ClearFields();
                loaddgv();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            tbMa.Text = "";
            tbTen.Text = "";

            tbDiachi.Text = "";
            tbSDT.Text = "";
            tbEmail.Text = "";

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = olodo;
            kh.TenKH = tbTen.Text;
            kh.DiaChi = tbDiachi.Text;
            kh.SDT = tbSDT.Text;
            kh.Email = tbEmail.Text;
            string result = BUS.Suankh(kh);
            if (result == "Sửa thông tin thành công.")
            {

                MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvkhachhang.DataSource = BUS.getData();
                ClearFields();
                loaddgv();
            }
            else
            {
                MessageBox.Show("Sửa thông tin khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            string maKh = tbMa.Text;
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này ra khỏi danh sách khách hàng công ty không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = maKh;

                string result = BUS.XoanKH(kh);
                if (result == "Xóa Khách Hàng này thành công.")
                {
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvkhachhang.DataSource = BUS.getData();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btmoi_Click(this, EventArgs.Empty);
                }
            }
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            loaddgv();
        }

        private void bttim_Click(object sender, EventArgs e)
        {
            string keyword = tbtim.Text;
            DataTable searchResult = BUS.TimKiemKhachHang(keyword);

            if (searchResult.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào phù hợp với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvkhachhang.DataSource = searchResult;
            }
            if (string.IsNullOrWhiteSpace(tbtim.Text))
            {
                errorProvider1.SetError(tbtim, "Nếu bạn bỏ trống thông tin chúng tôi không thể tìm kiếm !");
            }
            else
            {
                errorProvider1.SetError(tbtim, null);
            }
        }
    }
}
