using BUS;
using DoAn1_10122390.chucnang;
using DTO;
using Guna.UI2.WinForms;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAn1_10122390
{
    public partial class NhaCungCap : UserControl
    {

        /*  _____     __  __     __  __     ______   __  __     ______     __   __    */
        /* /\  __-.  /\ \/\ \   /\ \_\ \   /\__  _\ /\ \/\ \   /\  __ \   /\ "-.\ \   */
        /* \ \ \/\ \ \ \ \_\ \  \ \____ \  \/_/\ \/ \ \ \_\ \  \ \  __ \  \ \ \-.  \  */
        /*  \ \____-  \ \_____\  \/\_____\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\\"\_\ */
        /*   \/____/   \/_____/   \/_____/     \/_/   \/_____/   \/_/\/_/   \/_/ \/_/ */


        public NhaCungCap()
        {
            InitializeComponent();
        }
        NhaCungCapBUS BUS = new NhaCungCapBUS();
        void loaddgv()
        {

            dgvnhacungcap.DataSource = BUS.getData();

            dgvnhacungcap.Columns[0].HeaderText = "Mã Nhà Cung Cấp ";
            dgvnhacungcap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvnhacungcap.Columns[2].HeaderText = "Địa chỉ";
            dgvnhacungcap.Columns[3].HeaderText = "Sổ điện thoại";

            dgvnhacungcap.Columns[0].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvnhacungcap.Columns[1].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvnhacungcap.Columns[2].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvnhacungcap.Columns[3].DefaultCellStyle.Font = new Font("Arial", 10);
            dgvnhacungcap.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);

        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            loaddgv();
            if ((Quyen.tk == "admin") || (Quyen.tk == "123"))
            {
                MessageBox.Show("Chào mừng Quản Lý", "Chào Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                btsua.Enabled = false;
                btthem.Enabled = false;
                btxoa.Enabled = false;
                MessageBox.Show("Bạn đang nhập tài khoản không phải tài khoản quản lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvnhacungcap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvnhacungcap.Rows.Count)
            {
                int i = e.RowIndex;
                tbManhacungcap.Text = dgvnhacungcap[0, i].Value.ToString();
                tbTennhacungcap.Text = dgvnhacungcap[1, i].Value.ToString();
                tbDiachi.Text = dgvnhacungcap[2, i].Value.ToString();
                tbSDT.Text = dgvnhacungcap[3, i].Value.ToString();
            }

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool ValidatePhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường thông tin có rỗng không
            if (!ValidatePhoneNumber(tbSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tbTennhacungcap.Text) || string.IsNullOrEmpty(tbDiachi.Text) || string.IsNullOrEmpty(tbSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int count = dgvnhacungcap.Rows.Count;

                if (count > 0)
                {
                    int lastSupplierID = Convert.ToInt32(dgvnhacungcap.Rows[count - 1].Cells[0].Value);
                    int nextSupplierID = lastSupplierID + 1;
                    tbManhacungcap.Text = nextSupplierID.ToString();
                }
                else
                {
                    tbManhacungcap.Text = "1";
                }

                NhaCungCapDTO ncc = new NhaCungCapDTO();

                ncc.ManhaCC = tbManhacungcap.Text;
                ncc.Tennhacc = tbTennhacungcap.Text;
                ncc.Diachi = tbDiachi.Text;
                ncc.SDT = tbSDT.Text;

                string result = BUS.Themnhacc(ncc);
                if (result == "Thêm nhà cung cấp thành công.")
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvnhacungcap.DataSource = BUS.getData();
                    ClearFields();
                    loaddgv();
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ClearFields()
        {
            tbManhacungcap.Text = "";
            tbTennhacungcap.Text = "";

            tbDiachi.Text = "";
            tbSDT.Text = "";

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbManhacungcap.Text) || string.IsNullOrEmpty(tbTennhacungcap.Text) || string.IsNullOrEmpty(tbDiachi.Text) || string.IsNullOrEmpty(tbSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            if (!ValidatePhoneNumber(tbSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhaCungCapDTO ncc = new NhaCungCapDTO();
            ncc.ManhaCC = tbManhacungcap.Text;
            ncc.Tennhacc = tbTennhacungcap.Text;
            ncc.Diachi = tbDiachi.Text;
            ncc.SDT = tbSDT.Text;
            string currentTen = dgvnhacungcap.CurrentRow.Cells[1].Value.ToString();
            string currentDiaChi = dgvnhacungcap.CurrentRow.Cells[2].Value.ToString();
            string currentSDT = dgvnhacungcap.CurrentRow.Cells[3].Value.ToString();
            if (currentTen == tbTennhacungcap.Text && currentDiaChi == tbDiachi.Text && currentSDT == tbSDT.Text)
            {
                MessageBox.Show("Bạn không có thay đổi nào để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string result = BUS.Suanhacc(ncc);
            if(result == "Sửa thông tin nhà cung cấp thành công.")
            {

                MessageBox.Show("Sửa thông tin nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvnhacungcap.DataSource = BUS.getData();
                ClearFields();
                loaddgv();
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbManhacungcap.Text) || string.IsNullOrEmpty(tbTennhacungcap.Text) || string.IsNullOrEmpty(tbDiachi.Text) || string.IsNullOrEmpty(tbSDT.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maNCC = tbManhacungcap.Text;
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa nha cung cấp này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO();
                ncc.ManhaCC = maNCC;

                string result = BUS.Xoanhacc(ncc);
                if (result == "Xóa nhà cung cấp thành công.")
                {
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvnhacungcap.DataSource = BUS.getData();
                    ClearFields();
                    loaddgv();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bttim_Click(object sender, EventArgs e)
        {
            string keyword = tbtim.Text;
            DataTable searchResult = BUS.TimKiemNhanVien(keyword);

            if (searchResult.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp nào phù hợp với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvnhacungcap.DataSource = searchResult;
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

        private void btmoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            loaddgv();
        }

        private void tbManhacungcap_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbManhacungcap.Text))
            {
                errorProvider1.SetError(tbManhacungcap, "Không được bỏ trống mã nhà cung cấp!");
            }
            else
            {
                errorProvider1.SetError(tbManhacungcap, null);
            }
        }

        private void tbTennhacungcap_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTennhacungcap.Text))
            {
                errorProvider2.SetError(tbTennhacungcap, "Không được bỏ trống tên nhà cung cấp!");
            }
            else
            {
                errorProvider1.SetError(tbTennhacungcap, null);
            }
        }

        private void tbDiachi_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDiachi.Text))
            {
                errorProvider3.SetError(tbDiachi, "Không được bỏ trống địa chỉ !");
            }
            else
            {
                errorProvider1.SetError(tbDiachi, null);
            }
        }

        private void tbSDT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSDT.Text))
            {
                errorProvider4.SetError(tbSDT, "Không được bỏ trống số điện thoại !");
            }
            else
            {
                errorProvider1.SetError(tbSDT, null);
            }
        }

        private void tbtim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
