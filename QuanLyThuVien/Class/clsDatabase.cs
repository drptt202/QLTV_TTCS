using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace QuanLyThuVien.Class
{
    class clsDatabase
    {
        //Khai báo các chuỗi kết nối và các đối tượng
        public string strConnect = @"Data Source=MY-FLAPTOP;Initial Catalog=QLTV_TTCS;User ID=sa;Password=123123;Integrated Security=True";
        public SqlConnection sqlCon;
        public SqlCommand sqlCom;
        public SqlDataReader sqlRea;
        public SqlDataAdapter sqlAdap;
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable("QLTV_TTCS");

        //Phương thức kết nối tới CSDL SQL Server
        public void KetNoi()
        {
            sqlCon = new SqlConnection(strConnect);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        //Phương thức đóng kết nối tới CSDL
        public void NgatKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
        /// <param name="sql">Câu lệnh SQL: Insert, Update, Delete...</param>
        public void ThucThiSQLTheoKetNoi(string strSql)
        {
            KetNoi();
            //
        
            sqlCom = new SqlCommand(strSql, sqlCon);
            sqlCom.ExecuteNonQuery();
            //
            NgatKetNoi();
        }
        /// <param name="sql">Câu lệnh SQL: Insert, Update, Delete...</param>

        /// Phương thức Load dữ liệu lên Combobox
        /// <param name="cb">Tên của  Combobox</param>
        /// <param name="strSelect">Câu lệnh Select cần lấy dữ liệu cho Combobox</param>
        /// 
        public Object layGiaTri(string sql) //lay gia tri cua  cot dau tien trong bang 
        {
            sqlCom = new SqlCommand();
            sqlCom.CommandText = sql;
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Connection = sqlCon;

            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCom.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            return obj;
            //Ket qua de dau ? - de trong obj
        }
        public void LoadData2Combobox(ComboBox cb, string strSelect)
        {
            //Kết nối
            cb.Items.Clear();
            KetNoi();
            //Thực thi
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            //Load dữ liệu vào Combobox
            while (sqlRea.Read())
            {
                cb.Items.Add(sqlRea[0].ToString());
            }
            //Đóng kết nối
            NgatKetNoi();
        }

        public void LoadData2Checklist(CheckedListBox cl, string strSelect)
        {
            //Kết nối
            cl.Items.Clear();
            KetNoi();
            //Thực thi
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            //Load dữ liệu vào Combobox
            while (sqlRea.Read())
            {
                cl.Items.Add(sqlRea[0].ToString());
            }
            //Đóng kết nối
            NgatKetNoi();
        }

        public void LoadData2CTextbox(TextBox tb, string strSelect)
        {
            //Kết nối
            tb.Text = "";
            KetNoi();
            //Thực thi
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            //Load dữ liệu vào Textbox
            while (sqlRea.Read())
            {
                tb.Text=sqlRea[0].ToString();
            }
            //Đóng kết nối
            NgatKetNoi();
        }
        public void LoadData2Label(Label lb, string strSelect)
        {
            lb.Text = "";
            KetNoi();
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            while (sqlRea.Read())
            {
                lb.Text = sqlRea[0].ToString();
            }
            NgatKetNoi();
        }
        /// Phương thức Load dữ liệu lên DataGridView
        /// <param name="dg">Tên của DataGridView</param>
        /// <param name="strSelect">Câu lệnh Select cần lấy dữ liệu cho DataGridView</param>
        public void LoadData2DataGridView(DataGridView dg, string strSelect)
        {
            dt.Clear();
            //Fill vào DataTable
            sqlAdap = new SqlDataAdapter(strSelect, strConnect);
            sqlAdap.Fill(dt);
            dg.DataSource = dt;
        }
    }
}
