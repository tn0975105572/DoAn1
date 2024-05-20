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
       
        SqlConnection connection = new SqlConnection("Data Source=DUYTUAN;Initial Catalog=olodo;Integrated Security=True");
        private ThongKeBUS BUS = new ThongKeBUS();
      
        private void ThongKe_Load(object sender, EventArgs e)
        {

            label1.Text = BUS.getMaxMaKhachHang().ToString();
            label2.Text = BUS.getMaxMaNhanVien().ToString();
            label3.Text = BUS.getMaxMaSanPham().ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT TOP 5 SP.TenSanPham AS ProductName, SUM(CTDH.SoLuong) AS QtySold " +
                                                                "FROM ChiTietDonHang CTDH " +
                                                                "JOIN SanPham SP ON CTDH.MaSanPham = SP.MaSanPham " +
                                                                "JOIN DonHang DH ON CTDH.MaDonHang = DH.MaDonHang " +
                                                                "WHERE DH.NgayDat >= @StartDate AND DH.NgayDat <= @EndDate " +
                                                                "GROUP BY SP.TenSanPham " +
                                                                "ORDER BY SUM(CTDH.SoLuong) DESC", connection);

                dataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", dateTimePicker1.Value.Date);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value.Date);

                connection.Open();
                dataAdapter.Fill(dt);
                connection.Close();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"Không có dữ liệu cho khoảng thời gian từ {dateTimePicker1.Value.ToString("dd-MM-yyyy")} đến {dateTimePicker2.Value.ToString("dd-MM-yyyy")}");
                    return;
                }

                // Kiểm tra xem loạt dữ liệu đã tồn tại chưa
                if (BieuDoCot.Series.IndexOf("ProductName") != -1)
                {
                    // Nếu loạt dữ liệu đã tồn tại, xóa nó đi
                    BieuDoCot.Series.Remove(BieuDoCot.Series["ProductName"]);
                }

              
                Series series = new Series("Top 5 Sản Phẩm Bán Chạy");
                BieuDoCot.Series.Add(series);

                BieuDoCot.ChartAreas["ChartArea1"].AxisX.Title = "Tên Sản Phẩm";
                BieuDoCot.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng đã bán";

                // Thêm dữ liệu vào loạt dữ liệu mới
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string productName = dt.Rows[i]["ProductName"].ToString();
                    int qtySold = Convert.ToInt32(dt.Rows[i]["QtySold"]);
                    series.Points.AddXY(productName, qtySold);
                }

                series.IsValueShownAsLabel = true; // Hiển thị giá trị trên biểu đồ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
