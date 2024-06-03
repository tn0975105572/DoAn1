using BUS;
using DoAn1_10122390.chucnang;
using DTO;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAn1_10122390
{
    public partial class ThongKe : UserControl
    {
        /*  _____     __  __     __  __     ______   __  __     ______     __   __    */
        /* /\  __-.  /\ \/\ \   /\ \_\ \   /\__  _\ /\ \/\ \   /\  __ \   /\ "-.\ \   */
        /* \ \ \/\ \ \ \ \_\ \  \ \____ \  \/_/\ \/ \ \ \_\ \  \ \  __ \  \ \ \-.  \  */
        /*  \ \____-  \ \_____\  \/\_____\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\\"\_\ */
        /*   \/____/   \/_____/   \/_____/     \/_/   \/_____/   \/_/\/_/   \/_/ \/_/ */
        public ThongKe()
        {
            InitializeComponent();
        }

        private readonly ThongKeBUS BUS = new ThongKeBUS();

        private void ThongKe_Load(object sender, EventArgs e)
        {

            label1.Text = BUS.getMaxMaKhachHang().ToString();
            label2.Text = BUS.getMaxMaNhanVien().ToString();
            label3.Text = BUS.getMaxMaSanPham().ToString();
            lb.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular);

        }




        private void bttThem_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Thời Gian Bạn Chọn Bị Lỗi Vì Thời Gian Bắt Đầu Luôn Nhỏ Hơn Thời Gian Kết Thúc",
                    "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            object result = BUS.GetTongDoanhThu(startDate, endDate);
            lb.Text = result != DBNull.Value
                ? $"Tổng doanh thu {Convert.ToDouble(result):N0} VNĐ"
                : "Không có dữ liệu thời gian này.";

            UpdateChart(startDate, endDate);
        }




        private void UpdateChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = BUS.GetTopSanPhamBanChay(startDate, endDate);

                if (dt.Rows.Count == 0)
                {
                    BieuDoCot.Series.Clear();
                    MessageBox.Show(
                        $"Không có dữ liệu cho khoảng thời gian từ {startDate:dd-MM-yyyy} đến {endDate:dd-MM-yyyy}");
                    return;
                }

                // Check if the series already exists and remove it if it does
                if (BieuDoCot.Series.IndexOf("Top 5 Sản Phẩm Bán Chạy") != -1)
                {
                    BieuDoCot.Series.Remove(BieuDoCot.Series["Top 5 Sản Phẩm Bán Chạy"]);
                }

                Series series = new Series("Top 5 Sản Phẩm Bán Chạy")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                BieuDoCot.Series.Add(series);
                BieuDoCot.ChartAreas["ChartArea1"].AxisX.Title = "Tên Sản Phẩm";
                BieuDoCot.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng đã bán";

                foreach (DataRow row in dt.Rows)
                {
                    string productName = row["ProductName"].ToString();
                    int qtySold = Convert.ToInt32(row["QtySold"]);
                    series.Points.AddXY(productName, qtySold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
    
}
