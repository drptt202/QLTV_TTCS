﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyThuVien
{
    public partial class rpDocGia : Form
    {
        public rpDocGia()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void BCDocGia_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        int thongke;
        int tongso;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.Enabled = true;

                cls.LoadData2DataGridView(dataGridView1, "select dg.SOTHEDOCGIA,dg.NGAYCAPTHE,dg.HO,dg.TEN, COUNT(*) as SOLANMUON from DOCGIA dg join PHIEUMUONSACH pm on pm.SOTHEDOCGIA=dg.SOTHEDOCGIA group by dg.SOTHEDOCGIA,dg.NGAYCAPTHE,dg.HO,dg.TEN ");
            }
            if (radioButton2.Checked)
            {

                cls.LoadData2DataGridView(dataGridView1,"  select * from DOCGIA where SOTHEDOCGIA not in (select SOTHEDOCGIA from PHIEUMUONSACH)");
            }
            if (radioButton3.Checked)
            {

                cls.LoadData2DataGridView(dataGridView1, "select dg.SOTHEDOCGIA, dg.NGAYCAPTHE, dg.HO, dg.TEN, dg.NGHENGHIEP, dg.PHAI, pm.TRANGTHAITRA from DOCGIA dg join PHIEUMUONSACH pm on dg.SOTHEDOCGIA =pm.SOTHEDOCGIA and pm.TRANGTHAITRA=0");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}
