using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QuanLyThuVien.Class;

namespace QuanLyThuVien
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Transparent;
            label7.BackColor = System.Drawing.Color.Transparent;
            label9.BackColor = System.Drawing.Color.Transparent;
            label8.BackColor = System.Drawing.Color.Transparent;
            label11.BackColor = System.Drawing.Color.Transparent;

            lbTK.Hide();
            lbCV.Hide();
            label11.Hide();

        }
        public static string TenDN, MatKhau, Quyen,Ho,Ten;

        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void button1_Click(object sender, EventArgs e)
        {
            TenDN = txtTenDangNhap.Text;
            MatKhau = txtMatKhau.Text;
            if (TenDN != "")
            {
                object Q = cls.layGiaTri("select CHUCVU from NHANVIEN where TENDANGNHAP='" + TenDN + "' and MatKhau='" + MatKhau + "'");
                object H = cls.layGiaTri("select HO from NHANVIEN where TENDANGNHAP='" + TenDN + "' and MatKhau='" + MatKhau + "'");
                object T = cls.layGiaTri("select TEN from NHANVIEN where TENDANGNHAP='" + TenDN + "' and MatKhau='" + MatKhau + "'");

                if (Q == null)
                {
                    MessageBox.Show("Sai tài khoản");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công");
                    Quyen = Convert.ToString(Q);
                    Ho = Convert.ToString(H);
                    Ten = Convert.ToString(T);
                    if (Quyen == "Nhân viên")
                    {
                        groupBox2.Enabled = true;
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        tìmKiếmBáoTạpChíToolStripMenuItem.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = false;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtBáoTạpChíToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem1.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnBToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        báoTạpChíToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = false;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                        đăngXuấtToolStripMenuItem.Enabled = true;
                    }
                    if (Quyen == "Quản lý")
                    {
                        groupBox2.Enabled = true;
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        tìmKiếmBáoTạpChíToolStripMenuItem.Enabled = true;
                        KiêmTratoolStripMenuItem1.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = true;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtBáoTạpChíToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem1.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnBToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        báoTạpChíToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = true;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                        đăngXuấtToolStripMenuItem.Enabled = true;
                    }
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";

                    lbTK.Text = "Tài khoản: " + TenDN;
                    lbCV.Text = "Chức vụ:   " + Quyen;
                    label11.Text = "Nhân viên: "+Ho + " " + Ten;
                    label10.Hide();
                    label2.Hide();
                    label3.Hide();
                    txtTenDangNhap.Hide();
                    txtMatKhau.Hide();
                    button1.Hide();
                    lbCV.Show();
                    lbTK.Show();
                    label11.Show();

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                cls.KetNoi();
            }
            catch { MessageBox.Show("Không thể kết nối"); }
        }

        private void cậpNhậtSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapnhatSach cnsach = new frmCapnhatSach();
            cnsach.Show();
        }



        private void cậpNhậtBáoTạpChíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapnhatBao cnbao = new frmCapnhatBao();
            cnbao.Show();
        }

        private void cậpNhậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCapnhatDocgia cndocgia = new frmCapnhatDocgia();
            cndocgia.Show();

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void cậpNhậtTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapnhatTG cnTG = new frmCapnhatTG();
            cnTG.Show();
        }

        private void cậpNhậtNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapnhatNXB cnNXB = new frmCapnhatNXB();
            cnNXB.Show();
        }


        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMK doimatkhau = new frmDoiMK();
            doimatkhau.Show();
        }

        private void cậpNhậtThôngTinMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinmuonSach T = new frmThongtinmuonSach();
            T.Show();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangky T = new frmDangky();
            T.Show();
        }

        private void tìnhTrạngSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpSach BCTTS = new rpSach();
            BCTTS.Show();
        }

        private void sốĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpDocGia BCDG = new rpDocGia();
            BCDG.Show();
        }
        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinTacgia ttTG = new frmThongtinTacgia();
            ttTG.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinNXB ttnxb = new frmThongtinNXB();
            ttnxb.Show();
        }


        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinSach ttsach = new frmThongtinSach();
            ttsach.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinDocgia ttDG = new frmThongtinDocgia();
            ttDG.Show();
        }



  

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        

        private void Main_Load_1(object sender, EventArgs e)
        {

        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tìmKiếmBáoTạpChíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimkiemBao search = new frmTimkiemBao();
            search.Show();
        }

        private void tìnhTrạngBáoTạpChíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpBao rp = new rpBao();
            rp.Show();
        }

        private void cậpNhậtThôngTinMượnBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinmuonBao A = new frmThongtinmuonBao();
            A.Show();
        }

        private void báoTạpChíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongtinBao B = new frmThongtinBao();
            B.Show();
        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void Main_Load_2(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       

       

        

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenDN = MatKhau = Quyen = "";
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            quảnLyToolStripMenuItem.Enabled = false;
            tìmKiếmToolStripMenuItem.Enabled = false;
            tìmKiếmSáchToolStripMenuItem.Enabled = false;
            KiêmTratoolStripMenuItem1.Enabled = false;
            tìmKiếmĐGToolStripMenuItem.Enabled = false;
            cậpNhậtToolStripMenuItem.Enabled = false;
            mượnSáchToolStripMenuItem.Enabled = false;
            báoCáoToolStripMenuItem.Enabled = false;
            cậpNhậtSáchToolStripMenuItem.Enabled = false;
            cậpNhậtTácGiảToolStripMenuItem.Enabled = false;
            cậpNhậtToolStripMenuItem1.Enabled = false;
            cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = false;
            cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = false;
            tácGiảToolStripMenuItem.Enabled = false;
            nhàXuấtBảnToolStripMenuItem.Enabled = false;
            độcGiảToolStripMenuItem.Enabled = false;
            sáchToolStripMenuItem.Enabled = false;
            tạoTàiKhoảnToolStripMenuItem.Enabled = false;
            đổiMậtKhẩuToolStripMenuItem.Enabled = false;
            lbTK.Hide();
            lbCV.Hide();
            label11.Hide();
            label10.Show();
            label2.Show();
            label3.Show();
            txtTenDangNhap.Show();
            txtMatKhau.Show();
            button1.Show();
        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimkiemSach search = new frmTimkiemSach();
            search.Show();
        }

      

        private void tìmKiếmĐGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimkiemDocgia Dg = new frmTimkiemDocgia();
            Dg.Show();
        }

        private void KiêmTratoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmThongtinNV K = new frmThongtinNV();
            K.Show();
        }

    }
}
