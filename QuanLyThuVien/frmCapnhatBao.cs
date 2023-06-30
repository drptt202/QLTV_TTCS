using QuanLyThuVien.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapnhatBao : Form
    {
        public frmCapnhatBao()
        {
            InitializeComponent();
            txtManhaxuatban.Enabled = false;
            txtMatailieu.Enabled = false;
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        
        private void capnhatbao_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from VIEW_BAOTAPCHI");
            cls.LoadData2Combobox(txtTennhaxuatban, "select TEN from NHAXUATBAN");
            cls.LoadData2Combobox(txtTentailieu, "select TENTAILIEU from TAILIEU where LOAITAILIEU = N'Báo-Tạp chí'");
        }
        int them = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(them== 0)
            {
                them = 1;
                button2.Enabled= button3.Enabled = false;
                txtNamphathanh.Text = 
                txtDinhky.Text =
                txtTennhaxuatban.Text = 
                txtManhaxuatban.Text = 
                txtMatailieu.Text = 
                txtSoxuatban.Text = 
                txtSoluongnhap.Text =
                txtTentailieu.Text = "";
            }
            else
            {
                try
                {
                    string strInsert = "EXEC SP_ADD_BAOTAPCHI @NamPhatHanh='" + txtNamphathanh.Text + "',@DinhKy=N'" + txtDinhky.Text + "',@MaNhaXB='" + txtManhaxuatban.Text + "',@MaTaiLieu='" + txtMatailieu.Text + "',@SoXuatBan=N'" + txtSoxuatban.Text + "',@SoLuongNhap=N'" + txtSoluongnhap.Text + "'";               
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select *from VIEW_BAOTAPCHI");
                    them = 0;
                    button2.Enabled = button3.Enabled = true;
                    MessageBox.Show("Thêm thành công");
                }
                catch { MessageBox.Show("Thêm thất bại"); };
            }
        }

        int sua = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                sua = 1;
                button1.Enabled = false;
                button3.Enabled = false;
                cls.LoadData2DataGridView(dataGridView1, "  select * from VIEW_BAOTAPCHI where MABAO not in (select MABAO from KYXUATBAN where MAKYXB in (select MAKYXB from PHIEUMUONBAO))");

            }
            else
            {
                try
                {

                string strUpdate = "EXEC SP_UPDATE_BAOTAPCHI @MaBao='" + mabao+"', @NamPhatHanh='" + txtNamphathanh.Text + "',@DinhKy='" + txtDinhky.Text + "',@MaNhaXB='" + txtManhaxuatban.Text + "',@MaTaiLieu='" + txtMatailieu.Text + "',@SoXuatBan='" + txtSoxuatban.Text + "',@SoLuongNhap='" + txtSoluongnhap.Text + "'";

                cls.ThucThiSQLTheoKetNoi(strUpdate);
                cls.LoadData2DataGridView(dataGridView1, "select *from VIEW_BAOTAPCHI");
                button1.Enabled = true;
                button3.Enabled = true;
                sua = 0;
                MessageBox.Show("Sửa thành công");
                }
                catch { MessageBox.Show("Sửa thất bại "); }
            }
        }
        string mabao = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNamphathanh.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtDinhky.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtTennhaxuatban.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtManhaxuatban.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtMatailieu.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtSoxuatban.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSoluongnhap.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTentailieu.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                mabao = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                
            }
            catch { };
        }
        int xoa = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (xoa == 0)
            {
                xoa = 1;
                button1.Enabled = false;
                button2.Enabled = false;
                cls.LoadData2DataGridView(dataGridView1, "  select * from VIEW_BAOTAPCHI where MABAO not in (select MABAO from KYXUATBAN where MAKYXB in (select MAKYXB from PHIEUMUONBAO))");

            }
            else {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                string strDelete = "EXEC [dbo].[SP_DELETE_BAOTAPCHI] '"+ mabao + "'";
                cls.ThucThiSQLTheoKetNoi(strDelete);
                cls.LoadData2DataGridView(dataGridView1, "select *from VIEW_BAOTAPCHI");
                MessageBox.Show("Xóa thành công !!!");
                xoa= 0;
                button1.Enabled = true;
                button2.Enabled = true;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
                frmCapnhatNXB cnNXB = new frmCapnhatNXB();
                cnNXB.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmThemtailieu cnNXB = new frmThemtailieu();
            cnNXB.Show();
        }

        private void txtTentailieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.LoadData2CTextbox(txtMatailieu, "select MATAILIEU from TAILIEU where TENTAILIEU=N'" + txtTentailieu.Text + "'");
        }

        private void txtTennhaxuatban_SelectedIndexChanged(object sender, EventArgs e)
        {

            cls.LoadData2CTextbox(txtManhaxuatban, "select ID from NHAXUATBAN where TEN=N'" + txtTennhaxuatban.Text + "'");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            them = 0;
            sua = 0;
            xoa = 0;
            button2.Enabled = button3.Enabled=button1.Enabled = true;
            txtNamphathanh.Text =
                txtDinhky.Text =
                txtTennhaxuatban.Text =
                txtManhaxuatban.Text =
                txtMatailieu.Text =
                txtSoxuatban.Text =
                txtSoluongnhap.Text =
                txtTentailieu.Text = "";
        }
    }
}
