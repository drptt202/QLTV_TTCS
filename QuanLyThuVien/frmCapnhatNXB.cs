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
    public partial class frmCapnhatNXB : Form
    {
        public frmCapnhatNXB()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase(); 
        private void capnhatNXB_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from NHAXUATBAN");
            txtMaNXB.Enabled = false;
        }
        int them = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (them == 0 )
            {
                them = 1;
                button2.Enabled = button3.Enabled = false;
                txtMaNXB.Text = txtTenNXB.Text = txtDiachi.Text = txtSdt.Text = txtEmail.Text = "";
            }
            else {
                try
                {
                    string strInsert = "Insert Into NHAXUATBAN(TEN,DIACHI,EMAIL,SDT) values (N'" + txtTenNXB.Text + "',N'" + txtDiachi.Text + "',N'" + txtEmail.Text + "',N'" + txtSdt.Text + "')";
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select *from NHAXUATBAN");
                    MessageBox.Show("Thêm thành công");
                    them = 0;
                    button2.Enabled = button3.Enabled = true;

                }
                catch { MessageBox.Show("Thêm thất bại"); };
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string strDelete = "Delete from NHAXUATBAN where ID='" + txtMaNXB.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select *from NHAXUATBAN");
                    MessageBox.Show("Xóa thành công");
                }
                catch { MessageBox.Show("Phải xóa những thông tin liên quan đến nhà xuất bản này trước"); };
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNXB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNXB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSdt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch { };
        }

        int sua = 0;
        string manxb;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                manxb = txtMaNXB.Text;
                sua = 1;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {
                    string strUpdata = "Update NHAXUATBAN set TEN=N'" + txtTenNXB.Text + "',DIACHI=N'" + txtDiachi.Text + "',SDT='" + txtSdt.Text + "',EMAIL='" + txtEmail.Text + "' where ID='" + manxb + "'";
                    cls.ThucThiSQLTheoKetNoi(strUpdata);
                    cls.LoadData2DataGridView(dataGridView1, "select *from NHAXUATBAN");
                    button1.Enabled = true;
                    button3.Enabled = true;
                    sua = 0;
                    MessageBox.Show("Sửa thành công");
                }
                catch { MessageBox.Show("Sửa thất bại"); };
            }
        }


        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sua = 0;
            them = 0;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            txtMaNXB.Text = txtTenNXB.Text = txtDiachi.Text = txtSdt.Text = txtEmail.Text = "";

        }
    }
}
