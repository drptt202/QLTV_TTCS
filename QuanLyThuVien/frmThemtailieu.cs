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
    public partial class frmThemtailieu : Form
    {
        public frmThemtailieu()
        {
            InitializeComponent();
            txtMa.Enabled= false;
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void frmThemtailieu_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from TAILIEU");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string strInsert = "Insert Into TAILIEU(TENTAILIEU,LOAITAILIEU) values (N'" + txtTentailieu.Text + "',N'" + txtLoaitailieu.Text + "')";
                cls.ThucThiSQLTheoKetNoi(strInsert);
                cls.LoadData2DataGridView(dataGridView1, "select *from TAILIEU");
                MessageBox.Show("Thêm thành công");
            }
            catch { MessageBox.Show("Thêm thất bại"); };
        }
    }
}
