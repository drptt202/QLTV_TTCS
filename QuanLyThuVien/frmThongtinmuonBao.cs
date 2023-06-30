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
    public partial class frmThongtinmuonBao : Form
    {
        public frmThongtinmuonBao()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void muonBao_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from PHIEUMUONBAO");
            cls.LoadData2Combobox(txtMakyxuatban, "select MAKYXB from KYXUATBAN");
            cls.LoadData2Combobox(txtManhanvienlap, "select MANHANVIEN from NHANVIEN");
            cls.LoadData2Combobox(txtSothedocgia, "select SOTHEDOCGIA from DOCGIA");

        }

        int them = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (them == 0)
            {
                them = 1;
                button2.Enabled = button3.Enabled = false;
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
                    string strInsert = "EXEC [dbo].[SP_ADD_PHIEUMUONBAO] @NgayMuon='" + txtNgaymuon.Text + "',@NgayTra='" + txtNgaytra.Text + "',@TrangThaiTra='" + check + "',@SoTheDocGia='" + txtSothedocgia.Text + "',@MaKyXB='" + txtMakyxuatban.Text + "',@MaNhanVienLap='" + txtManhanvienlap.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.ThucThiSQLTheoKetNoi("[dbo].[SP_UPDATE_SOLUONGCON]");
                    cls.LoadData2DataGridView(dataGridView1, "select *from PHIEUMUONBAO");
                    MessageBox.Show("Thêm thành công");
                    them = 0;
                    button2.Enabled = button3.Enabled = true;
                }
                catch { MessageBox.Show("Thêm thất bại"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string strDelete = "EXEC [dbo].[SP_DELETE_PHIEUMUONBAO] '" + txtMamuon.Text + "'";
                cls.ThucThiSQLTheoKetNoi(strDelete);
                cls.ThucThiSQLTheoKetNoi("[dbo].[SP_UPDATE_SOLUONGCON]");

                cls.LoadData2DataGridView(dataGridView1, "select *from PHIEUMUONBAO");
                MessageBox.Show("Xóa thành công !!!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool check = false;
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
                txtMamuon.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNgaymuon.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNgaytra.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                checkBox1.Checked = check;
                txtSothedocgia.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMakyxuatban.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtManhanvienlap.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { };
        }
        int sua = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                sua = 1;
                button1.Enabled = false;
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

                    string strUpdate = "EXEC [dbo].[SP_UPDATE_PHIEUMUONBAO] @MaMuon='" + txtMamuon.Text + "', @NgayMuon='" + txtNgaymuon.Text + "',@NgayTra='" + txtNgaytra.Text + "',@TrangThaiTra='" + check + "',@SoTheDocGia='" + txtSothedocgia.Text + "',@MaKyXB='" + txtMakyxuatban.Text + "',@MaNhanVienLap='" + txtManhanvienlap.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strUpdate);
                    cls.ThucThiSQLTheoKetNoi("[dbo].[SP_UPDATE_SOLUONGCON]");
                    cls.LoadData2DataGridView(dataGridView1, "select *from PHIEUMUONBAO");
                    button1.Enabled = true;
                    button3.Enabled = true;
                    MessageBox.Show("Sửa thành công");
                    sua = 0;
                }
                catch { MessageBox.Show("Sửa thất bại"); };
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            them = sua = 0;
            button1.Enabled = button2.Enabled = button3.Enabled = true;
        }
    }
}

