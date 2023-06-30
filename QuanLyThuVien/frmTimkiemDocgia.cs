using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    public partial class frmTimkiemDocgia : Form
    {
        public frmTimkiemDocgia()
        {
            InitializeComponent();
        }
        Class.clsDatabase Cls = new QuanLyThuVien.Class.clsDatabase();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text + ":";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cls.LoadData2DataGridView(dataGridView1, "select*from DOCGIA where " + comboBox1.Text + " like N'%" + textBox1.Text + "%'");
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Cls.LoadData2DataGridView(dataGridView2, "EXEC [dbo].[SP_SEARCH_DOCGIA] @SoTheDocGia = '" + txtSothedocgia.Text +"', @NgayCap = '"+ txtNgaycap.Text+"', @Ho = N'"+txtHo.Text+"', @Ten = N'"+txtTen.Text+"', @NgheNghiep = N'"+txtNghenghiep.Text+"', @Phai = N'"+txtPhai.Text+"'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimkiemDG_Load(object sender, EventArgs e)
        {
            Cls.KetNoi();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
