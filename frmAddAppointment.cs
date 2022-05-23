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
using DentistToolClient.CRUD;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace DentistToolClient
{
    public partial class frmAddAppointment : Form
    {
        
        List<Patient> SelectedPatient = new List<Patient>();
        List<Doctor> SelectedDoctor = new List<Doctor>();
        public frmAddAppointment()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsNumeric(txtSearch.Text))
            {
                if (rdbID.Checked)
                {
                    List<Patient> pat = new List<Patient>();
                    PatientController db = new PatientController();
                    var ret = db.GetSingle(int.Parse(txtSearch.Text));
                    if (ret.Data == null)
                        MessageBox.Show(ret.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        pat.Add(ret.Data);
                        SelectedPatient = pat;
                        lstPatients.DataSource = pat;
                        lstPatients.DisplayMember = "ListView";
                    }

                }
                else if (rdbTel.Checked)
                {
                    List<Patient> pat = new List<Patient>();
                    PatientController db = new PatientController();
                    var ret = db.GetbyTel(int.Parse(txtSearch.Text));
                    if (ret.Data == null)
                        MessageBox.Show(ret.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        pat.AddRange(ret.Data);
                        SelectedPatient = pat;
                        lstPatients.DataSource = pat;
                        lstPatients.DisplayMember = "ListView";
                    }
                }
            }
            else
            {
                MessageBox.Show("Value must be a Number", "Error",MessageBoxButtons.OK ,MessageBoxIcon.Exclamation );
            }
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbID.Checked)
            {
                rdbTel.Checked = false;
            }
        }

        private void rdbTel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTel.Checked)
            {
                rdbID.Checked = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAddAppointment_Load(object sender, EventArgs e)
        {

        }

        private void lstDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.doctor = frmCalendar.SD;
            //assigns year, month, day, hour, min, seconds
            string time = cmbHour.SelectedItem.ToString(); 
            app.dateTime = new DateTime(frmCalendar.year,frmCalendar.month,UserControlDays.static_day, int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3, 2)),00);
            app.AppReason = txtAppReason.Text;
            app.cancelled = false;
            app.CancelReason = "";
            app.mduration = int.Parse(cmbDuration.SelectedItem.ToString());
            app.treatment = 0;
            app.patient = SelectedPatient[lstPatients.SelectedIndex].Id;
            AppointmentController db = new AppointmentController();
            //Get Appointments to check availability
            List<Appointment> apps = new List<Appointment>();
            AppointmentController dbapps = new AppointmentController();
            DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, UserControlDays.static_day);
            var ret = dbapps.GetAppointmentsbyDate(dt, frmCalendar.SD);
            apps.AddRange(ret.Data);
            //
            

            bool exists = false;
            for (int i = 0; i < apps.Count; i++)
            {
                DateTime end = apps[i].dateTime;
                end = end.AddMinutes(apps[i].mduration);
                DateTime endapp = app.dateTime;
                endapp = endapp.AddMinutes(app.mduration);

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
                db.AddAppointment(app);
                MessageBox.Show("Appointment Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            

        }

        private void cmbHour_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
