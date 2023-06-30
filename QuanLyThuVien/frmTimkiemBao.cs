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
    public partial class frmTimkiemBao : Form
    {
        public frmTimkiemBao()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void timkiem_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           label4.Text = comboBox1.Text + ":";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select*from VIEW_BAOTAPCHI where " + comboBox1.Text + " like N'%" + textBox1.Text + "%'");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView2, "EXECUTE [dbo].[SP_SEARCH_BAOTAPCHI] @MaKyXB ='" + txtMakyxuatban.Text + "', @ThoiGianNhap='" + txtThoigiannhap.Text + "', @SoXuatBan='" + txtSoxuatban.Text + "', @SoLuongNhap='" + txtSoluongnhap.Text + "', @SoLuongCon='" + txtSoluongcon.Text + "', @MaBao='" + txtMabao.Text + "', @NamPhatHanh='" + txtNamphathanh.Text + "', @DinhKy=N'" + txtDinhky.Text + "', @MaNhaXB='" + txtManxb.Text + "', @TenNhaXB=N'" + txtTennxb.Text + "', @MaTaiLieu='" + txtMatailieu.Text + "', @TenTaiLieu=N'" + txtTentailieu.Text + "'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
