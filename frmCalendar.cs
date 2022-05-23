using DentistToolClient.CRUD;
using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentistToolClient
{
    
    public partial class frmCalendar : Form
    {
        static List<Doctor> SelectedDoctor = new List<Doctor>();
       
        public static int month, year, SD;
        public frmCalendar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoctorController dbdoc = new DoctorController();
            var retdoc = dbdoc.GetAll();
            SelectedDoctor.AddRange(retdoc.Data);
            cmbDoctor.DataSource = SelectedDoctor;
            cmbDoctor.DisplayMember = "ListView";
        }

        private void update(int month, int year)
        {
            lblmonthyear.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) +" "+ year.ToString();
    
        }
        private void displayDays()
        {
            flpDaysContainer.Controls.Clear();

            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            //First of the month
            DateTime startofthemonth = new DateTime(year, month, 1);
            //get the count of days of the month 
            int days = DateTime.DaysInMonth(year, month);
            //convert the start of the month to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            //monthemptydates
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                flpDaysContainer.Controls.Add(ucblank);

            }
            //monthdays
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();

                List<Appointment> apps = new List<Appointment>();
                AppointmentController db = new AppointmentController();
                DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, i);
                var ret = db.GetAppointmentsbyDate(dt,SelectedDoctor[cmbDoctor.SelectedIndex].Id);
                apps.AddRange(ret.Data);
                ucdays.numappointments(apps.Count);
                ucdays.days(i);
                
                flpDaysContainer.Controls.Add(ucdays);
            }


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            flpDaysContainer.Controls.Clear();
            month--;
            if (month == 0)
            {
                month = 12;
                year--;
            }
            update(month, year);

            //First of the month
            DateTime startofthemonth = new DateTime(year, month, 1);
            //get the count of days of the month 
            int days = DateTime.DaysInMonth(year, month);
            //convert the start of the month to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            //monthemptydates
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                flpDaysContainer.Controls.Add(ucblank);
            }
            //monthdays
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                List<Appointment> apps = new List<Appointment>();
                AppointmentController db = new AppointmentController();
                DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, i);
                var ret = db.GetAppointmentsbyDate(dt, SelectedDoctor[cmbDoctor.SelectedIndex].Id);
                apps.AddRange(ret.Data);
                ucdays.numappointments(apps.Count);
                ucdays.days(i);
                flpDaysContainer.Controls.Add(ucdays);
            }
        }

        private void frmCalendar_Activated(object sender, EventArgs e)
        {
            displayDays();
            update(month, year);
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SD = SelectedDoctor[cmbDoctor.SelectedIndex].Id;
            displayDays();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            flpDaysContainer.Controls.Clear();
            month++;
            if (month == 13)
            {
                month = 1;
                year++;
            }
            update(month, year);

            //First of the month
            DateTime startofthemonth = new DateTime(year, month, 1);
            //get the count of days of the month 
            int days = DateTime.DaysInMonth(year, month);
            //convert the start of the month to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            //monthemptydates
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                flpDaysContainer.Controls.Add(ucblank);
            }
            //monthdays
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                List<Appointment> apps = new List<Appointment>();
                AppointmentController db = new AppointmentController();
                DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, i);
                var ret = db.GetAppointmentsbyDate(dt, SelectedDoctor[cmbDoctor.SelectedIndex].Id);
                apps.AddRange(ret.Data);
                ucdays.numappointments(apps.Count);
                ucdays.days(i);
                flpDaysContainer.Controls.Add(ucdays);
            }

        }
    }
}
