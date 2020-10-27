namespace geldAutomaatAdmin
{
    partial class adminBeginScherm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchCb = new System.Windows.Forms.ComboBox();
            this.searchTxb = new System.Windows.Forms.TextBox();
            this.userDgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameTxb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTxb = new System.Windows.Forms.TextBox();
            this.lastNameTxb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bankNumberTxb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::geldAutomaatAdmin.Properties.Resources.rabobank_logo;
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
            this.panel4.Controls.Add(this.searchCb);
            this.panel4.Controls.Add(this.searchTxb);
            this.panel4.Controls.Add(this.userDgv);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.firstNameTxb);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.registerBtn);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.passwordTxb);
            this.panel4.Controls.Add(this.lastNameTxb);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.bankNumberTxb);
            this.panel4.Location = new System.Drawing.Point(88, 144);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(627, 267);
            this.panel4.TabIndex = 14;
            // 
            // searchCb
            // 
            this.searchCb.FormattingEnabled = true;
            this.searchCb.Items.AddRange(new object[] {
            "firstName",
            "lastName",
            "bankNumber"});
            this.searchCb.Location = new System.Drawing.Point(384, 8);
            this.searchCb.Name = "searchCb";
            this.searchCb.Size = new System.Drawing.Size(121, 24);
            this.searchCb.TabIndex = 13;
            // 
            // searchTxb
            // 
            this.searchTxb.Location = new System.Drawing.Point(512, 8);
            this.searchTxb.Name = "searchTxb";
            this.searchTxb.Size = new System.Drawing.Size(100, 22);
            this.searchTxb.TabIndex = 12;
            this.searchTxb.TextChanged += new System.EventHandler(this.SearchTxb_TextChanged);
            // 
            // userDgv
            // 
            this.userDgv.AllowUserToAddRows = false;
            this.userDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.userDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDgv.Location = new System.Drawing.Point(248, 40);
            this.userDgv.Name = "userDgv";
            this.userDgv.RowHeadersWidth = 51;
            this.userDgv.RowTemplate.Height = 24;
            this.userDgv.Size = new System.Drawing.Size(376, 224);
            this.userDgv.TabIndex = 11;
            this.userDgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserDgv_CellEndEdit);
            this.userDgv.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDgv_UserDeletingRow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registreer u hier!:";
            // 
            // firstNameTxb
            // 
            this.firstNameTxb.Location = new System.Drawing.Point(16, 64);
            this.firstNameTxb.Name = "firstNameTxb";
            this.firstNameTxb.Size = new System.Drawing.Size(100, 22);
            this.firstNameTxb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "VOORNAAM";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(128, 232);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(104, 23);
            this.registerBtn.TabIndex = 10;
            this.registerBtn.Text = "Registreer";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "ACHTERNAAM";
            // 
            // passwordTxb
            // 
            this.passwordTxb.Location = new System.Drawing.Point(16, 232);
            this.passwordTxb.Name = "passwordTxb";
            this.passwordTxb.PasswordChar = '*';
            this.passwordTxb.Size = new System.Drawing.Size(100, 22);
            this.passwordTxb.TabIndex = 9;
            // 
            // lastNameTxb
            // 
            this.lastNameTxb.Location = new System.Drawing.Point(16, 120);
            this.lastNameTxb.Name = "lastNameTxb";
            this.lastNameTxb.Size = new System.Drawing.Size(100, 22);
            this.lastNameTxb.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(16, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "WACHTWOORD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "BANKREKENINGNUMMER";
            // 
            // bankNumberTxb
            // 
            this.bankNumberTxb.Location = new System.Drawing.Point(16, 176);
            this.bankNumberTxb.Name = "bankNumberTxb";
            this.bankNumberTxb.Size = new System.Drawing.Size(100, 22);
            this.bankNumberTxb.TabIndex = 6;
            // 
            // adminBeginScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "adminBeginScherm";
            this.Text = "Geldautomaat admin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.DataGridView userDgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameTxb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordTxb;
        private System.Windows.Forms.TextBox lastNameTxb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bankNumberTxb;
        private System.Windows.Forms.TextBox searchTxb;
        private System.Windows.Forms.ComboBox searchCb;
    }
}

