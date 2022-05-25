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
    public partial class frmEditDoctor : Form
    {
        List<Doctor> SelectedDoctor = new List<Doctor>();
        public frmEditDoctor()
        {
            InitializeComponent();
        }

        private void frmEditDoctor_Load(object sender, EventArgs e)
        {
            DoctorController dbdoc = new DoctorController();
            var retdoc = dbdoc.GetAll();
            SelectedDoctor.AddRange(retdoc.Data);
            lstDoctors.DataSource = SelectedDoctor;
            lstDoctors.DisplayMember = "ListView";
        }

        private void lstDoctors_SelectedIndexChanged(object sender, EventArgs e)
         {
            cmbSpecialty.SelectedItem = null;
            txtOther.Enabled = false;
            txtName.Text = SelectedDoctor[lstDoctors.SelectedIndex].Name;
            txtSurname.Text = SelectedDoctor[lstDoctors.SelectedIndex].Surname;
            txtAddress.Text = SelectedDoctor[lstDoctors.SelectedIndex].address;
            txtemail.Text = SelectedDoctor[lstDoctors.SelectedIndex].email;
            txtTelNo.Text = SelectedDoctor[lstDoctors.SelectedIndex].telnum;
            cmbSpecialty.SelectedItem = SelectedDoctor[lstDoctors.SelectedIndex].specialty;
            if (cmbSpecialty.SelectedItem == null)
            {
                cmbSpecialty.SelectedItem = "Other...";
                txtOther.Text = SelectedDoctor[lstDoctors.SelectedIndex].specialty;
                txtOther.Enabled=true;
            }
        }

        private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecialty.SelectedItem == null)
            { 
            
            }
            else if (cmbSpecialty.SelectedItem.ToString() == "Other...")
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkinput())
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!IsNumeric(txtTelNo.Text))
                MessageBox.Show("Telephone number must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!IsValidEmail(txtemail.Text))
                MessageBox.Show("Email provided not in the correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Doctor editd = new Doctor();
                editd.Id = SelectedDoctor[lstDoctors.SelectedIndex].Id;
                editd.Name = txtName.Text;
                editd.Surname = txtSurname.Text;
                editd.email = txtemail.Text;
                editd.telnum = txtTelNo.Text;
                if (cmbSpecialty.SelectedItem.ToString() == "Other...")
                    editd.specialty = txtOther.Text;
                else
                    editd.specialty = cmbSpecialty.SelectedItem.ToString();
                editd.address = txtAddress.Text;

                DoctorController db = new DoctorController();
                var task = db.UpdateDoctor(editd);

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
            if (txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "" || txtemail.Text == "" || txtTelNo.Text == "" || cmbSpecialty.SelectedItem == null)
                return false;
            else
                return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMainMenu mm = new frmMainMenu();
            mm.Show();
            this.Hide();
        }
    }
}
