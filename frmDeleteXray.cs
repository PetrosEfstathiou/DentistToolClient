using DentistToolClient.CRUD;
using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentistToolClient
{
    public partial class frmDeleteXray : Form
    {
        List<Patient> SelectedPatient = new List<Patient>();
        List<Xray> SelectedXray = new List<Xray>();

        public frmDeleteXray()
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
                MessageBox.Show("Value must be a Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rdbTel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTel.Checked)
            {
                rdbID.Checked = false;
            }
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbID.Checked)
            {
                rdbTel.Checked = false;
            }
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void lstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
                XrayController xdb = new XrayController();
                var res = xdb.GetXray(SelectedPatient[lstPatients.SelectedIndex].Id);
                if (res.Data.Count == 0)
                    MessageBox.Show("No Xrays found for selected patient", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    SelectedXray.AddRange(res.Data);
                    lstXrays.DataSource = res.Data;
                    lstXrays.DisplayMember = "ListView";
                }         
        }

        private void lstXrays_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCreated.Text = SelectedXray[lstXrays.SelectedIndex].xrcreated.ToString("dd/MM/yyyy");
            txtXrayName.Text = SelectedXray[lstXrays.SelectedIndex].xrname;
            MemoryStream picturems = new MemoryStream(SelectedXray[lstXrays.SelectedIndex].xrimage);
            Image returnImage = Image.FromStream(picturems);
            pictureBox1.Image = returnImage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstXrays.SelectedIndex != -1)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected Xray?", "Delete Xray", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    XrayController db = new XrayController();
                    var res = db.DeleteXray(SelectedXray[lstXrays.SelectedIndex].id);
                    if (res.Success)
                    {
                        MessageBox.Show("Xray Deleted", "Delete Xray", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show(res.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("You need to select a Patient to do that", "Delete Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}

