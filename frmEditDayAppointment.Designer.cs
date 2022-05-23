
namespace DentistToolClient
{
    partial class frmEditDayAppointment
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
            this.lstAppointment = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbHour = new System.Windows.Forms.ComboBox();
            this.cmbDuration = new System.Windows.Forms.ComboBox();
            this.txtAppReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstAppointment);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Appointment to Edit:";
            // 
            // lstAppointment
            // 
            this.lstAppointment.FormattingEnabled = true;
            this.lstAppointment.ItemHeight = 16;
            this.lstAppointment.Location = new System.Drawing.Point(7, 22);
            this.lstAppointment.Name = "lstAppointment";
            this.lstAppointment.Size = new System.Drawing.Size(427, 164);
            this.lstAppointment.TabIndex = 0;
            this.lstAppointment.SelectedIndexChanged += new System.EventHandler(this.lstAppointment_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbHour);
            this.groupBox3.Controls.Add(this.cmbDuration);
            this.groupBox3.Controls.Add(this.txtAppReason);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 233);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 140);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Appointment Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Time";
            // 
            // cmbHour
            // 
            this.cmbHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHour.FormattingEnabled = true;
            this.cmbHour.Items.AddRange(new object[] {
            "07:00",
            "07:15",
            "07:30",
            "07:45",
            "08:00",
            "08:15",
            "08:30",
            "08:45",
            "09:00",
            "09:15",
            "09:30",
            "09:45",
            "10:00",
            "10:15",
            "10:30",
            "10:45",
            "11:00",
            "11:15",
            "11:30",
            "11:45",
            "12:00",
            "12:15",
            "12:30",
            "12:45",
            "13:00",
            "13:15",
            "13:30",
            "13:45",
            "14:00",
            "14:15",
            "14:30",
            "14:45",
            "15:00",
            "15:15",
            "15:30",
            "15:45",
            "16:00",
            "16:15",
            "16:30",
            "16:45",
            "17:00",
            "17:15",
            "17:30",
            "17:45",
            "18:00",
            "18:15",
            "18:30",
            "18:45",
            "19:00",
            "19:15",
            "19:30",
            "19:45",
            "20:00"});
            this.cmbHour.Location = new System.Drawing.Point(110, 25);
            this.cmbHour.Name = "cmbHour";
            this.cmbHour.Size = new System.Drawing.Size(78, 24);
            this.cmbHour.TabIndex = 17;
            // 
            // cmbDuration
            // 
            this.cmbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuration.FormattingEnabled = true;
            this.cmbDuration.Items.AddRange(new object[] {
            "30",
            "45",
            "60",
            "75",
            "90",
            "105",
            "120"});
            this.cmbDuration.Location = new System.Drawing.Point(194, 63);
            this.cmbDuration.Name = "cmbDuration";
            this.cmbDuration.Size = new System.Drawing.Size(121, 24);
            this.cmbDuration.TabIndex = 16;
            // 
            // txtAppReason
            // 
            this.txtAppReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppReason.Location = new System.Drawing.Point(194, 97);
            this.txtAppReason.Name = "txtAppReason";
            this.txtAppReason.Size = new System.Drawing.Size(240, 22);
            this.txtAppReason.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Appointment Reason";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Duration (minutes)";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(55, 388);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(145, 33);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Update Appointment";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(274, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 33);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmEditDayAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 439);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEditDayAppointment";
            this.Text = "Edit Appointment";
            this.Load += new System.EventHandler(this.frmEditAppointment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstAppointment;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbHour;
        private System.Windows.Forms.ComboBox cmbDuration;
        private System.Windows.Forms.TextBox txtAppReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
    }
}