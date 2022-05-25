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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar calendar = new frmCalendar();
            calendar.Show();
            this.Hide();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmAddPatient addp = new frmAddPatient();
            addp.Show();
            this.Hide();
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            frmEditPatient editp = new frmEditPatient();
            editp.Show();
            this.Hide();
        }

        private void btnViewPatient_Click(object sender, EventArgs e)
        {
            frmViewPatient viewp = new frmViewPatient();
            viewp.Show();
            this.Hide();
        }

        private void btnAddXray_Click(object sender, EventArgs e)
        {
            frmAddXray addx = new frmAddXray();
            addx.Show();
            this.Hide();
        }

        private void btnDeleteXray_Click(object sender, EventArgs e)
        {
            frmDeleteXray delx = new frmDeleteXray();
            delx.Show();
            this.Hide();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmAddDoctor addd = new frmAddDoctor();
            addd.Show();
            this.Hide();
        }

        private void btnEditDoctor_Click(object sender, EventArgs e)
        {
            frmEditDoctor editd = new frmEditDoctor();
            editd.Show();
            this.Hide();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
