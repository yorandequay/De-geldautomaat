namespace geldAutomaat
{
    partial class gebruikerScherm
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.balanceLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBankNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.depositBtn = new System.Windows.Forms.Button();
            this.withdrawBtn = new System.Windows.Forms.Button();
            this.transactionsBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(184, 8);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 17);
            this.lblUsername.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.balanceLbl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblBankNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(216, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 1;
            // 
            // balanceLbl
            // 
            this.balanceLbl.AutoSize = true;
            this.balanceLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.balanceLbl.Location = new System.Drawing.Point(8, 72);
            this.balanceLbl.Name = "balanceLbl";
            this.balanceLbl.Size = new System.Drawing.Size(0, 17);
            this.balanceLbl.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Saldo";
            // 
            // lblBankNumber
            // 
            this.lblBankNumber.AutoSize = true;
            this.lblBankNumber.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBankNumber.Location = new System.Drawing.Point(8, 32);
            this.lblBankNumber.Name = "lblBankNumber";
            this.lblBankNumber.Size = new System.Drawing.Size(0, 17);
            this.lblBankNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "BANKREKENINGNUMMER:";
            // 
            // depositBtn
            // 
            this.depositBtn.Location = new System.Drawing.Point(216, 160);
            this.depositBtn.Name = "depositBtn";
            this.depositBtn.Size = new System.Drawing.Size(200, 23);
            this.depositBtn.TabIndex = 2;
            this.depositBtn.Text = "STORTEN";
            this.depositBtn.UseVisualStyleBackColor = true;
            this.depositBtn.Click += new System.EventHandler(this.DepositBtn_Click);
            // 
            // withdrawBtn
            // 
            this.withdrawBtn.Location = new System.Drawing.Point(216, 184);
            this.withdrawBtn.Name = "withdrawBtn";
            this.withdrawBtn.Size = new System.Drawing.Size(200, 23);
            this.withdrawBtn.TabIndex = 3;
            this.withdrawBtn.Text = "OPNEMEN";
            this.withdrawBtn.UseVisualStyleBackColor = true;
            this.withdrawBtn.Click += new System.EventHandler(this.WithdrawBtn_Click);
            // 
            // transactionsBtn
            // 
            this.transactionsBtn.Location = new System.Drawing.Point(216, 208);
            this.transactionsBtn.Name = "transactionsBtn";
            this.transactionsBtn.Size = new System.Drawing.Size(200, 23);
            this.transactionsBtn.TabIndex = 4;
            this.transactionsBtn.Text = "TRANSACTIES";
            this.transactionsBtn.UseVisualStyleBackColor = true;
            this.transactionsBtn.Click += new System.EventHandler(this.TransactionsBtn_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.depositBtn);
            this.panel3.Controls.Add(this.transactionsBtn);
            this.panel3.Controls.Add(this.withdrawBtn);
            this.panel3.Location = new System.Drawing.Point(88, 144);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 264);
            this.panel3.TabIndex = 8;
            // 
            // gebruikerScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "gebruikerScherm";
            this.Text = "gebruikerScherm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label balanceLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBankNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button depositBtn;
        private System.Windows.Forms.Button withdrawBtn;
        private System.Windows.Forms.Button transactionsBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}