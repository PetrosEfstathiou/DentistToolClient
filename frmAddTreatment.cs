using DentistToolClient.CRUD;
using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DentistToolClient.Globals;

namespace DentistToolClient
{
    
    public partial class frmAddTreatment : Form
    {
        Appointment app = new Appointment();
        Bitmap bitmap = new Bitmap(1000,653);
        List<TreatmentCost> TreatmentCosts = new List<TreatmentCost>();
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;


        public frmAddTreatment()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 8);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            
        }

        private void pbRed_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            moving = true;
            x = e.X;
            y= e.Y;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = bitmap;
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
            

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;

        }

        private void frmAddTreatment_Load(object sender, EventArgs e)
        {
               AppointmentController dbApp = new AppointmentController();
                var eapp = dbApp.GetAppointmentsbyAppID(FinishedApp);
                app = eapp.Data;
            TreatmentCostController db = new TreatmentCostController();
            var ret = db.GetAll();
            TreatmentCosts.AddRange(ret.Data);
            for (int i = 0; i < TreatmentCosts.Count; i++)
            {
                chkLBTreaments.Items.Add(TreatmentCosts[i].Name);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbFillings_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkLBTreaments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lstPrice.Items.Clear();
            List<string> strl = new List<string>();
            for (int i = 0; i < chkLBTreaments.CheckedItems.Count; i++)
            {
                strl.Add(chkLBTreaments.CheckedItems[i].ToString());
            }
            int Cost = 0;
            for (int i = 0; i < strl.Count; i++)
                for (int j = 0; j < TreatmentCosts.Count; j++)
                {
                    if (strl[i] == TreatmentCosts[j].Name)
                    {
                        ListViewItem item = new ListViewItem(TreatmentCosts[j].Name);
                        item.SubItems.Add("€ " + TreatmentCosts[j].Cost.ToString());
                        Cost += TreatmentCosts[j].Cost;
                        lstPrice.Items.Add(item);
                    }

                }
            lblTotal.Text =  Cost.ToString();
            

        }

        private void lstPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text == "")
                MessageBox.Show("You need to enter Treatments and Calculate Cost before saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDescription.Text == "")
                MessageBox.Show("You need to enter a short Description of the treatment before saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Treatment addt = new Treatment();
                MemoryStream picturems = new MemoryStream();
                bitmap.Save(picturems, ImageFormat.Png);
                byte[] imgData = new byte[picturems.Length];
                picturems.Position = 0;
                picturems.Read(imgData, 0, imgData.Length);
                //Set Data
                addt.timage = imgData;
                addt.appointment = app.id;
                //Calculate Name 
                //

                //
                addt.treatment = txtDescription.Text;
                addt.cost = int.Parse(lblTotal.Text);
                addt.patient = app.patient;
                //Add Treatment to Database 
                TreatmentController dbTC = new TreatmentController();
                dbTC.AddTreatment(addt);
                //Get Treatment ID8
                var ret = dbTC.GetTreatmentAppID(app.id);
                addt = ret.Data;
                //////////////////////////////////////////////////////
                //Add Treatment ID to Appointment
                app.treatment = addt.id;
                AppointmentController dbApp = new AppointmentController();
                dbApp.UpdateAppointment(app);
                MessageBox.Show("Treatment saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

                
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
