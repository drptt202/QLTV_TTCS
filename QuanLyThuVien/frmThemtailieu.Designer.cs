namespace QuanLyThuVien
{
    partial class frmThemtailieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoaitailieu = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTentailieu = new System.Windows.Forms.TextBox();
            this.txtMatailieu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoaitailieu);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtTentailieu);
            this.groupBox1.Controls.Add(this.txtMatailieu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(13, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(547, 196);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập đầy đủ các thông tin";
            // 
            // txtLoaitailieu
            // 
            this.txtLoaitailieu.FormattingEnabled = true;
            this.txtLoaitailieu.Items.AddRange(new object[] {
            "Sách",
            "Báo-Tạp chí"});
            this.txtLoaitailieu.Location = new System.Drawing.Point(183, 101);
            this.txtLoaitailieu.Name = "txtLoaitailieu";
            this.txtLoaitailieu.Size = new System.Drawing.Size(247, 28);
            this.txtLoaitailieu.TabIndex = 32;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(197, 137);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(172, 32);
            this.button6.TabIndex = 31;
            this.button6.Text = "Thêm tài liệu";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(183, 34);
            this.txtMa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(247, 27);
            this.txtMa.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(83, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Loại tài liệu :";
            // 
            // txtTentailieu
            // 
            this.txtTentailieu.Location = new System.Drawing.Point(183, 66);
            this.txtTentailieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTentailieu.Name = "txtTentailieu";
            this.txtTentailieu.Size = new System.Drawing.Size(247, 27);
            this.txtTentailieu.TabIndex = 5;
            // 
            // txtMatailieu
            // 
            this.txtMatailieu.Location = new System.Drawing.Point(758, 30);
            this.txtMatailieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatailieu.Name = "txtMatailieu";
            this.txtMatailieu.Size = new System.Drawing.Size(33, 27);
            this.txtMatailieu.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 67);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tên tài liệu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Mã tài liệu :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 242);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(547, 196);
            this.dataGridView1.TabIndex = 11;
            // 
            // frmThemtailieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThemtailieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm tài liệu";
            this.Load += new System.EventHandler(this.frmThemtailieu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox txtLoaitailieu;
        private Button button6;
        private TextBox txtMa;
        private Label label12;
        private TextBox txtTentailieu;
        private TextBox txtMatailieu;
        private Label label7;
        private Label label6;
        private DataGridView dataGridView1;
    }
}