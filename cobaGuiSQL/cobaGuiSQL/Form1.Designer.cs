namespace cobaGuiSQL
{
    partial class Form1
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
            this.Insert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dtgv1 = new System.Windows.Forms.DataGridView();
            this.NIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMA_GURU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GENDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAPEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TANGGAL_LAHIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GAJI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(12, 53);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(75, 23);
            this.Insert.TabIndex = 0;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtgv1
            // 
            this.dtgv1.AllowUserToAddRows = false;
            this.dtgv1.AllowUserToDeleteRows = false;
            this.dtgv1.AllowUserToResizeRows = false;
            this.dtgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NIP,
            this.NAMA_GURU,
            this.GENDER,
            this.MAPEL,
            this.TANGGAL_LAHIR,
            this.GAJI});
            this.dtgv1.Location = new System.Drawing.Point(12, 82);
            this.dtgv1.Name = "dtgv1";
            this.dtgv1.ReadOnly = true;
            this.dtgv1.RowHeadersVisible = false;
            this.dtgv1.ShowEditingIcon = false;
            this.dtgv1.Size = new System.Drawing.Size(835, 150);
            this.dtgv1.TabIndex = 0;
            // 
            // NIP
            // 
            this.NIP.DataPropertyName = "NIP";
            this.NIP.HeaderText = "NIP";
            this.NIP.Name = "NIP";
            this.NIP.ReadOnly = true;
            // 
            // NAMA_GURU
            // 
            this.NAMA_GURU.DataPropertyName = "NAMA_GURU";
            this.NAMA_GURU.HeaderText = "NAMA GURU";
            this.NAMA_GURU.Name = "NAMA_GURU";
            this.NAMA_GURU.ReadOnly = true;
            // 
            // GENDER
            // 
            this.GENDER.DataPropertyName = "GENDER";
            this.GENDER.HeaderText = "GENDER";
            this.GENDER.Name = "GENDER";
            this.GENDER.ReadOnly = true;
            // 
            // MAPEL
            // 
            this.MAPEL.DataPropertyName = "MAPEL";
            this.MAPEL.HeaderText = "MAPEL";
            this.MAPEL.Name = "MAPEL";
            this.MAPEL.ReadOnly = true;
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.dtgv1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMA_GURU;
        private System.Windows.Forms.DataGridViewTextBoxColumn GENDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAPEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TANGGAL_LAHIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn GAJI;
    }
}

