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

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "Select*from VIEW_CUONSACH where TINHTRANG != N'Tốt'");
                cls.LoadData2Label(lb1, "select count(*) from VIEW_CUONSACH where  TINHTRANG != N'Tốt'");
            }
            if (radioButton3.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select vs.ID,STT,MALANXB,MASACH,TINHTRANG,TENTAILIEU,TACGIA,LANXUATBAN,NAMXUATBAN,KHOGIAY,SOTRANG,TEN,GIA,CODIACD, COUNT(*) as SOLANMUON from PHIEUMUONSACH pm  join VIEW_CUONSACH vs on pm.IDCUONSACH=vs.ID group by vs.ID,vs.ID,STT,MALANXB,MASACH,TINHTRANG,TENTAILIEU,TACGIA,LANXUATBAN,NAMXUATBAN,KHOGIAY,SOTRANG,TEN,GIA,CODIACD");
            }
            if (radioButton4.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select vs.ID,STT,MALANXB,MASACH,TINHTRANG,TENTAILIEU,TACGIA,LANXUATBAN,NAMXUATBAN,KHOGIAY,SOTRANG,TEN,GIA,CODIACD, SOLANMUON ='0' from PHIEUMUONSACH pm join VIEW_CUONSACH vs on pm.IDCUONSACH!=vs.ID group by vs.ID,vs.ID,STT,MALANXB,MASACH,TINHTRANG,TENTAILIEU,TACGIA,LANXUATBAN,NAMXUATBAN,KHOGIAY,SOTRANG,TEN,GIA,CODIACD");
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
    }
}
