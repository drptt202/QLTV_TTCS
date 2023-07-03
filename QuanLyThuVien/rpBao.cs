using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyThuVien
{
    public partial class rpBao : Form
    {
        public rpBao()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void BCBao_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "Select*from VIEW_BAOTAPCHI");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int thongke;
        int tongso;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select*from VIEW_BAOTAPCHI where SOLUONGCON >0");
                cls.LoadData2Label(lb1, "select sum(SOLUONGCON) from VIEW_BAOTAPCHI where SOLUONGCON >0");
            }
            if (radioButton3.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "EXEC [dbo].[SP_STATISTICS_SOLUOTMUON_BAO]");
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
                cls.KetNoi();
                object S = cls.layGiaTri("select sum(SOLUONGNHAP) from VIEW_BAOTAPCHI");
                object K = cls.layGiaTri("select sum(SOLUONGCON) from VIEW_BAOTAPCHI");
                thongke = Convert.ToInt32(K);
                tongso = Convert.ToInt32(S);

            Chart chart = new Chart(thongke,tongso);
            chart.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
