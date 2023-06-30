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

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select*from VIEW_BAOTAPCHI where SOLUONGCON >0");
                cls.LoadData2Label(lb1, "select sum(SOLUONGCON) from VIEW_BAOTAPCHI where SOLUONGCON >0");
            }
            if (radioButton3.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select*from VIEW_BAOTAPCHI where SOLUONGNHAP >50");
            }
            if (radioButton4.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select*from VIEW_BAOTAPCHI where SOLUONGNHAP <=50");
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

    }
}
