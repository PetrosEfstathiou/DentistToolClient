
namespace DentistToolClient
{
    partial class UserControlAppointment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.ForeColor = System.Drawing.Color.Red;
            this.btCancel.Location = new System.Drawing.Point(378, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(27, 27);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "X";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.ForeColor = System.Drawing.Color.Green;
            this.btnFinish.Location = new System.Drawing.Point(350, 0);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(27, 27);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "V";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // UserControlAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Name = "UserControlAppointment";
            this.Size = new System.Drawing.Size(405, 27);
            this.Load += new System.EventHandler(this.UserControlAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinish;
    }
}
