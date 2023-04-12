namespace cobaGuiSQL
{
    partial class Form4
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
            this.dtgv1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMA_GURU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GENDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAPEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TANGGAL_LAHIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GAJI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv1
            // 
            this.dtgv1.AllowUserToAddRows = false;
            this.dtgv1.AllowUserToDeleteRows = false;
            this.dtgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NIP,
            this.NAMA_GURU,
            this.GENDER,
            this.MAPEL,
            this.TANGGAL_LAHIR,
            this.GAJI});
            this.dtgv1.Location = new System.Drawing.Point(12, 132);
            this.dtgv1.Name = "dtgv1";
            this.dtgv1.ReadOnly = true;
            this.dtgv1.RowHeadersVisible = false;
            this.dtgv1.Size = new System.Drawing.Size(776, 150);
            this.dtgv1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NIP
            // 
            this.NIP.DataPropertyName = "NIP";
            this.NIP.HeaderText = "NIP";
            this.NIP.Name = "NIP";
            this.NIP.ReadOnly = true;
            this.NIP.Width = 120;
            // 
            // NAMA_GURU
            // 
            this.NAMA_GURU.DataPropertyName = "NAMA_GURU";
            this.NAMA_GURU.HeaderText = "NAMA GURU";
            this.NAMA_GURU.Name = "NAMA_GURU";
            this.NAMA_GURU.ReadOnly = true;
            this.NAMA_GURU.Width = 150;
            // 
            // GENDER
            // 
            this.GENDER.DataPropertyName = "GENDER";
            this.GENDER.HeaderText = "GENDER";
            this.GENDER.Name = "GENDER";
            this.GENDER.ReadOnly = true;
            this.GENDER.Width = 75;
            // 
            // MAPEL
            // 
            this.MAPEL.DataPropertyName = "MAPEL";
            this.MAPEL.HeaderText = "MAPEL";
            this.MAPEL.Name = "MAPEL";
            this.MAPEL.ReadOnly = true;
            this.MAPEL.Width = 120;
            // 
            // TANGGAL_LAHIR
            // 
            this.TANGGAL_LAHIR.DataPropertyName = "TANGGAL_LAHIR";
            this.TANGGAL_LAHIR.HeaderText = "TANGGAL LAHIR";
            this.TANGGAL_LAHIR.Name = "TANGGAL_LAHIR";
            this.TANGGAL_LAHIR.ReadOnly = true;
            // 
            // GAJI
            // 
            this.GAJI.DataPropertyName = "GAJI";
            this.GAJI.HeaderText = "GAJI";
            this.GAJI.Name = "GAJI";
            this.GAJI.ReadOnly = true;
            this.GAJI.Width = 110;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "DELETE ALL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "RESTORE ALL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgv1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMA_GURU;
        private System.Windows.Forms.DataGridViewTextBoxColumn GENDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAPEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TANGGAL_LAHIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn GAJI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}