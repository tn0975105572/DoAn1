using BUS;
using ClosedXML.Excel;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;

using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace DoAn1_10122390
{
    public partial class ChamCong : Form
    {

        /*  _____     __  __     __  __     ______   __  __     ______     __   __    */
        /* /\  __-.  /\ \/\ \   /\ \_\ \   /\__  _\ /\ \/\ \   /\  __ \   /\ "-.\ \   */
        /* \ \ \/\ \ \ \ \_\ \  \ \____ \  \/_/\ \/ \ \ \_\ \  \ \  __ \  \ \ \-.  \  */
        /*  \ \____-  \ \_____\  \/\_____\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\\"\_\ */
        /*   \/____/   \/_____/   \/_____/     \/_/   \/_____/   \/_/\/_/   \/_/ \/_/ */


        public ChamCong()
        {
            InitializeComponent();
        }
        ChamCongBUS BUS = new ChamCongBUS();
        void loaddgv()
        {

            dgvchamcong.DataSource = BUS.getData();
            dgvchamcong.Columns[0].HeaderText = "Mã Chấm Công ";
            dgvchamcong.Columns[1].HeaderText = "Tên NV";
            dgvchamcong.Columns[2].HeaderText = "Ngày Chấm Công";
            dgvchamcong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);

        }
        private void LoadDataIntoComboBox()
        {
    
            DataTable dataTable = BUS.getData1();

      
            cbbnhanvien.DataSource = dataTable;
            cbbnhanvien.DisplayMember = "MaNhanVien";
            cbbnhanvien.ValueMember = "MaNhanVien"; 
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }


        private void ChamCong_Load(object sender, EventArgs e)
        {

            loaddgv();
            LoadDataIntoComboBox();


        }

        private void dgvchamcong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int i = e.RowIndex;

                tbmacc.Text = dgvchamcong[0, i].Value.ToString();
                dtpngay.Text = dgvchamcong[2, i].Value.ToString();
                cbbnhanvien.Text = dgvchamcong[1, i].Value.ToString();
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            int count = dgvchamcong.Rows.Count;

            if (count > 0)
            {
                int lastEmployeeID = Convert.ToInt32(dgvchamcong.Rows[count - 1].Cells[0].Value);
                int nextEmployeeID = lastEmployeeID + 1;
                tbmacc.Text = nextEmployeeID.ToString();
            }
            else
            {
                tbmacc.Text = "1";
            }

            ChamCongDTO cc = new ChamCongDTO();
            cc.Mavn = cbbnhanvien.SelectedValue.ToString();
            cc.Ngaycc = dtpngay.Value;

            string result = BUS.Themcc(cc);
            if (result == "Thêm chấm công thành công!")
            {
                MessageBox.Show("Thêm chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvchamcong.DataSource = BUS.getData();
                loaddgv();
                ClearFields();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            tbmacc.Text = "";
           
            dtpngay.Value = DateTime.Now;
            cbbnhanvien.Text = "";
           
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            string maCC = tbmacc.Text;
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa chấm công này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                ChamCongDTO dto = new ChamCongDTO();
                dto.Macc = maCC;

                string result = BUS.Xoacc(dto);
                if (result == "Xóa chấm công thành công!")
                {
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvchamcong.DataSource = BUS.getData();
                    loaddgv();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

  

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maNhanVien = cbbnhanvien.Text;
            DateTime ngayChamCong = dtpngay.Value;
            DataTable result = BUS.TimKiemCC(maNhanVien, ngayChamCong);
            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result.Rows.Count > 0)
            {               
                dgvchamcong.DataSource = result;
            }
            else
            {      
                string message = "Nhân viên " + maNhanVien + " không có chấm công trong ngày này.";
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            DataTable dataTable = BUS.getData();
                            workbook.Worksheets.Add(dataTable, "NhanVien");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Lưu thành công!",ShowIcon.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhanvien nv = new Nhanvien();
            nv.Show();
        }

        private void dgvchamcong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbbnhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ptb2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void tbtimkiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
