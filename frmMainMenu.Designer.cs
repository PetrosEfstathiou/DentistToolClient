
namespace DentistToolClient
{
    partial class frmMainMenu
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
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.gbPatient = new System.Windows.Forms.GroupBox();
            this.btnViewPatient = new System.Windows.Forms.Button();
            this.btnEditPatient = new System.Windows.Forms.Button();
            this.gbDoctor = new System.Windows.Forms.GroupBox();
            this.btnEditDoctor = new System.Windows.Forms.Button();
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.gbXray = new System.Windows.Forms.GroupBox();
            this.btnDeleteXray = new System.Windows.Forms.Button();
            this.btnAddXray = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.gbPatient.SuspendLayout();
            this.gbDoctor.SuspendLayout();
            this.gbXray.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.Location = new System.Drawing.Point(62, 25);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(192, 34);
            this.btnAddPatient.TabIndex = 0;
            this.btnAddPatient.Text = "Add Patient";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // gbPatient
            // 
            this.gbPatient.Controls.Add(this.btnViewPatient);
            this.gbPatient.Controls.Add(this.btnEditPatient);
            this.gbPatient.Controls.Add(this.btnAddPatient);
            this.gbPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPatient.Location = new System.Drawing.Point(12, 12);
            this.gbPatient.Name = "gbPatient";
            this.gbPatient.Size = new System.Drawing.Size(308, 167);
            this.gbPatient.TabIndex = 2;
            this.gbPatient.TabStop = false;
            this.gbPatient.Text = "Patient Services";
            // 
            // btnViewPatient
            // 
            this.btnViewPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPatient.Location = new System.Drawing.Point(62, 105);
            this.btnViewPatient.Name = "btnViewPatient";
            this.btnViewPatient.Size = new System.Drawing.Size(192, 34);
            this.btnViewPatient.TabIndex = 2;
            this.btnViewPatient.Text = "View Patient History";
            this.btnViewPatient.UseVisualStyleBackColor = true;
            this.btnViewPatient.Click += new System.EventHandler(this.btnViewPatient_Click);
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPatient.Location = new System.Drawing.Point(62, 65);
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(192, 34);
            this.btnEditPatient.TabIndex = 1;
            this.btnEditPatient.Text = "Edit/Delete Patient";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            this.btnEditPatient.Click += new System.EventHandler(this.btnEditPatient_Click);
            // 
            // gbDoctor
            // 
            this.gbDoctor.Controls.Add(this.btnEditDoctor);
            this.gbDoctor.Controls.Add(this.btnAddDoctor);
            this.gbDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDoctor.Location = new System.Drawing.Point(346, 185);
            this.gbDoctor.Name = "gbDoctor";
            this.gbDoctor.Size = new System.Drawing.Size(308, 124);
            this.gbDoctor.TabIndex = 3;
            this.gbDoctor.TabStop = false;
            this.gbDoctor.Text = "Doctor Services";
            // 
            // btnEditDoctor
            // 
            this.btnEditDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDoctor.Location = new System.Drawing.Point(62, 65);
            this.btnEditDoctor.Name = "btnEditDoctor";
            this.btnEditDoctor.Size = new System.Drawing.Size(192, 34);
            this.btnEditDoctor.TabIndex = 1;
            this.btnEditDoctor.Text = "Edit Doctor";
            this.btnEditDoctor.UseVisualStyleBackColor = true;
            this.btnEditDoctor.Click += new System.EventHandler(this.btnEditDoctor_Click);
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDoctor.Location = new System.Drawing.Point(62, 25);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(192, 34);
            this.btnAddDoctor.TabIndex = 0;
            this.btnAddDoctor.Text = "Add Doctor";
            this.btnAddDoctor.UseVisualStyleBackColor = true;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);
            // 
            // gbXray
            // 
            this.gbXray.Controls.Add(this.btnDeleteXray);
            this.gbXray.Controls.Add(this.btnAddXray);
            this.gbXray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbXray.Location = new System.Drawing.Point(12, 185);
            this.gbXray.Name = "gbXray";
            this.gbXray.Size = new System.Drawing.Size(308, 124);
            this.gbXray.TabIndex = 4;
            this.gbXray.TabStop = false;
            this.gbXray.Text = "Xray Services";
            // 
            // btnDeleteXray
            // 
            this.btnDeleteXray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteXray.Location = new System.Drawing.Point(62, 65);
            this.btnDeleteXray.Name = "btnDeleteXray";
            this.btnDeleteXray.Size = new System.Drawing.Size(192, 34);
            this.btnDeleteXray.TabIndex = 1;
            this.btnDeleteXray.Text = "Delete Xray";
            this.btnDeleteXray.UseVisualStyleBackColor = true;
            this.btnDeleteXray.Click += new System.EventHandler(this.btnDeleteXray_Click);
            // 
            // btnAddXray
            // 
            this.btnAddXray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddXray.Location = new System.Drawing.Point(62, 25);
            this.btnAddXray.Name = "btnAddXray";
            this.btnAddXray.Size = new System.Drawing.Size(192, 34);
            this.btnAddXray.TabIndex = 0;
            this.btnAddXray.Text = "Add XRay";
            this.btnAddXray.UseVisualStyleBackColor = true;
            this.btnAddXray.Click += new System.EventHandler(this.btnAddXray_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.Image = global::DentistToolClient.Properties.Resources.calendar;
            this.btnCalendar.Location = new System.Drawing.Point(429, 31);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(152, 127);
            this.btnCalendar.TabIndex = 5;
            this.btnCalendar.UseVisualStyleBackColor = true;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 327);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.gbXray);
            this.Controls.Add(this.gbDoctor);
            this.Controls.Add(this.gbPatient);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DentistTool Client";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.gbPatient.ResumeLayout(false);
            this.gbDoctor.ResumeLayout(false);
            this.gbXray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.GroupBox gbPatient;
        private System.Windows.Forms.Button btnViewPatient;
        private System.Windows.Forms.Button btnEditPatient;
        private System.Windows.Forms.GroupBox gbDoctor;
        private System.Windows.Forms.Button btnEditDoctor;
        private System.Windows.Forms.Button btnAddDoctor;
        private System.Windows.Forms.GroupBox gbXray;
        private System.Windows.Forms.Button btnDeleteXray;
        private System.Windows.Forms.Button btnAddXray;
        private System.Windows.Forms.Button btnCalendar;
    }
}