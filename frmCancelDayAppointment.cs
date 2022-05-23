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

namespace DentistToolClient
{
    public partial class frmCancelDayAppointment : Form
    {
        List<Appointment> sortedapps = new List<Appointment>();
        public frmCancelDayAppointment()
        {
            InitializeComponent();
        }

        private void frmCancelDayAppointment_Load(object sender, EventArgs e)
        {
            List<Appointment> apps = new List<Appointment>();
            AppointmentController db = new AppointmentController();
            DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, UserControlDays.static_day);
            var ret = db.GetAppointmentsbyDate(dt,frmCalendar.SD);
            apps.AddRange(ret.Data);
            sortedapps = apps.OrderBy(d => d.dateTime).ToList();
            for (int i = 0; i < sortedapps.Count; i++)
            {
                //Database PAtient
                PatientController dbpat = new PatientController();
                var task = dbpat.GetSingle(sortedapps[i].patient);
                var patient = task.Data;
                ///
                TimeSpan ts = TimeSpan.FromMinutes(sortedapps[i].mduration);
                string app = patient.Name + " " + patient.Surname + " " + sortedapps[i].dateTime.ToString("HH:mm") + "-" + (sortedapps[i].dateTime + ts).ToString("HH:mm") + " for " + sortedapps[i].AppReason;
                lstAppointment.Items.Add(app);
            }
        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (lstAppointment.SelectedIndex != -1)
            {
                var result = MessageBox.Show("Are you sure you want to cancel the appointment?", "Cancel appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Appointment app = new Appointment();
                    app = sortedapps[lstAppointment.SelectedIndex];
                    app.CancelReason = txtCancelReason.Text;
                    app.cancelled = true;
                    AppointmentController db = new AppointmentController();
                    var res = db.CancelAppointment(app);
                    if (res.Success)
                    {
                        MessageBox.Show("Appointment Cancelled", "Cancel appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show(res.Message, "Cancel appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("You need to select an appointment to do that", "Cancel appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
