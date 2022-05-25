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
    public partial class frmAddDoctor : Form
    {
        public frmAddDoctor()
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
                Doctor addd = new Doctor();
                addd.Name = txtName.Text;
                addd.Surname = txtSurname.Text;
                addd.email = txtemail.Text;
                addd.telnum = txtTelNo.Text;
                if (cmbSpecialty.SelectedItem.ToString() == "Other...")
                    addd.specialty = txtOther.Text;
                else
                    addd.specialty = cmbSpecialty.SelectedItem.ToString();
                addd.address = txtAddress.Text;

                DoctorController db = new DoctorController();
                var task = db.AddDoctor(addd);

                if (task.Success)
                {
                    MessageBox.Show(task.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(task.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            if (txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "" || txtemail.Text == "" || txtTelNo.Text == "" || cmbSpecialty.SelectedItem == null )
                return false;
            else
                return true;
        }

        private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecialty.SelectedItem.ToString() == "Other...")
            {
                txtOther.Text = "";
                txtOther.Enabled = true;
            }
            else
            {
                txtOther.Text = "Other..";
                txtOther.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu mm = new frmMainMenu();
            mm.Show();
            this.Hide();
        }
    }
}
