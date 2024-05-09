using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1_10122390
{
    public partial class SanPham1 : Form
    {
        public SanPham1()
        {
            InitializeComponent();
            dgvSanpham.ReadOnly = true;
        }

        private void SanPham1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doan1DataSet.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter.Fill(this.doan1DataSet.SanPham);

        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
        private byte[] imageData;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Đọc dữ liệu hình ảnh từ tệp được chọn
                    imageData = File.ReadAllBytes(openFileDialog.FileName);
                    // Hiển thị hình ảnh trên PictureBox
                    ptbAnh.Image = Image.FromStream(new MemoryStream(imageData));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }

        private void bttThem_Click(object sender, EventArgs e)
        {

            DataRowView newRow = (DataRowView)sanPhamBindingSource.AddNew();
            DataRow dataRow = newRow.Row;
            dataRow["MaSanPham"] = Convert.ToInt32(tbMasp.Text);
            dataRow["TenSanPham"] = tbTensp.Text;
            dataRow["Gia"] = Convert.ToInt32(tbGia.Text);
            dataRow["MoTa"] = tbMota.Text;
            dataRow["MaNhaCungCap"] = Convert.ToInt32(tbMacc.Text);
            dataRow["SoLuong"] = Convert.ToInt32(tbSoluong.Value);
            dataRow["HinhAnh"] = ConvertImageToByteArray(ptbAnh.Image);
            try
            {
                this.Validate();
                this.sanPhamBindingSource.EndEdit();
                int rowsAffected = sanPhamTableAdapter.Update(doan1DataSet.SanPham);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data saved successfully.");
                }
                else
                {
                    MessageBox.Show("No changes to save.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }
        byte[] bytes;
        private void dgvSanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanpham.Rows.Count - 1) // Đảm bảo chỉ số hàng hợp lệ
            {
                int i = e.RowIndex;
                tbMasp.Text = dgvSanpham[0, i].Value.ToString();
                tbTensp.Text = dgvSanpham[1, i].Value.ToString();
                tbGia.Text = dgvSanpham[2, i].Value.ToString();
                tbMota.Text = dgvSanpham[3, i].Value.ToString();
                tbMacc1.Text = dgvSanpham[4, i].Value.ToString();
                tbSoluong.Text = dgvSanpham[5, i].Value.ToString();

                if (dgvSanpham[6, i].Value != DBNull.Value)
                {
                    bytes = (byte[])dgvSanpham[6, i].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    ptbAnh.Image = Image.FromStream(ms);
                }
                else
                {
                    ptbAnh.Image = null;
                }
            }
            else
            {
                
                tbMasp.Text = string.Empty;
                tbTensp.Text = string.Empty;
                tbGia.Text = string.Empty;
                tbMota.Text = string.Empty;
                tbMacc1.Text = string.Empty;
                tbSoluong.Text = string.Empty;
                ptbAnh.Image = null;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tbMasp.Clear();
            tbTensp.Clear();
            tbGia.Clear();
            tbMota.Clear();
           
            tbSoluong.Value = 0; // Đặt giá trị mặc định cho Guna2NumericUpDown
            ptbAnh.Image = null; // Xóa hình ảnh hiển thị

            // Di chuyển con trỏ tới textbox đầu tiên
            tbMasp.Focus();

            // Thêm bản ghi mới
            sanPhamBindingSource.AddNew();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
