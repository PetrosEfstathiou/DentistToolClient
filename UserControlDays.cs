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
    
    public partial class UserControlDays : UserControl
    {
        public static int static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            lblday.Text = numday.ToString();
        }

        public void numappointments(int numapps)
        {

            lblApps.Text = numapps.ToString() + " Appointments";
        }




        private void UserControlDays_Enter(object sender, EventArgs e)
        {
  
        }

        private void UserControlDays_Leave(object sender, EventArgs e)
        {

        }

        private void UserControlDays_DoubleClick(object sender, EventArgs e)
        {
            static_day = int.Parse(lblday.Text);
            frmDayAppointments dayapp = new frmDayAppointments();
            dayapp.Show();
        }

        private void lblApps_Click(object sender, EventArgs e)
        {

        }

        private void lblApps_DoubleClick(object sender, EventArgs e)
        {
            static_day = int.Parse(lblday.Text);
            frmDayAppointments dayapp = new frmDayAppointments();
            dayapp.Show();
        }

        private void UserControlDays_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }



        private void UserControlDays_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
