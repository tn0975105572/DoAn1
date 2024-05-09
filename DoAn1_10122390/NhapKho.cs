﻿using BUS;
using ClosedXML.Excel;
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
    public partial class NhapKho : Form
    {
        private int soluonghientai = 0;
        string tensp = null;
        public NhapKho()
        {
            InitializeComponent();
        }
        SanPhamBUS BUS = new SanPhamBUS();
        void loaddgv()
        {

            dgvSanpham.DataSource = BUS.getData();
            dgvSanpham.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);
            //dgvSanpham.Columns[0].HeaderText = "Mã Sản Phẩm ";
            //dgvSanpham.Columns[1].HeaderText = "Số lượng";
            //dgvSanpham.Columns[0].DefaultCellStyle.Font = new Font("Arial", 10);

            //dgvSanpham.Columns[1].DefaultCellStyle.Font = new Font("Arial", 10);

        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            loaddgv();
        }

        private void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                int i = e.RowIndex;
                tbMa.Text = dgvSanpham[0, i].Value.ToString();
                tbSoluomg.Text = dgvSanpham[6, i].Value.ToString();
                soluonghientai = Convert.ToInt32(dgvSanpham[5, i].Value.ToString());
                tensp = dgvSanpham[2, i].Value.ToString();
            }


        }

        private void ClearFields()
        {
        }
        private void btNhap_Click(object sender, EventArgs e)
        {
            SanPhamDTO sp = new SanPhamDTO();
            int olodo3 = Convert.ToInt32(soluonghientai + Convert.ToInt32(tbSoluomg.Text));
            string result = this.BUS.Suasoluong(Convert.ToInt32(tbMa.Text),  olodo3);
            if (string.IsNullOrWhiteSpace(tbSoluomg.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == "Nhập kho thành công")
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

      

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPham nv = new SanPham();
            nv.Show();
        }

        private void ptb2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Close();
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
                            workbook.Worksheets.Add(dataTable, "SanPham");
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

        private void tbSoluomg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    