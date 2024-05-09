using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using System.Windows.Forms;
using DocumentFormat.OpenXml.ExtendedProperties;
using System.Data.SqlClient;

namespace DoAn1_10122390
{
    public partial class SanPham2 : Form
    {
        private readonly string connectionString = @"Data Source=DUYTUAN;Initial Catalog=Doan1;Integrated Security=True;";
        public SanPham2()
        {
            InitializeComponent();
        }
        
        SanPhamBUS BUS = new SanPhamBUS();
        void loaddgv()
        {
            dgvSanpham.DataSource = BUS.getData();
        }
        private void LoadDataIntoComboBox()
        {

            DataTable dataTable = BUS.getData1();


            tbMacc.DataSource = dataTable;
            tbMacc.DisplayMember = "MaNhaCungCap";
            tbMacc.ValueMember = "MaNhaCungCap";
        }
        private void SanPham2_Load(object sender, EventArgs e)
        {
            loaddgv();
            tbMasp.ReadOnly = true;
            LoadDataIntoComboBox();

        }
        byte[] bytes;
        private void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            tbMasp.Text = dgvSanpham[0, i].Value.ToString();
            tbTensp.Text = dgvSanpham[1, i].Value.ToString();
            tbGia.Text = dgvSanpham[2, i].Value.ToString();
            tbMota.Text = dgvSanpham[3, i].Value.ToString();
            tbMacc.Text = dgvSanpham[4, i].Value.ToString();
            tbSoluong.Text = dgvSanpham[5, i].Value.ToString();
            bytes = (byte[])dgvSanpham[6, i].Value;
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    byte[] imageData = ConvertImageToBytes();

                    string query = "INSERT INTO SanPham VALUES ( @HinhAnh)";
                    SqlCommand com = new SqlCommand(query, con);
                
                    com.Parameters.AddWithValue("@HinhAnh", imageData);
                    com.ExecuteNonQuery();

                    con.Close();
                }
                MessageBox.Show("Loi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int count = dgvSanpham.Rows.Count;

            if (count > 0)
            {

                int lastEmployeeID = Convert.ToInt32(dgvSanpham.Rows[count - 1].Cells[0].Value);
                int nextEmployeeID = lastEmployeeID + 1;
                string newEmployeeID = nextEmployeeID.ToString();
                tbMasp.Text = newEmployeeID;

            }
            else
            {
                tbMasp.Text = "1";
            }
            SanPhamDTO sp = new SanPhamDTO();
            sp.Masp = tbMasp.Text;
            sp.Tensp = tbTensp.Text;
            sp.Gia = tbGia.Text;
            sp.Mota = tbMota.Text;
            sp.Mancc = tbMacc.Text;
            sp.SoLuong = tbSoluong.Text;

            string result = BUS.Themsp(sp);
            if (result == "Thêm thành công")
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSanpham.DataSource = BUS.getData();
                ClearFields();
            }

            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] ConvertImageToBytes()
        {
            if (ptbAnh.Image == null)
            {
                MessageBox.Show("Please select an image.");
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                ptbAnh.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void ClearFields()
        {
            tbMasp.Text = "";
            tbTensp.Text = "";
            tbGia.Text = "";
            tbMota.Text = "";
            tbMacc.Text = "";
            tbSoluong.Text = "";
            ptbAnh.Image = null;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SanPhamDTO sp = new SanPhamDTO();
            sp.Masp = tbMasp.Text;
            sp.Tensp = tbTensp.Text;

            sp.Gia = tbGia.Text;
            sp.Mota = tbMota.Text;
            sp.Mancc = tbMacc.Text;
            sp.SoLuong = tbSoluong.Text;
            string result = BUS.Suasp(sp);
            if (result == "Sửa thành công")
            {
                MessageBox.Show("Sửa thông tin Sản Phẩn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSanpham.DataSource = BUS.getData();
                ClearFields();
                loaddgv();
            }
            else
            {
                MessageBox.Show("Sửa thông tin Sản Phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            string maSp = tbMasp.Text;
            SanPhamDTO sanPhamDTO = new SanPhamDTO();
            sanPhamDTO.Masp = maSp;

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string result = BUS.Xoasp(sanPhamDTO);
                if (result == "Xóa thành công")
                {
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSanpham.DataSource = BUS.getData();
                    ClearFields();
                    loaddgv();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClearFields();
            loaddgv();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhapKho nk = new NhapKho();
            nk.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.ImageLocation = openFileDialog1.FileName;
            }
        }
    }
}
