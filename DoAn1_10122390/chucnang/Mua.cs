using BUS;
using System;
using System.Windows.Forms;


namespace DoAn1_10122390
{
    public partial class Mua : UserControl
    {
        public Mua()
        {
            InitializeComponent();
        }
        SanPhamBUS BUS = new SanPhamBUS();

        
        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "Column4")
            {
                dgvGioHang.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            dgvGioHang.Rows.Clear();
        }

        private void Mua_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = BUS.Laydulieu();
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "Column5")
            {
                dgvGioHang.Rows.Add(dgvSanPham.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }
    }
}
