namespace geldAutomaat
{
    partial class transacties
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
            this.transactionsDgv = new System.Windows.Forms.DataGridView();
            this.userScreenBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // transactionsDgv
            // 
            this.transactionsDgv.AllowUserToAddRows = false;
            this.transactionsDgv.AllowUserToDeleteRows = false;
            this.transactionsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionsDgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.transactionsDgv.Location = new System.Drawing.Point(0, 0);
            this.transactionsDgv.Name = "transactionsDgv";
            this.transactionsDgv.ReadOnly = true;
            this.transactionsDgv.RowHeadersWidth = 51;
            this.transactionsDgv.RowTemplate.Height = 24;
            this.transactionsDgv.Size = new System.Drawing.Size(496, 264);
            this.transactionsDgv.TabIndex = 0;
            // 
            // userScreenBtn
            // 
            this.userScreenBtn.Location = new System.Drawing.Point(520, 16);
            this.userScreenBtn.Name = "userScreenBtn";
            this.userScreenBtn.Size = new System.Drawing.Size(75, 23);
            this.userScreenBtn.TabIndex = 1;
            this.userScreenBtn.Text = "< BACK";
            this.userScreenBtn.UseVisualStyleBackColor = true;
            this.userScreenBtn.Click += new System.EventHandler(this.UserScreenBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::geldAutomaat.Properties.Resources.rabobank_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.panel4.Controls.Add(this.transactionsDgv);
            this.panel4.Controls.Add(this.userScreenBtn);
            this.panel4.Location = new System.Drawing.Point(88, 144);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(624, 264);
            this.panel4.TabIndex = 10;
            // 
            // transacties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "transacties";
            this.Text = "transacties";
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView transactionsDgv;
        private System.Windows.Forms.Button userScreenBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
    }
}