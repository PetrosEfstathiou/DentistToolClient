
namespace DentistToolClient
{
    partial class UserControlDays
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
            this.lblday = new System.Windows.Forms.Label();
            this.lblApps = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblday
            // 
            this.lblday.AutoSize = true;
            this.lblday.Location = new System.Drawing.Point(16, 19);
            this.lblday.Name = "lblday";
            this.lblday.Size = new System.Drawing.Size(19, 13);
            this.lblday.TabIndex = 1;
            this.lblday.Text = "00";
            // 
            // lblApps
            // 
            this.lblApps.AutoSize = true;
            this.lblApps.Location = new System.Drawing.Point(72, 45);
            this.lblApps.Name = "lblApps";
            this.lblApps.Size = new System.Drawing.Size(0, 13);
            this.lblApps.TabIndex = 2;
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblApps);
            this.Controls.Add(this.lblday);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(159, 75);
            this.Load += new System.EventHandler(this.UserControlDays_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblday;
        private System.Windows.Forms.Label lblApps;
    }
}
