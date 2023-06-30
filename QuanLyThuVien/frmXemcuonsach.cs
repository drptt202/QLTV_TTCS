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
        public frmXemcuonsach(string lanxuatban, string ten)
        {
            InitializeComponent();
            lxb = lanxuatban;
            tencuonsach=ten;
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();

        private void frmXemcuonsach_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from VIEW_CUONSACH where TENTAILIEU=N'" + tencuonsach + "' and LANXUATBAN='"+lxb+"'");
        }
    }
}
