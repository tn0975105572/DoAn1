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
    public partial class NhaCungCap : UserControl
    {
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

        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            loaddgv();
        }

        private void dgvnhacungcap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            tbManhacungcap.Text = dgvnhacungcap[0, i].Value.ToString();
            tbTennhacungcap.Text = dgvnhacungcap[1, i].Value.ToString();
            tbDiachi.Text = dgvnhacungcap[2, i].Value.ToString();
            tbSDT.Text = dgvnhacungcap[3, i].Value.ToString();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {
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
        private void ClearFields()
        {
            tbManhacungcap.Text = "";
            tbTennhacungcap.Text = "";

            tbDiachi.Text = "";
            tbSDT.Text = "";

        }
    }
}
