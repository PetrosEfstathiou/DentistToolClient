using DentistToolClient.CRUD;
using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentistToolClient
{

    public partial class frmAddXray : Form
    {
        List<Patient> SelectedPatient = new List<Patient>();
        public frmAddXray()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            //BMP, GIF, JPEG, EXIF, PNG, and TIFF) and SVG
            opnfd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.exif; *.png; *.tiff; *.svg)|*.jpg; *.jpeg; *.gif; *.bmp;*.exif; *.png; *.tiff; *.svg";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                lblpath.Text = opnfd.FileName;
                pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
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

        private void frmAddXray_Load(object sender, EventArgs e)
        {

        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
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

        private void btnAddXray_Click(object sender, EventArgs e)
        {
            if (lstPatients.SelectedIndex == -1)
                MessageBox.Show("You have to select a patient to do that", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (txtXrayName.Text == "")
                MessageBox.Show("Enter an Xray Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (lblpath.Text == "")
                MessageBox.Show("Select and Xray first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MemoryStream picturems = new MemoryStream();
                pictureBox1.Image.Save(picturems, ImageFormat.Png);
                byte[] imgData = new byte[picturems.Length];
                picturems.Position = 0;
                picturems.Read(imgData, 0, imgData.Length);
                AddXrayDto xray = new AddXrayDto();
                xray.patient = SelectedPatient[lstPatients.SelectedIndex].Id;
                xray.xrcreated = DateTime.Now;
                xray.xrimage = imgData;
                xray.xrname = txtXrayName.Text;
                XrayController db = new XrayController();
                var ret = db.AddXray(xray);
                if (ret.Success)
                {
                    MessageBox.Show("Xray added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Your Xray was not added to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
