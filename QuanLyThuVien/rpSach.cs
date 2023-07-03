using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class rpSach : Form
    {
        public rpSach()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void BCTinhTrangSach_Load(object sender, EventArgs e)
        {
           cls.LoadData2DataGridView(dataGridView1, "Select*from VIEW_CUONSACH");
        }
        int thongke;
        int tongso;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "Select*from VIEW_CUONSACH where TINHTRANG != N'Tốt'");
                cls.LoadData2Label(lb1, "select count(*) from VIEW_CUONSACH where  TINHTRANG != N'Tốt'");
            }
            if (radioButton3.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "EXEC [dbo].[SP_STATISTICS_SOLUOTMUON_SACH]");

            }
            if (radioButton4.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select *,SOLANMUON='0' from VIEW_CUONSACH where ID not in (select IDCUONSACH from PHIEUMUONSACH)");
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            cls.KetNoi();
            if (radioButton1.Checked)
            {
                object S = cls.layGiaTri("select count(*) from VIEW_CUONSACH");
                object K = cls.layGiaTri("select count(*) from VIEW_CUONSACH where TINHTRANG != N'Tốt'");
                thongke = Convert.ToInt32(K);
                tongso = Convert.ToInt32(S);
            }
            if (radioButton3.Checked)
            {
                object TS = cls.layGiaTri("select count(*) from VIEW_CUONSACH");
                object TK = cls.layGiaTri("select count(*) from PHIEUMUONSACH");
                thongke = Convert.ToInt32(TK);
                tongso = Convert.ToInt32(TS);
            }
            if (radioButton4.Checked)
            {

                object TS = cls.layGiaTri("select count(*) from VIEW_CUONSACH");
                object TK = cls.layGiaTri("select count(*) from VIEW_CUONSACH where ID not in (select IDCUONSACH from PHIEUMUONSACH)");
                thongke = Convert.ToInt32(TK);
                tongso = Convert.ToInt32(TS);
            }
            Chart chart = new Chart(thongke,tongso);
            chart.Show();
        }
    }
}
