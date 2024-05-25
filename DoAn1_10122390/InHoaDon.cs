using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace DoAn1_10122390
{
    public partial class InHoaDon : Form
    {
        public InHoaDon()
        {
            InitializeComponent();
        }

        // Lớp xử lý kết nối và truy vấn cơ sở dữ liệu
        public class KetNoi
        {
            private string chuoiKetNoi = "Data Source=DUYTUAN;Initial Catalog=olodo;Integrated Security=True;"; // Thay đổi chuỗi kết nối của bạn tại đây

            public DataTable laybang(string truyVan)
            {
                DataTable dt = new DataTable();

                try
                {
                    using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                    {
                        using (SqlCommand cmd = new SqlCommand(truyVan, conn))
                        {
                            conn.Open();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }

                return dt;
            }
        }

        private void InHoaDon_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            KetNoi kn = new KetNoi();
            dt = kn.laybang("SELECT * FROM ChiTietHoaDon");

            if (dt.Rows.Count > 0)
            {
                RPDanhSach rp = new RPDanhSach();
                rp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rp;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }
    }
}
