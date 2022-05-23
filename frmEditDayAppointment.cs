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
    
    public partial class frmEditDayAppointment : Form
    {
        List<Appointment> sortedapps = new List<Appointment>();
        List<Doctor> SelectedDoctor = new List<Doctor>();

        public frmEditDayAppointment()
        {
            InitializeComponent();
        }

        private void frmEditAppointment_Load(object sender, EventArgs e)
        {
            
            List<Appointment> apps = new List<Appointment>();
            AppointmentController db = new AppointmentController();
            DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, UserControlDays.static_day);
            var ret = db.GetAppointmentsbyDate(dt, frmCalendar.SD);
            apps.AddRange(ret.Data);
            sortedapps = apps.OrderBy(d => d.dateTime).ToList();
            for (int i = 0; i < sortedapps.Count; i++)
            {
                if (sortedapps[i].treatment == 0)
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
            if (lstAppointment.Items.Count == 0)
            {
                MessageBox.Show("No appointments to edit found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void lstAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = lstAppointment.SelectedIndex;
            txtAppReason.Text = sortedapps[ind].AppReason;
            cmbDuration.SelectedItem = sortedapps[ind].mduration;
            cmbHour.SelectedItem = sortedapps[ind].dateTime.ToString("HH:mm");
            cmbDuration.SelectedItem = sortedapps[ind].mduration.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.doctor = frmCalendar.SD;
            //assigns year, month, day, hour, min, seconds
            string time = cmbHour.SelectedItem.ToString();
            app.dateTime = new DateTime(frmCalendar.year, frmCalendar.month, UserControlDays.static_day, int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3, 2)), 00);
            app.AppReason = txtAppReason.Text;
            app.cancelled = false;
            app.CancelReason = "NotCancelled";
            app.mduration = int.Parse(cmbDuration.SelectedItem.ToString());
            app.treatment = 0;
            app.patient = sortedapps[lstAppointment.SelectedIndex].patient;
            app.id = sortedapps[lstAppointment.SelectedIndex].id;
            AppointmentController db = new AppointmentController();
            //Get Appointments to check availability
            List<Appointment> apps = new List<Appointment>();
            AppointmentController dbapps = new AppointmentController();
            DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, UserControlDays.static_day);
            var ret = dbapps.GetAppointmentsbyDate(dt, frmCalendar.SD);
            apps.AddRange(ret.Data);
            apps = apps.OrderBy(d => d.dateTime).ToList();
            //

            bool exists = false;
            for (int i = 0; i < apps.Count; i++)
            {
                DateTime end = apps[i].dateTime;
                end = end.AddMinutes(apps[i].mduration);
                DateTime endapp = app.dateTime;
                endapp = endapp.AddMinutes(app.mduration);

               if(i != lstAppointment.SelectedIndex)
                if ((end > app.dateTime && app.dateTime > apps[i].dateTime) || (end > endapp && endapp > apps[i].dateTime))
                    exists = true;
            }

            if (exists)
            {
                MessageBox.Show("Conflict between Appointments pls check the appointments and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDuration.Focus();
            }
            else
            {
                db.UpdateAppointment(app);
                MessageBox.Show("Appointment Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
