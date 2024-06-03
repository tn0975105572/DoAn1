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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAn1_10122390
{
    public partial class Menu : Form
    {
        /*  _____     __  __     __  __     ______   __  __     ______     __   __    */
        /* /\  __-.  /\ \/\ \   /\ \_\ \   /\__  _\ /\ \/\ \   /\  __ \   /\ "-.\ \   */
        /* \ \ \/\ \ \ \ \_\ \  \ \____ \  \/_/\ \/ \ \ \_\ \  \ \  __ \  \ \ \-.  \  */
        /*  \ \____-  \ \_____\  \/\_____\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\\"\_\ */
        /*   \/____/   \/_____/   \/_____/     \/_/   \/_____/   \/_/\/_/   \/_/ \/_/ */


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
            toolTip1.SetToolTip(this.btnThongtin, "Click or Nhấn  Ctrl + T để Quản Lý Tài Khoản");
            toolTip1.SetToolTip(this.btnNhanvien, "Click or Nhấn Ctrl + N để Quản Lý Nhân Viên");
            toolTip1.SetToolTip(this.guna2Button2, "Click or Nhấn Ctrl + S để Quản Lý Khách Hàng");
            toolTip1.SetToolTip(this.guna2Button9, "Click or Nhấn CTRL+ D để Quản Lý Sản Phẩm");
            toolTip1.SetToolTip(this.btnNhacungcap, "Click or Nhấn CTRL + E để Quản Lý Nhà Cung Cấp");
            toolTip1.SetToolTip(this.btnMua, "Click or Nhấn Ctrl + F để Mua");
            toolTip1.SetToolTip(this.btnThongke, "Click or Nhấn Ctrl + G để Thống Kê-Báo Cáo");

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
            labeltieude.Text = "Nhân Viên";
            pictureBox4.Visible = false;
        }

        
      

       

       

        private void btnThongke_Click(object sender, EventArgs e)
        {
            ThongKe nv = new ThongKe();
            if (panelmenu.Controls.Count == 0)
            {
                panelmenu.Controls.Add(nv);
            }
            else
            {
                panelmenu.Controls.Clear();
            }
            labeltieude.Text = "Thống Kê-Báo Cáo";
            pictureBox4.Visible = false;

        }


      

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dk = new DangNhap();
            dk.ShowDialog();
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

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.T:
                        btnThongtin.PerformClick();
                        break;
                    case Keys.N:
                        btnNhanvien.PerformClick();
                        break;
                    case Keys.S:
                        guna2Button2.PerformClick();
                        break;
                    case Keys.D:
                        guna2Button9.PerformClick();
                        break;
                    case Keys.E:
                        btnNhacungcap.PerformClick();
                        break;
                    case Keys.F:
                        btnMua.PerformClick();
                        break;
                    case Keys.G:
                        btnThongke.PerformClick();
                        break;
                   
                }
            }

        }
    }
}
