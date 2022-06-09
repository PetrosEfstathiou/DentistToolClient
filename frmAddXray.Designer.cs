
namespace DentistToolClient
{
    partial class frmAddXray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddXray));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstPatients = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdbTel = new System.Windows.Forms.RadioButton();
            this.rdbID = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblpath = new System.Windows.Forms.Label();
            this.txtXrayName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddXray = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstPatients);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.rdbTel);
            this.groupBox2.Controls.Add(this.rdbID);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 134);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Patient";
            // 
            // lstPatients
            // 
            this.lstPatients.FormattingEnabled = true;
            this.lstPatients.ItemHeight = 16;
            this.lstPatients.Location = new System.Drawing.Point(183, 22);
            this.lstPatients.Name = "lstPatients";
            this.lstPatients.Size = new System.Drawing.Size(259, 100);
            this.lstPatients.TabIndex = 5;
            this.lstPatients.SelectedIndexChanged += new System.EventHandler(this.lstPatients_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(45, 65);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 22);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(45, 94);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdbTel
            // 
            this.rdbTel.AutoSize = true;
            this.rdbTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTel.Location = new System.Drawing.Point(45, 42);
            this.rdbTel.Name = "rdbTel";
            this.rdbTel.Size = new System.Drawing.Size(86, 20);
            this.rdbTel.TabIndex = 2;
            this.rdbTel.TabStop = true;
            this.rdbTel.Text = "Phone No";
            this.rdbTel.UseVisualStyleBackColor = true;
            this.rdbTel.CheckedChanged += new System.EventHandler(this.rdbTel_CheckedChanged);
            // 
            // rdbID
            // 
            this.rdbID.AutoSize = true;
            this.rdbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbID.Location = new System.Drawing.Point(45, 19);
            this.rdbID.Name = "rdbID";
            this.rdbID.Size = new System.Drawing.Size(39, 20);
            this.rdbID.TabIndex = 1;
            this.rdbID.TabStop = true;
            this.rdbID.Text = "ID";
            this.rdbID.UseVisualStyleBackColor = true;
            this.rdbID.CheckedChanged += new System.EventHandler(this.rdbID_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 282);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblpath);
            this.groupBox1.Controls.Add(this.txtXrayName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 135);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xray Details";
            // 
            // lblpath
            // 
            this.lblpath.AutoSize = true;
            this.lblpath.Location = new System.Drawing.Point(19, 106);
            this.lblpath.Name = "lblpath";
            this.lblpath.Size = new System.Drawing.Size(0, 16);
            this.lblpath.TabIndex = 19;
            // 
            // txtXrayName
            // 
            this.txtXrayName.Location = new System.Drawing.Point(100, 25);
            this.txtXrayName.Name = "txtXrayName";
            this.txtXrayName.Size = new System.Drawing.Size(221, 22);
            this.txtXrayName.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Xray Name";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(167, 62);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(112, 33);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "Select Xray";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 319);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview";
            // 
            // btnAddXray
            // 
            this.btnAddXray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddXray.Location = new System.Drawing.Point(83, 640);
            this.btnAddXray.Name = "btnAddXray";
            this.btnAddXray.Size = new System.Drawing.Size(112, 33);
            this.btnAddXray.TabIndex = 20;
            this.btnAddXray.Text = "Upload Xray";
            this.btnAddXray.UseVisualStyleBackColor = true;
            this.btnAddXray.Click += new System.EventHandler(this.btnAddXray_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(260, 639);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(154, 34);
            this.btnMainMenu.TabIndex = 24;
            this.btnMainMenu.Text = "Back to Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // frmAddXray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 741);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnAddXray);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddXray";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Xray to Patient";
            this.Load += new System.EventHandler(this.frmAddXray_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstPatients;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdbTel;
        private System.Windows.Forms.RadioButton rdbID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtXrayName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddXray;
        private System.Windows.Forms.Label lblpath;
        private System.Windows.Forms.Button btnMainMenu;
    }
}