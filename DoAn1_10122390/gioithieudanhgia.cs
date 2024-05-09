using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1_10122390
{
    public partial class gioithieudanhgia : Form
    {
        public gioithieudanhgia()
        {
            InitializeComponent();
        }

        private void ptb2_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void pbfb_Click(object sender, EventArgs e)
        {
            string fb = "https://www.facebook.com/jackdote0810";
            System.Diagnostics.Process.Start(fb);
        }

        private void pbemail_Click(object sender, EventArgs e)
        {
            string diachiemail = "tn0975105572@gmail.com";
            System.Diagnostics.ProcessStartInfo mo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "mailto:" + diachiemail,
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(mo);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string ut = "https://www.youtube.com/channel/UC4K7Gq6-9y8Hbj2Q-oBbpzQ";
            System.Diagnostics.Process.Start(ut);
        }
    }
}
