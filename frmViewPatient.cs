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
    public partial class frmViewPatient : Form
    {
        public static MemoryStream SXray = new MemoryStream();
        public static MemoryStream STreatment = new MemoryStream();
        List <Patient> SelectedPatient = new List<Patient>();
        List<Appointment> sortedapps = new List<Appointment>();
        List<Xray> SelectedXray = new List<Xray>();
        List<Treatment> SelectedTreatment = new List<Treatment>();
        public frmViewPatient()
        {
            InitializeComponent();
        }

        private void frmViewPatient_Load(object sender, EventArgs e)
        {

        }

        private void lstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtName.Text = SelectedPatient[lstPatients.SelectedIndex].Name;
            txtSurname.Text = SelectedPatient[lstPatients.SelectedIndex].Surname;
            txtAddress.Text = SelectedPatient[lstPatients.SelectedIndex].address;
            txtemail.Text = SelectedPatient[lstPatients.SelectedIndex].email;
            txtNation.Text = SelectedPatient[lstPatients.SelectedIndex].nation;
            txtTelNo.Text = SelectedPatient[lstPatients.SelectedIndex].telnum;
            txtID.Text= SelectedPatient[lstPatients.SelectedIndex].Id.ToString();
            try
            {
                cmbBloodtype.SelectedItem = SelectedPatient[lstPatients.SelectedIndex].bloodtype;
                lblDoB.Text = SelectedPatient[lstPatients.SelectedIndex].dob;
                mcDoB.SelectionStart = Convert.ToDateTime(lblDoB.Text);
            }
            catch (Exception Ex) { };
            //Load Appointments
            lstAppointment.Items.Clear();
            sortedapps.Clear();
            List<Appointment> apps = new List<Appointment>();
            AppointmentController db = new AppointmentController();
            var ret = db.GetAppointmentsbyID(SelectedPatient[lstPatients.SelectedIndex].Id);
            apps.AddRange(ret.Data);
            sortedapps = apps.OrderBy(d => d.dateTime).ToList();
            for (int i = 0; i < sortedapps.Count; i++)
            {
                    TimeSpan ts = TimeSpan.FromMinutes(sortedapps[i].mduration);
                    string app = sortedapps[i].dateTime.ToString("dd/MM/yyyy") + " " + sortedapps[i].dateTime.ToString("HH:mm") + "-" + (sortedapps[i].dateTime + ts).ToString("HH:mm") +" " + (sortedapps[i].cancelled ? "(Cancelled) " : " ") + (sortedapps[i].treatment !=0 ? "(Completed)" : " ");
                    lstAppointment.Items.Add(app);

            }
            if (lstAppointment.Items.Count == 0)
            {
                gbA.Enabled = false;
                lstAppointment.Items.Add("No Appointments found");
            }
            else
                gbA.Enabled = true;
            //Load Xrays
            lstXrays.DataSource = null;
            lstXrays.Items.Clear();
            SelectedXray.Clear();
            XrayController xdb = new XrayController();
            var res = xdb.GetXray(SelectedPatient[lstPatients.SelectedIndex].Id);
            if (res.Data.Count == 0)
            {
                gbX.Enabled = false;
                lstXrays.Items.Add("No Xrays found");
            }
            else
            {
                
                SelectedXray.AddRange(res.Data);
                lstXrays.DataSource = res.Data;
                lstXrays.DisplayMember = "ListView";
                gbX.Enabled = true;
            }
            //Load Treatments
            lstTreatments.DataSource = null;
            lstTreatments.Items.Clear();
            SelectedTreatment.Clear();
            gbT.Enabled = false;
            TreatmentController tdb = new TreatmentController();
            var rest = tdb.GetTreatmentPatientID(SelectedPatient[lstPatients.SelectedIndex].Id);
            if (res.Data.Count == 0)
            {
                
                lstTreatments.Items.Add("No Treatments found");
            }
            else
            {

                SelectedTreatment.AddRange(rest.Data);
                lstTreatments.DataSource = rest.Data;
                lstTreatments.DisplayMember = "ListView";
                gbT.Enabled = true;
            }
            //Load Treatments


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

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void lstAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = lstAppointment.SelectedIndex;
            txtAppReason.Text = sortedapps[ind].AppReason;
            cmbDuration.SelectedItem = sortedapps[ind].mduration;
            cmbHour.SelectedItem = sortedapps[ind].dateTime.ToString("HH:mm");
            cmbDuration.SelectedItem = sortedapps[ind].mduration.ToString();
            txtAppID.Text = sortedapps[ind].id.ToString();
            chkCancelled.Checked = sortedapps[ind].cancelled;
            txtCancellationReason.Text = chkCancelled.Checked ? sortedapps[ind].CancelReason: "";
            DoctorController dbD = new DoctorController();
            var ret = dbD.GetSingle(sortedapps[ind].doctor);
            txtDoctor.Text = "(" +ret.Data.Id + ") " +ret.Data.Name + " " + ret.Data.Surname ;
            txtAppDate.Text = sortedapps[ind].dateTime.ToString("dd/MM/yyyy");
        }

        private void lstXrays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstXrays.SelectedItem != null )
            {
                try
                {
                    txtCreated.Text = SelectedXray[lstXrays.SelectedIndex].xrcreated.ToString("dd/MM/yyyy");
                    txtXrayName.Text = SelectedXray[lstXrays.SelectedIndex].xrname;
                    MemoryStream picturems = new MemoryStream(SelectedXray[lstXrays.SelectedIndex].xrimage);
                    SXray = new MemoryStream(SelectedXray[lstXrays.SelectedIndex].xrimage);
                    Image returnImage = Image.FromStream(picturems);
                    pictureBox1.Image = returnImage;
                }
                catch (Exception Ex)
                { 
                }
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            frmViewXray viewXray = new frmViewXray();
            viewXray.Show();
        }

        private void lstTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTreatments.SelectedItem != null)
            {
                try
                {
                    txtTID.Text = SelectedTreatment[lstTreatments.SelectedIndex].id.ToString();
                    AppointmentController db = new AppointmentController();
                    var app = db.GetAppointmentsbyAppID(SelectedTreatment[lstTreatments.SelectedIndex].appointment);
                    TimeSpan ts = TimeSpan.FromMinutes(app.Data.mduration);
                    txtAppointment.Text = app.Data.dateTime.ToString("dd/MM/yyyy") + " " + app.Data.dateTime.ToString("HH:mm") + "-" + (app.Data.dateTime + ts).ToString("HH:mm") ;
                    txtCost.Text = "€ " + SelectedTreatment[lstTreatments.SelectedIndex].cost.ToString();

                    MemoryStream picturems = new MemoryStream(SelectedTreatment[lstTreatments.SelectedIndex].timage);
                    STreatment = new MemoryStream(SelectedTreatment[lstTreatments.SelectedIndex].timage);
                    Image returnImage = Image.FromStream(picturems);
                    pictureBox2.Image = returnImage;
                    pictureBox2.BackgroundImage = DentistToolClient.Properties.Resources.preview_tooth_formula;
                }
                catch (Exception Ex)
                {
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmViewFormula viewf = new frmViewFormula();
            viewf.Show();
        }
    }
}
