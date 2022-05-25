using DentistToolClient.CRUD;
using DentistToolClient.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DentistToolClient.Globals;

namespace DentistToolClient
{
    public partial class frmDayAppointments : Form
    {

        List<Appointment> sortedapps = new List<Appointment>();


        public frmDayAppointments()
        {
            InitializeComponent();
        }

        private void frmDayAppointments_Load(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, UserControlDays.static_day);
            this.Text = "Appointments for " + dt.DayOfWeek.ToString() + " " + dt.ToString("dd/MM/yyyy");
        }

        private void userControlDayView1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddAppointment addapp = new frmAddAppointment();
            addapp.Show();
        }

        private void frmDayAppointments_Activated(object sender, EventArgs e)
        {
            userControlDayView1.Clearflp();
            List<Appointment> apps = new List<Appointment>();
            AppointmentController db = new AppointmentController();
            DateTime dt = new DateTime(frmCalendar.year, frmCalendar.month, UserControlDays.static_day);
            var ret = db.GetAppointmentsbyDate(dt, frmCalendar.SD);
            apps.AddRange(ret.Data);

            sortedapps = apps.OrderBy(d => d.dateTime).ToList();
            int i = 0;
            TimeSpan opent = new TimeSpan(07, 00, 00);
            if (sortedapps.Count == 0)
            {
                Label app = new Label();
                app.AutoSize = false;
                app.TextAlign = ContentAlignment.MiddleCenter;
                app.Width = 405;
                app.Height = 572;
                app.Text = "Available";
                app.BackColor = Color.White;
                userControlDayView1.Addflp(app);

            }
            else
            {

                while (sortedapps.Count > i)
                {
                    

                    TimeSpan apptime = new TimeSpan(sortedapps[i].dateTime.Hour, sortedapps[i].dateTime.Minute, 00);

                    if (opent < apptime)

                    {
                        Label app = new Label();
                        app.AutoSize = false;
                        app.TextAlign = ContentAlignment.MiddleCenter;
                        app.Width = 405;
                    //
                        int minutes = ((int)apptime.TotalMinutes - (int)opent.TotalMinutes);
                        app.Height = minutes / 15 * 11;
                        app.Text = "Available";
                        app.BackColor = Color.White;
                        userControlDayView1.Addflp(app);
                        opent = opent + (apptime - opent);
                    }
                    else if (opent == apptime)
                    {
                        UserControlAppointment app = new UserControlAppointment();
                        
                        app.AutoSize = false;
                        //app.TextAlign = ContentAlignment.MiddleCenter;
                        app.Width = 405;
                        int minutes = ((int)apptime.TotalMinutes - (int)opent.TotalMinutes);
                        app.Height = sortedapps[i].mduration / 15 * 11;
                        //Database PAtient
                        PatientController dbpat = new PatientController();
                        var task = dbpat.GetSingle(sortedapps[i].patient);
                        var patient = task.Data;
                        ///
                        
                        TimeSpan ts = TimeSpan.FromMinutes(sortedapps[i].mduration);
               
                        app.settext(sortedapps[i].dateTime.ToString("HH:mm") + "-" + (sortedapps[i].dateTime + ts).ToString("HH:mm ")+patient.Name + " " + patient.Surname + " for " + sortedapps[i].AppReason);
                        app.setid(sortedapps[i].id);
                        if (sortedapps[i].treatment != 0)
                            app.completed();
                        userControlDayView1.Addflp(app);
                      
                        opent = opent + ts;
                        i++;
                    }


                }
                TimeSpan end = new TimeSpan(sortedapps[sortedapps.Count - 1].dateTime.Hour, sortedapps[sortedapps.Count - 1].dateTime.Minute, 00);
                TimeSpan tsd = TimeSpan.FromMinutes(sortedapps[sortedapps.Count - 1].mduration);
                end = end + tsd;
                TimeSpan close = new TimeSpan(20, 00, 00);
                if (end < close)
                {
                    Label app = new Label();
                    app.AutoSize = false;
                    app.TextAlign = ContentAlignment.MiddleCenter;
                    app.Width = 405;
                    app.Height = (int)((close-end).TotalMinutes) / 15 * 11;
                    app.Text = "Available";
                    app.BackColor = Color.White;
                    userControlDayView1.Addflp(app);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditDayAppointment editapp = new frmEditDayAppointment();
            editapp.Show();
        }

        private void btneReminder_Click(object sender, EventArgs e)
        {
            //https://jasonwatmore.com/post/2021/09/02/net-5-send-an-email-via-smtp-with-mailkit
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(eusername, epass);
            for (int i = 0; i < sortedapps.Count; i++)
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(emailadd));
                //get patient from database
                PatientController db = new PatientController();
                var res = db.GetSingle(sortedapps[i].patient);
                var pat = res.Data;
                //get doctor from database
                DoctorController dbd = new DoctorController();
                var resd = dbd.GetSingle(sortedapps[i].doctor);
                var doc = resd.Data;
                email.To.Add(MailboxAddress.Parse(pat.email));
                email.Subject = "DentistToolClient Appointment Reminder";
                TimeSpan ts = TimeSpan.FromMinutes(sortedapps[i].mduration);
                email.Body = new TextPart(TextFormat.Html) { Text = "<p>We would like to remind you about your appointment on " +
                                                            sortedapps[i].dateTime.DayOfWeek + " " + sortedapps[i].dateTime.ToString("dd/MM/yyyy HH:mm") + "-" + 
                                                            (sortedapps[i].dateTime + ts).ToString("HH:mm") + " for " + sortedapps[i].AppReason + " with Dr. " + 
                                                            doc.Surname + " "+ doc.Name + " </p>" };
                smtp.Send(email);   
            } 
            smtp.Disconnect(true);
            MessageBox.Show("Email Reminders Successfully Sent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
