using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmXemlanxuatban : Form
    {
        string ten;
        string malxb;
        string masach;
        public frmXemlanxuatban(string tentailieu,string ms)
        {
            InitializeComponent();
            ten = tentailieu;
            masach = ms;
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void frmXemlanxuatban_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "EXEC[dbo].[SP_SEARCH_LANXB_IN_TUASACH] @MASACH = '"+masach+"'");
            cls.LoadData2Combobox(txtTennhaxuatban, "select TEN from NHAXUATBAN");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool check = false;
            if (dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() == "True")
            {
                check = true;
            }
            else
            {
                check = false;
            }
            label1.Text = "Xem danh sách cuốn sách của lần xuất bản " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            button1.Visible = true;
            
            malxb = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtGia.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtKhogiay.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtTennhaxuatban.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtLanxuatban.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMasach.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNamxuatban.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSotrang.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            checkBox1.Checked = check;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmXemcuonsach xem = new frmXemcuonsach(malxb,txtLanxuatban.Text,ten);

            xem.Show();
        }

        private void txtTennhaxuatban_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.LoadData2CTextbox(txtManhaxuatban, "select ID from NHAXUATBAN where TEN=N'" + txtTennhaxuatban.Text + "'");
        }
        int them = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (them == 0)
            {
                them = 1;
                button3.Enabled = button5.Enabled = false;
                txtGia.Text =
                txtKhogiay.Text =
                txtTennhaxuatban.Text =
                txtManhaxuatban.Text =
                txtLanxuatban.Text =
                txtMasach.Text =
                txtNamxuatban.Text =
                txtSotrang.Text = "";
                checkBox1.Checked = false;
            }
            else
            {
                try
                {
                    string check;
                    if (checkBox1.Checked == true)
                    {
                        check = "1";
                    }
                    else
                    {
                        check = "0";
                    }
                    string strInsert = "EXEC [dbo].[SP_ADD_LANXUATBAN] @LANXUATBAN = '"+txtLanxuatban.Text+"', @NAMXUATBAN = '"+txtNamxuatban.Text+"', @KHOGIAY = '"+txtKhogiay.Text+"', @SOTRANG = '"+txtSotrang.Text+"', @MANHAXB = '"+txtManhaxuatban.Text+"', @GIA = '"+txtGia.Text+"', @CODIACD = '"+check+"', @MASACH = '"+masach+"'";
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "EXEC[dbo].[SP_SEARCH_LANXB_IN_TUASACH] @MASACH = '" + masach + "'");

                    them = 0;
                    button3.Enabled = button5.Enabled = true;
                    MessageBox.Show("Thêm thành công");
                }
                catch { MessageBox.Show("Thêm thất bại"); };
            }
        }
        int sua = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                sua = 1;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {
                    string check;
                    if (checkBox1.Checked == true)
                    {
                        check = "1";
                    }
                    else
                    {
                        check = "0";
                    }
                    string strUpdate = "EXEC [dbo].[SP_UPDATE_LANXUATBAN] @MALANXB ='"+malxb+"', @LANXUATBAN = '" + txtLanxuatban.Text + "', @NAMXUATBAN = '" + txtNamxuatban.Text + "', @KHOGIAY = '" + txtKhogiay.Text + "', @SOTRANG = '" + txtSotrang.Text + "', @MANHAXB = '" + txtManhaxuatban.Text + "', @GIA = '" + txtGia.Text + "', @CODIACD = '" + check + "', @MASACH = '" + masach + "'";

                    cls.ThucThiSQLTheoKetNoi(strUpdate);
                    cls.LoadData2DataGridView(dataGridView1, "EXEC[dbo].[SP_SEARCH_LANXB_IN_TUASACH] @MASACH = '" + masach + "'");

                    button2.Enabled = true;
                    button3.Enabled = true;
                    sua = 0;
                    MessageBox.Show("Sửa thành công");
                }
                catch { MessageBox.Show("Sửa thất bại "); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string strDelete = "EXEC [dbo].[SP_DELETE_LANXUATBAN] @MALANXB = '"+malxb+"'";
                cls.ThucThiSQLTheoKetNoi(strDelete);
                cls.LoadData2DataGridView(dataGridView1, "EXEC[dbo].[SP_SEARCH_LANXB_IN_TUASACH] @MASACH = '" + masach + "'");
                MessageBox.Show("Xóa thành công !!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = button3.Enabled = button5.Enabled = true;
            them = sua = 0;
            txtGia.Text =
            txtKhogiay.Text =
            txtTennhaxuatban.Text =
            txtManhaxuatban.Text =
            txtLanxuatban.Text =
            txtMasach.Text =
            txtNamxuatban.Text =
            txtSotrang.Text = "";
            checkBox1.Checked = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

    }
}
