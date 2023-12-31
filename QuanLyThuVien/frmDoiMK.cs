﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmDoiMK : Form
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMkMoi.Text.Length - 1 < 1)//kiểm tra mật khẩu mới xem co lờn hơn 6 ký tụ ko
                MessageBox.Show("mật khẩu mới quá ngắn");
            else
                if (txtMkMoi.Text.Length - 1 > 30)//kiểm tra mật khẩu mới xem có bé hơn 30 ký tụ ko
                    MessageBox.Show("mật khẩu mới quá dài");
                else
                    if (txtMkMoi.Text != txtXNhanLaiMk.Text)//kiểm tra mật khẩu mới và xác nhận mk co trung nha
                        MessageBox.Show("mật khẩu mới không trùng hãy nhập lại");
                    else
                        if (txtMkCu.Text != Main.MatKhau)//kiểm tra mật khẩu cũ
                            MessageBox.Show("Mật khẩu cũ sai hãy nhập lại mật khẩu");
                        else
                        {
                            try//thục hiên cau lệnh để thay đổi mật khẩu
                            {
                                string strUpdate = "Update NHANVIEN set MATKHAU='" + txtMkMoi.Text + "'where TENDANGNHAP='" + Main.TenDN + "' and MATKHAU='" + txtMkCu.Text + "'";
                                cls.ThucThiSQLTheoKetNoi(strUpdate);
                                MessageBox.Show("Đổi mật khẩu thành công");
                            }
                            catch (Exception E)
                            { MessageBox.Show("" + E.ToString()); }
                        }
        //    string strUpdate = "Update tblNhanVien set MATKHAU='" + textBox2.Text + "'where MATKHAU='" + textBox1.Text + "'";
        //    cls.ThucThiSQLTheoKetNoi(strUpdate);
        //    MessageBox.Show("Đổi mật khẩu thành công");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                txtMkCu.PasswordChar = '\0';
                txtMkMoi.PasswordChar = '\0';
                txtXNhanLaiMk.PasswordChar = '\0';
            }
            else
            {
                txtMkCu.PasswordChar = '*';
                txtMkMoi.PasswordChar = '*';
                txtXNhanLaiMk.PasswordChar = '*';
            }
            
        }

    }
}
