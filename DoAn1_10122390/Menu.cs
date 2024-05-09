using DoAn1_10122390.chucnang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DTO;

namespace DoAn1_10122390
{
    public partial class Menu : Form
    {
        private TaiKhoanDTO olodo3;
        public Menu(TaiKhoanDTO olodo)
        {
            InitializeComponent();
            olodo3 = olodo;
         
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
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("ddd, dd/MM/yyyy HH:mm:ss");


        }

        private void ptb2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void thunho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            gioithieudanhgia dg = new gioithieudanhgia();
            dg.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            //labeltieude.Text = "Sản Phẩm";
            //SanPham sp = new SanPham();
            //if (panelmenu.Controls.Count == 0)
            //{
            //    panelmenu.Controls.Add(sp);
            //}
            //else
            //{
            //    panelmenu.Controls.Clear();
            //};
        }
    

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            labeltieude.Text = "Nhân Viên";
            Nhanvien nv = new Nhanvien();
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(nv);
            }
            else
            {
                panelmenu.Controls.Clear();

            }
            pictureBox4.Visible = false;


        }

        private void btnSanpham_Click(object sender, EventArgs e)
        {
           
        }

        private void btnThongtin_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan thongtin = new ThongTinCaNhan(olodo3);
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(thongtin);
            }
            else
            {
                panelmenu.Controls.Clear(); 
            }
            labeltieude.Text = "Thông tin cá nhân";
            pictureBox4.Visible = false;

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Nhanvien nv = new Nhanvien();
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(nv);
            }
            else
            {
                panelmenu.Controls.Clear(); 
            }
            pictureBox4.Visible = false;
        }

        
      

       

       

        private void btnThongke_Click(object sender, EventArgs e)
        {
         
        }


        private void timerSP_Tick(object sender, EventArgs e)
        {
            

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dk = new DangNhap();
            dk.ShowDialog();
        }

     

        private void labeltieude_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
           
            labeltieude.Text = "Home";
            panelmenu.Controls.Clear();
            pictureBox4.Visible = true;
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            labeltieude.Text = "Sản Phẩm";
            SanPham sp = new SanPham();
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(sp);
            }
            else
            {
                panelmenu.Controls.Clear();
            }
            pictureBox4.Visible = false;
        }

        private void btnNhacungcap_Click_1(object sender, EventArgs e)
        {
            labeltieude.Text = "Nhà Cung Cấp";
            NhaCungCap sp = new NhaCungCap();
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(sp);
            }
            else
            {
                panelmenu.Controls.Clear();
            }
            pictureBox4.Visible = false;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            labeltieude.Text = "Khách Hàng";
            KhachHang sp = new KhachHang();
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(sp);
            }
            else
            {
                panelmenu.Controls.Clear();
            }
        }

      

        private void btnMua_Click(object sender, EventArgs e)
        {
            labeltieude.Text = "MUA HÀNG";
            MUA sp = new MUA();
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(sp);
            }
            else
            {
                panelmenu.Controls.Clear();
            }

        }
    }
}
