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
    public partial class frmAddPatient : Form
    {
        public frmAddPatient()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!checkinput())
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!IsNumeric(txtTelNo.Text))
                MessageBox.Show("Telephone number must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!IsValidEmail(txtemail.Text))
                MessageBox.Show("Email provided not in the correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Patient addp = new Patient();
                addp.Name = txtName.Text;
                addp.Surname = txtSurname.Text;
                addp.email = txtemail.Text;
                addp.telnum = txtTelNo.Text;
                addp.nation = txtNation.Text;
                addp.dob = mcDoB.SelectionStart.ToShortDateString();
                addp.bloodtype = cmbBloodtype.SelectedItem.ToString();
                addp.address = txtAddress.Text;

                PatientController db = new PatientController();
                var task = db.AddPatient(addp);

                if (task.Success)
                {
                    MessageBox.Show(task.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(task.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void mcDoB_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblDoB.Text = mcDoB.SelectionStart.ToString("dd/MM/yyyy");
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool checkinput()
        {
            if (txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "" || txtemail.Text == "" || txtNation.Text == "" || txtTelNo.Text == "" || cmbBloodtype.SelectedItem==null||lblDoB.Text=="")
                return false;
            else
                return true;
        }

        private void frmAddPatient_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
