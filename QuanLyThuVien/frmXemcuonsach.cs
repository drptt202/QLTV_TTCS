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
    public partial class frmXemcuonsach : Form
    {
        string lxb="";
        string tencuonsach="";
        string maLXB = "";
        public frmXemcuonsach(string malxb,string lanxuatban, string ten)
        {
            InitializeComponent();
            lxb = lanxuatban;
            tencuonsach=ten;
            maLXB = malxb;
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();

        private void frmXemcuonsach_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from VIEW_CUONSACH where TENTAILIEU=N'" + tencuonsach + "' and LANXUATBAN='"+lxb+"'");
            txtTencuonsach.Text = tencuonsach;
            txtMalanxuatban.Text = maLXB;
        }
        string idmax;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTinhtrang.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        int them = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(them== 0)
            {
                them = 1;
                txtSocuon.Text = "";
                button2.Enabled = button3.Enabled = false;
            }
            else
            {
                try
                {
                    string strInsert = "EXEC [dbo].[SP_ADD_CUONSACH] @SoLuongNhap = '"+txtSocuon.Text+"', @MaLanXB = '"+txtMalanxuatban.Text+"'";
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select * from VIEW_CUONSACH where TENTAILIEU=N'" + tencuonsach + "' and LANXUATBAN='" + lxb + "'");
                    MessageBox.Show("Thêm thành công"); them = 0;
                    button2.Enabled = button3.Enabled = true;
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
                txtSocuon.Text = "";
                button1.Enabled = button3.Enabled = false;
                label4.Visible = txtSocuon.Visible = false;
                label5.Visible = label2.Visible = txtID.Visible = txtTinhtrang.Visible = true;
            }
            else
            {
                try
                {
                    string strUpdate = "EXEC [dbo].[SP_UPDATE_CUONSACH] @ID = '"+txtID.Text+"', @TINHTRANG = N'"+txtTinhtrang.Text+"'";
                    cls.ThucThiSQLTheoKetNoi(strUpdate);
                    cls.LoadData2DataGridView(dataGridView1, "select * from VIEW_CUONSACH where TENTAILIEU=N'" + tencuonsach + "' and LANXUATBAN='" + lxb + "'");
                    MessageBox.Show("Sửa thành công"); them = 0;
                    button1.Enabled = button3.Enabled = true;

                    label4.Visible = txtSocuon.Visible = true;
                    label5.Visible = label2.Visible = txtID.Visible = txtTinhtrang.Visible = false;
                }
                catch { MessageBox.Show("Sửa thất bại"); };
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cls.KetNoi();
            Object M = cls.layGiaTri("select MAX(ID) from VIEW_CUONSACH where TENTAILIEU=N'" + tencuonsach + "' and LANXUATBAN='" + lxb + "'");
            idmax = Convert.ToString(M);

            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(txtID.Text != idmax) { MessageBox.Show("Chỉ nên xoá sách nhập thừa"); }
                else
                {
                try
                {
                    string strDelete = "EXEC [dbo].[SP_DELETE_CUONSACH] @ID = '"+txtID.Text+"'";
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select * from VIEW_CUONSACH where TENTAILIEU=N'" + tencuonsach + "' and LANXUATBAN='" + lxb + "'");
                    MessageBox.Show("Xóa thành công");
                }
                catch { MessageBox.Show("Xoá thất bại"); };

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            them = sua = 0;
            button1.Enabled = button2.Enabled = button3.Enabled = true;

            label4.Visible = txtSocuon.Visible = true;
            label5.Visible = label2.Visible = txtID.Visible = txtTinhtrang.Visible = false;
        }
    }
}
