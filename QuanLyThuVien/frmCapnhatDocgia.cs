using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapnhatDocgia : Form
    {
        public frmCapnhatDocgia()
        {
            InitializeComponent();
        }
    
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void capnhatdocgia_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1,"select *from DOCGIA");           
            dataGridView1.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd";
            txtSothedocgia.Enabled = false;
        }

        int them = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (them == 0)
            {
                them = 1;
                button2.Enabled= false;
                button3.Enabled= false;
                txtSothedocgia.Text =
                txtNgaycapthe.Text = 
                txtHo.Text = 
                txtTen.Text = 
                txtNghenghiep.Text = 
                txtPhai.Text = "";
            }
            else
            {
                try
                {
                    string strInsert = "Insert Into DOCGIA(NGAYCAPTHE,HO,TEN,NGHENGHIEP,PHAI) values ('" + txtNgaycapthe.Text + "',N'" + txtHo.Text + "',N'" + txtTen.Text + "',N'" + txtNghenghiep.Text + "',N'" + txtPhai.Text + "')";
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select *from DOCGIA");
                    MessageBox.Show("Thêm thành công"); them = 0;
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
                    string strDelete = "Delete from DOCGIA where SOTHEDOCGIA='" + txtSothedocgia.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select *from DOCGIA");
                    MessageBox.Show("Xóa thành công");
                }
                catch { MessageBox.Show("Xoá thất bại"); };
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtSothedocgia.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNgaycapthe.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtHo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNghenghiep.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPhai.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch { };
        }
        int sua = 0;
        string sothe;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                sothe = txtSothedocgia.Text;
                sua = 1;
                button1.Enabled = false;
                button3.Enabled = false;
                txtSothedocgia.Enabled= false;
            }
            else
            {
                try
                {
                    string strUpdate = "Update DOCGIA set HO=N'" + txtHo.Text + "',TEN=N'" + txtTen.Text + "',NGAYCAPTHE='" + txtNgaycapthe.Text + "',PHAI=N'" + txtPhai.Text + "',NGHENGHIEP=N'" + txtNghenghiep.Text + "' where SOTHEDOCGIA='" + sothe + "'";
                    cls.ThucThiSQLTheoKetNoi(strUpdate);
                    cls.LoadData2DataGridView(dataGridView1, "select *from DOCGIA");
                    button1.Enabled = true;
                    button3.Enabled = true;
                    MessageBox.Show("Sửa thành công");
                    sua = 0;
                }
                catch { MessageBox.Show("Sửa thất bại!"); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            them = 0;
            sua = 0;
            button1.Enabled = button2.Enabled = button3.Enabled = true;
            txtSothedocgia.Text =
            txtNgaycapthe.Text =
            txtHo.Text =
            txtTen.Text =
            txtNghenghiep.Text =
            txtPhai.Text = "";
        }
    }
}
