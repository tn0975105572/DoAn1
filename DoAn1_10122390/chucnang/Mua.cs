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
    public partial class MUA : UserControl
    {
        public MUA()
        {
            InitializeComponent();
        }
        SanPhamBUS BUS = new SanPhamBUS();
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

        private void MUA_Load(object sender, EventArgs e)
        {
            if (dgvSanpham != null)
            {
                loaddgv();
            }
        }

        private void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanpham.Columns[e.ColumnIndex].Name == "Column4")
            {


                dgvGioHang.Rows.Add(dgvSanpham.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvSanpham.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }

        private void dgvSanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "Column8")
            {
                dgvGioHang.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dgvGioHang.Rows.Clear();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }
    }
}
