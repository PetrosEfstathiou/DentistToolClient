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
    public partial class frmEditPatient : Form
    {
        List<Patient> SelectedPatient = new List<Patient>();
        public frmEditPatient()
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
                Patient updatep = new Patient();
                updatep.Id = SelectedPatient[lstPatients.SelectedIndex].Id;
                updatep.Name = txtName.Text;
                updatep.Surname = txtSurname.Text;
                updatep.email = txtemail.Text;
                updatep.telnum = txtTelNo.Text;
                updatep.nation = txtNation.Text;
                updatep.dob = mcDoB.SelectionStart.ToShortDateString();
                updatep.bloodtype = cmbBloodtype.SelectedItem.ToString();
                updatep.address = txtAddress.Text;

                PatientController db = new PatientController();
                var task = db.UpdatePatient(updatep);

                if (task.Success)
                {
                    MessageBox.Show(task.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMainMenu mm = new frmMainMenu();
                    mm.Show();
                    this.Hide();

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



        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsNumeric(txtSearch.Text) && txtSearch.Text != "")
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
                MessageBox.Show("Value must be a Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void lstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = SelectedPatient[lstPatients.SelectedIndex].Name;
            txtSurname.Text = SelectedPatient[lstPatients.SelectedIndex].Surname;
            txtAddress.Text = SelectedPatient[lstPatients.SelectedIndex].address;
            txtemail.Text = SelectedPatient[lstPatients.SelectedIndex].email;
            txtNation.Text = SelectedPatient[lstPatients.SelectedIndex].nation;
            txtTelNo.Text = SelectedPatient[lstPatients.SelectedIndex].telnum;
            try
            {
                cmbBloodtype.SelectedItem = SelectedPatient[lstPatients.SelectedIndex].bloodtype;
                lblDoB.Text = SelectedPatient[lstPatients.SelectedIndex].dob;
                mcDoB.SelectionStart = Convert.ToDateTime(lblDoB.Text);
            }
            catch (Exception Ex) { };
             
            
        }

        private void frmEditPatient_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPatients.SelectedIndex != -1)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected Patient?", "Delete Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                 
                    PatientController db = new PatientController();
                    var res = db.DeletePatient(SelectedPatient[lstPatients.SelectedIndex].Id);
                    if (res.Success)
                    {
                        MessageBox.Show("Patient Deleted", "Delete Patient", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMainMenu mm = new frmMainMenu();
                        mm.Show();
                        this.Hide();
                                           }
                    else
                        MessageBox.Show(res.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("You need to select a Patient to do that", "Delete Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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
