
namespace DentistToolClient
{
    partial class frmCancelDayAppointment
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCancelReason = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancelAppointment = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstAppointment);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Appointment to Cancel:";
            // 
            // lstAppointment
            // 
            this.lstAppointment.FormattingEnabled = true;
            this.lstAppointment.ItemHeight = 16;
            this.lstAppointment.Location = new System.Drawing.Point(7, 22);
            this.lstAppointment.Name = "lstAppointment";
            this.lstAppointment.Size = new System.Drawing.Size(427, 164);
            this.lstAppointment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cancellation Reason";
            // 
            // txtCancelReason
            // 
            this.txtCancelReason.Location = new System.Drawing.Point(130, 231);
            this.txtCancelReason.Name = "txtCancelReason";
            this.txtCancelReason.Size = new System.Drawing.Size(316, 20);
            this.txtCancelReason.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(284, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 33);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCancelAppointment
            // 
            this.btnCancelAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAppointment.Location = new System.Drawing.Point(65, 285);
            this.btnCancelAppointment.Name = "btnCancelAppointment";
            this.btnCancelAppointment.Size = new System.Drawing.Size(145, 33);
            this.btnCancelAppointment.TabIndex = 12;
            this.btnCancelAppointment.Text = "Cancel Appointment";
            this.btnCancelAppointment.UseVisualStyleBackColor = true;
            this.btnCancelAppointment.Click += new System.EventHandler(this.btnCancelAppointment_Click);
            // 
            // frmCancelDayAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 344);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCancelAppointment);
            this.Controls.Add(this.txtCancelReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCancelDayAppointment";
            this.Text = "Cancel Appointment";
            this.Load += new System.EventHandler(this.frmCancelDayAppointment_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstAppointment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCancelReason;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCancelAppointment;
    }
}