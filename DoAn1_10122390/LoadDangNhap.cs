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

namespace DoAn1_10122390
{
    public partial class LoadDangNhap : Form
    {
        private TaiKhoanDTO olodo2;
        public LoadDangNhap(TaiKhoanDTO olodo)
        {
            InitializeComponent();
            olodo2 = olodo;
        }

        private void LoadDangNhap_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2ProgressBar1.Value < 100)
            {
                guna2ProgressBar1.Value += 10;
                label2.Text = guna2ProgressBar1.Value.ToString() + "%";

            }
            else
            {
                this.Hide();
                timer1.Stop();
                Menu menu = new Menu(olodo2);
                menu.ShowDialog();

            }
        }
    }
}
