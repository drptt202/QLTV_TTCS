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
    public partial class frmCapnhatTG : Form
    {
        public frmCapnhatTG()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();

        private void capnhatTG_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1,"select *from TACGIA");
            dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd";
            txtMATG.Enabled = false;
        }
        int them = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (them == 0)
            {
                them = 1;
                button2.Enabled = false;
                button3.Enabled = false;
                txtMATG.Text = txtTenTG.Text = txtNamsinh.Text = "";
            }
            else {
                try
                {
                    string strInsert = "Insert Into TACGIA(TENTACGIA,NAMSINH) values (N'" + txtTenTG.Text + "','" + txtNamsinh.Text + "')";
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select *from TACGIA");
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
                    string strDelete = "Delete from TACGIA where MATACGIA='" + txtMATG.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select *from TACGIA");
                    MessageBox.Show("Xóa thành công !!!");
                }
                catch { MessageBox.Show("Xoá thất bại"); };
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMATG.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenTG.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNamsinh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { };
        }
        int sua = 0;
        string matg;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                matg = txtMATG.Text;
                sua = 1;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {
                    string strUpdate = "Update TACGIA set TENTACGIA=N'" + txtTenTG.Text + "',NAMSINH='" + txtNamsinh.Text + "' where MATACGIA='" + matg + "'";
                    cls.ThucThiSQLTheoKetNoi(strUpdate);
                    cls.LoadData2DataGridView(dataGridView1, "select *from TACGIA");
                    button1.Enabled = true;
                    button3.Enabled = true;
                    sua = 0;
                    MessageBox.Show("Sửa thành công");
                }
                catch { MessageBox.Show("Sửa thất bại"); };               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            them = sua = 0;
            button1.Enabled = button2.Enabled = button3.Enabled = true;
            txtMATG.Text = txtTenTG.Text = txtNamsinh.Text = "";
        }
    }
}
