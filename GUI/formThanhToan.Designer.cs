namespace _DACKUDQL
{
    partial class formThanhToan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMHD = new System.Windows.Forms.TextBox();
            this.txtMKH = new System.Windows.Forms.TextBox();
            this.txtTT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtgvHD = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã khách hàng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tổng tiền:";
            // 
            // txtMHD
            // 
            this.txtMHD.Enabled = false;
            this.txtMHD.Location = new System.Drawing.Point(119, 25);
            this.txtMHD.Name = "txtMHD";
            this.txtMHD.Size = new System.Drawing.Size(119, 20);
            this.txtMHD.TabIndex = 5;
            // 
            // txtMKH
            // 
            this.txtMKH.Enabled = false;
            this.txtMKH.Location = new System.Drawing.Point(119, 57);
            this.txtMKH.Name = "txtMKH";
            this.txtMKH.Size = new System.Drawing.Size(119, 20);
            this.txtMKH.TabIndex = 6;
            // 
            // txtTT
            // 
            this.txtTT.Enabled = false;
            this.txtTT.Location = new System.Drawing.Point(119, 89);
            this.txtTT.Name = "txtTT";
            this.txtTT.Size = new System.Drawing.Size(119, 20);
            this.txtTT.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thanh toán";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtgvHD
            // 
            this.dtgvHD.AllowUserToAddRows = false;
            this.dtgvHD.AllowUserToDeleteRows = false;
            this.dtgvHD.AllowUserToResizeColumns = false;
            this.dtgvHD.AllowUserToResizeRows = false;
            this.dtgvHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHD.Enabled = false;
            this.dtgvHD.Location = new System.Drawing.Point(25, 115);
            this.dtgvHD.Name = "dtgvHD";
            this.dtgvHD.Size = new System.Drawing.Size(213, 143);
            this.dtgvHD.TabIndex = 9;
            // 
            // formThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 299);
            this.Controls.Add(this.dtgvHD);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTT);
            this.Controls.Add(this.txtMKH);
            this.Controls.Add(this.txtMHD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "formThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.formThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMHD;
        private System.Windows.Forms.TextBox txtMKH;
        private System.Windows.Forms.TextBox txtTT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtgvHD;
    }
}