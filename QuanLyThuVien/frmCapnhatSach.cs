using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapnhatSach : Form
    {
        public frmCapnhatSach()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void capnhatsach_Load(object sender, EventArgs e)
        {
            
            cls.LoadData2DataGridView(dataGridView1, "select * from VIEW_TUASACH");
            cls.LoadData2Checklist(clTentacgia, "select TENTACGIA from TACGIA");
            cls.LoadData2Combobox(txtTentailieu, "select TENTAILIEU from TAILIEU where LOAITAILIEU =N'Sách'");
        }

        int them = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(them == 0)
            {
                them = 1;
                button2.Enabled = button3.Enabled = false;
                label4.Text = txtMasach.Text = txtMatacgia.Text = txtMatailieu.Text = txtTentailieu.Text = "";
                button5.Visible = false;
                for (int i = 0; i < clTentacgia.Items.Count; i++)
                {
                    clTentacgia.SetItemChecked(i, false);
                }
            }
            else
            {
                try
                {
                    string strInsert = "EXEC SP_ADD_TUASACH @MaTaiLieu = '"+txtMatailieu.Text+"' , @MaTacGiaList='"+txtMatacgia.Text+"'";
                    cls.ThucThiSQLTheoKetNoi(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select * from VIEW_TUASACH");
                    them = 0;
                    button2.Enabled = button3.Enabled = true;
                    MessageBox.Show("Thêm thành công ");
                }
                catch { MessageBox.Show("Thêm thất bại"); };
            }
           
            
        }

        int sua = 0;
        string masach;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                masach = txtMasach.Text;
                sua = 1;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {

                string strUpdate = "EXEC SP_UPDATE_TUASACH @MaSach = '"+txtMasach.Text+"', @MaTaiLieu='"+txtMatailieu.Text+"', @MaTacGiaList='"+txtMatacgia.Text+"'";
                cls.ThucThiSQLTheoKetNoi(strUpdate);
                cls.LoadData2DataGridView(dataGridView1, "select *from VIEW_TUASACH");
                button1.Enabled = true;
                button3.Enabled = true;
                sua = 0;
                MessageBox.Show("Sửa thành công");
                }
                catch { MessageBox.Show("Sửa thất bại"); };
            }
        }
        string malanxb = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < clTentacgia.Items.Count; i++)
            {
                clTentacgia.SetItemChecked(i, false);
            }
            try
            {
                string ten = "";
                ten = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                string[] arrListStr;
                if (ten.IndexOf(",") >0)
                {
                    arrListStr = ten.Split(", ");
                    for (int j = 0; j < arrListStr.Length ; j++)
                    {
                        for (int i = 0; i < clTentacgia.Items.Count; i++)
                        {
                            if (clTentacgia.Items[i].ToString() == arrListStr[j])
                            {
                                clTentacgia.SetItemChecked(i, true);
                            }
                        }
                    }
                }else
                {
                    for (int i = 0; i < clTentacgia.Items.Count; i++)
                    {
                        if (clTentacgia.Items[i].ToString() == ten)
                        {
                            clTentacgia.SetItemChecked(i, true);
                        }
                    }
                }
                txtMasach.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTentailieu.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                
                clTentacgia.Items.ToString();

            }
            catch { };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string strDelete = "EXEC SP_DELETE_TUASACH @MaSach = '" + txtMasach.Text +"'";
                cls.ThucThiSQLTheoKetNoi(strDelete);
                cls.LoadData2DataGridView(dataGridView1, "select *from VIEW_TUASACH");
                MessageBox.Show("Xóa thành công !!!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmXemlanxuatban xem = new frmXemlanxuatban(txtTentailieu.Text);
            xem.Show();
        }


        private void txtTentailieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.LoadData2CTextbox(txtMatailieu, "select MATAILIEU from TAILIEU where TENTAILIEU=N'" + txtTentailieu.Text + "'");

            label4.Text = "Xem kỳ xuất bản của " + txtTentailieu.Text;
            button5.Visible = true;
        }
        private void clTentacgia_Click(object sender, EventArgs e)
        {
            string result2 = " ";
            foreach (int indexChecked in clTentacgia.CheckedIndices)
            {
                string tmp = "";
                string result="";
                result = clTentacgia.Items[indexChecked].ToString();
                cls.KetNoi();
                cls.sqlCom = new SqlCommand("select MATACGIA from TACGIA where TENTACGIA=N'" + result + "'", cls.sqlCon);
                cls.sqlRea = cls.sqlCom.ExecuteReader();
                while (cls.sqlRea.Read())
                {
                    tmp = cls.sqlRea[0].ToString()+",";
                }
                cls.NgatKetNoi();
                result2 += tmp;
            }
            txtMatacgia.Text = result2.Remove(result2.Length-1);
        }

        private void clTentacgia_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clTentacgia.Items.Count; i++)
            {
                clTentacgia.SetItemChecked(i, false);
            }
            them = sua = 0;
            button1.Enabled = button2.Enabled = button3.Enabled = true;
            label4.Text = txtMasach.Text = txtMatacgia.Text = txtMatailieu.Text = txtTentailieu.Text = "";
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmThemtailieu them = new frmThemtailieu();
            them.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmCapnhatTG them = new frmCapnhatTG();
            them.Show();
        }
    }
}
