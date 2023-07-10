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
    public partial class frmThongtinNV : Form
    {
        public frmThongtinNV()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void KiemTraTTNhanVien_Load(object sender, EventArgs e)
        {   
            if(Main.Quyen== "Quản lý")
            {
            cls.LoadData2DataGridView(dataGridView1, "select*from NHANVIEN");
            }
            if(Main.Quyen== "Nhân viên")
            {
                cls.LoadData2DataGridView(dataGridView1, "select*from NHANVIEN where TENDANGNHAP='"+Main.TenDN+"'");
            }
            txtMaNV.Enabled = txtTenTaiKhoan.Enabled = txtQuyenHan.Enabled = false;
        }
		
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool check= false;
            if(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()=="True")
            {
                check = true;
            }else
            {
                check = false;
            }

            txtGT.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenTaiKhoan.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtQuyenHan.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtHo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbTrangthai.Checked = check;

        }
        string TenTK;
        int sua = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (sua == 0)
            {
                button2.Enabled = false;
                sua = 1;
                TenTK = txtTenTaiKhoan.Text;
                cbTrangthai.Checked = true;
            }
            else
            {
                try
                {
                    string check;
                    if (cbTrangthai.Checked == true)
                    {
                        check = "1";
                    }
                    else
                    {
                        check = "0";
                    }
                    string SQL = ("update NHANVIEN set MATKHAU='" + txtMatKhau.Text + "',CHUCVU=N'" + txtQuyenHan.Text + "',HO=N'" + txtHo.Text + "',TEN=N'" + txtTen.Text + "',PHAI=N'" + txtGT.Text + "',TRANGTHAI='" + check + "'where TENDANGNHAP='" + TenTK + "'");
                    cls.ThucThiSQLTheoKetNoi(SQL);
                    cls.LoadData2DataGridView(dataGridView1, "select * from NHANVIEN");
                    MessageBox.Show("Đã Sửa thành công");
                    sua = 0;
                    button2.Enabled = true;
                }
                    catch { MessageBox.Show("Sửa thất bại!"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = txtHo.Text + txtTen.Text;
            if (txtQuyenHan.Text == "Quản lý")
                MessageBox.Show("Không thể xóa tài khoản Quản lý");
            else
                if (MessageBox.Show("Bạn có chắc chắn xóa thông tin nhân viên " + s,"Thông Báo Xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string SQL = ("UPDATE NHANVIEN set TRANGTHAI='0' where TENDANGNHAP='" + txtTenTaiKhoan.Text + "'");
                    cls.ThucThiSQLTheoKetNoi(SQL);
                    cls.LoadData2DataGridView(dataGridView1, "select*from NHANVIEN");
                    MessageBox.Show("Xóa thành công");
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sua = 0;
            button1.Enabled =  button2.Enabled = true;
            txtTenTaiKhoan.Text = txtMaNV.Text = txtMatKhau.Text = txtHo.Text = txtTen.Text = txtGT.Text =txtQuyenHan.Text = "";

            cbTrangthai.Checked = false;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
