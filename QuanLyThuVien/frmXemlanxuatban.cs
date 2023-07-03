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
    public partial class frmXemlanxuatban : Form
    {
        string lanxuatban;
        string ten;
        string malxb;
        public frmXemlanxuatban(string tentailieu)
        {
            InitializeComponent();
            ten = tentailieu;
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void frmXemlanxuatban_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select distinct * from VIEW_TENSACH_LANXB where TENTAILIEU=N'" + ten + "'");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lanxuatban = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            malxb = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            label1.Text = "Xem danh sách cuốn sách của lần xuất bản " + lanxuatban;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmXemcuonsach xem = new frmXemcuonsach(malxb,lanxuatban,ten);

            xem.Show();
        }
    }
}
