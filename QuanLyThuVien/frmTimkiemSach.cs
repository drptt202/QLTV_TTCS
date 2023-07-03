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
    public partial class frmTimkiemSach : Form
    {
        public frmTimkiemSach()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void timkiem_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
            cls.LoadData2Combobox(txtTinhtrang, "select DISTINCT TINHTRANG from VIEW_CUONSACH");
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label4.Text = comboBox1.Text + ":";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select*from VIEW_CUONSACH where " + comboBox1.Text + " like N'%" + textBox1.Text + "%'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string check;
            if (cbCD.Checked == true)
            {
                check = "1";
            }
            else
            {
                check = "0";
            }
            cls.LoadData2DataGridView(dataGridView2, "EXEC [dbo].[SP_SEARCH_SACH] @ID = '" + txtID.Text + "', @STT = '" + txtSTT.Text+ "', @MALANXUATBAN = '" + txtMalanxuatban.Text+ "', @MASACH = '" + txtMasach.Text+ "', @TINHTRANG = N'" + txtTinhtrang.Text+ "', @TENTAILIEU = N'" + txtTentailieu.Text+ "', @LANXUATBAN = '" + txtLanxuatban.Text+ "', @NAMXUATBAN = '" + txtNamxuatban.Text+ "', @KHOGIAY = '" + txtKhogiay.Text+ "', @SOTRANG = N'" + txtSotrang.Text+ "', @TEN = N'" + txtTennxb.Text+ "', @GIA = '" + txtGia.Text+ "', @CODIACD = '" + check + "'");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
