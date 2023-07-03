using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Chart : Form
    {
        public Chart(int tk, int ts)
        {
            InitializeComponent();
            tke = tk;
            tso = ts;
        }
        int tke;
        int tso;
        private void Chart_Load(object sender, EventArgs e)
        {
            // Create a series of data points.
            string[] xValues = { "Thống kê", "Tổng số"};
            int[] yValues = { tke, tso };
            // Add the data points to the chart.
            chart1.Series["Số liệu"].Points.DataBindXY(xValues, yValues);
        }
    }
}
