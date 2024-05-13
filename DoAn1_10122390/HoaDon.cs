using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace DoAn1_10122390
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        public void SetReport(DataTable dataSource)
        {
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(dataSource);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}