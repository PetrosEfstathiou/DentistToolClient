using DentistToolClient.CRUD;
using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static DentistToolClient.Globals;

namespace DentistToolClient
{
    public partial class UserControlAppointment : UserControl
    {
        
        private int ID;
        private Random rnd = new Random();
        public UserControlAppointment()
        {
            InitializeComponent();
        }

        private void UserControlAppointment_Load(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            this.BackColor = randomColor;
            label1.BackColor = randomColor;
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btCancel, "Cancel appointment");
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.SetToolTip(this.btnFinish, "Appointment finished. Add Treatment");
        }
        public void settext(string text)
        {
            label1.Text = text;
        }

        public void setid(int appid)
        {
            ID = appid;
        }

        public int getid()
        {
            return ID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel the appointment?", "Cancel appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Appointment app = new Appointment();
                app.id = ID;

                string input = Interaction.InputBox("Enter the reason for appointment Cancellation", "Cancel Appointment", "COVID 19", -1,-1);
                app.CancelReason = input;
                app.cancelled = true;
                AppointmentController db = new AppointmentController();
                var res = db.CancelAppointment(app);
                if (res.Success)
                {
                    MessageBox.Show("Appointment Cancelled", "Cancel appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(res.Message, "Cancel appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            FinishedApp = getid();
            frmAddTreatment treat = new frmAddTreatment();
            treat.Show();
        }
        public void completed()
        {
            btCancel.Enabled = false;
            btnFinish.Enabled = false;
            label1.Text = label1.Text + " (Completed)";
        }
    }
}
