using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;



namespace DoAn1_10122390
{
    public partial class DangNhap : Form
    {
        /*  _____     __  __     __  __     ______   __  __     ______     __   __    */
        /* /\  __-.  /\ \/\ \   /\ \_\ \   /\__  _\ /\ \/\ \   /\  __ \   /\ "-.\ \   */
        /* \ \ \/\ \ \ \ \_\ \  \ \____ \  \/_/\ \/ \ \ \_\ \  \ \  __ \  \ \ \-.  \  */
        /*  \ \____-  \ \_____\  \/\_____\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\\"\_\ */
        /*   \/____/   \/_____/   \/_____/     \/_/   \/_____/   \/_/\/_/   \/_/ \/_/ */


        private TaiKhoanDTO olodo1 = new TaiKhoanDTO();
        
        public DangNhap()
        {
            InitializeComponent();
            
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
        public void DangNhap_Load(object sender, EventArgs e)
        {
          
        }

        public void btdangnhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = tbtendangnhap.Text;
            string matKhau = tbmk.Text;
            
            

            try
            {
                BUS_DangNhap busDangNhap = new BUS_DangNhap();
                TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO { Taikhoan = taiKhoan, Matkhau = matKhau };
                string ketQua = busDangNhap.KiemTraDangNhap(taiKhoanDTO);

                if (ketQua == "Đăng nhập thành công.")
                {
                    olodo1.Taikhoan = tbtendangnhap.Text;
                    this.Hide();
                    Quyen.tk = tbtendangnhap.Text;
                    Quyen.mk = tbmk.Text;
                    LoadDangNhap menu = new LoadDangNhap(olodo1);
                    menu.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(ketQua, "THÔNG BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "LỖI!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Phide_Click(object sender, EventArgs e)
        {
            if (tbmk.PasswordChar == '*')
            {
                pshow.BringToFront();
                tbmk.PasswordChar = '\0';
            }
        }

        private void pshow_Click(object sender, EventArgs e)
        {
            if (tbmk.PasswordChar == '\0')
            {
                Phide.BringToFront();
                tbmk.PasswordChar = '*';
            }
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
        private bool isMaximized = false;

        private void xoatat_Click(object sender, EventArgs e)
        {
            tbtendangnhap.Text = string.Empty;
        }

        private void xoatat2_Click(object sender, EventArgs e)
        {
            tbmk.Text = string.Empty;
        }

        private void tbtendangnhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangKy dk = new DangKy();
            dk.ShowDialog();  
        }

        private void llb1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            QuenMatKhau qmk = new QuenMatKhau();
            qmk.ShowDialog();
        }

        private void anhdaidien_Click(object sender, EventArgs e)
        {
            tbtendangnhap.Text = "123";
            tbmk.Text = "123";
            btdangnhap_Click(this, EventArgs.Empty);


        }

        private void tbmk_TextChanged(object sender, EventArgs e)
        {

        }
















        //private void phongto_Click(object sender, EventArgs e)
        //{
        //    if (!isMaximized)
        //    {

        //        this.WindowState = FormWindowState.Maximized;
        //        this.MinimumSize = this.Size;
        //        this.MaximumSize = this.Size;
        //        isMaximized = true;
        //    }
        //    else
        //    {

        //        this.WindowState = FormWindowState.Normal;
        //        this.MinimumSize = new Size(0, 0);
        //        this.MaximumSize = new Size(int.MaxValue, int.MaxValue);
        //        isMaximized = false;
        //    }

        //}
    }
}
