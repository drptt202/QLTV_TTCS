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
    public partial class frmThongtinBao : Form
    {
        public frmThongtinBao()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new Class.clsDatabase();
        private void frmThongtinBao_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "Select * from VIEW_BAOTAPCHI");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
