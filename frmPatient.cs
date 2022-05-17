using DentistToolClient.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DentistToolClient.Globals;
using DentistToolClient.CRUD;



namespace DentistToolClient
{
    public partial class frmPatient : Form
    {
        public string content;
        public frmPatient()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientController db = new PatientController();
            var task = db.GetAll();
            if (task.Success)
            {
                var patients = task.Data;
                foreach (var patient in patients)
                {
                    listView1.Items.Add(patient.Name);
                }
            }
            else
            {
                MessageBox.Show(task.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientController db = new PatientController();
            var task = db.GetSingle(3);
            if (task.Success)
            {
                var patient = task.Data;
                listView1.Items.Add(patient.Name);
                
            }
            else
            {
                MessageBox.Show(task.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Patient addp = new Patient();
            addp.Name = "Petros";
            addp.Surname = "Esftathiou";
            addp.email = "Petros2210@hotmail.com";
            addp.telnum = "96645393";
            addp.nation = "Cyprus";
            addp.dob = "22/10/1988";
            addp.bloodtype = "A+";
            addp.address = "Ag. Nicolaou 11";

            PatientController db = new PatientController();
            var task = db.AddPatient(addp);
            
            if (task.Success)
            {
                var patients = task.Data;
                foreach (var patient in patients)
                {
                    listView1.Items.Add(patient.Name);
                }
            }
            else
            {
                MessageBox.Show(task.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
           Patient updatep = new Patient();
            updatep.Id = 1;
            updatep.Name = "Petros";
            updatep.Surname = "Esftathiou";
            updatep.email = "Petros2210@hotmail.com";
            updatep.telnum = "96645393";
            updatep.nation = "Cyprus";
            updatep.dob = "22/10/1988";
            updatep.bloodtype = "A+";
            updatep.address = "Ag. Nicolaou 11";

            PatientController db = new PatientController();
            var task = db.UpdatePatient(updatep);

            if (task.Success)
            {
                var patient = task.Data;
                listView1.Items.Add(patient.Name);
                
            }
            else
            {
                MessageBox.Show(task.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            PatientController db = new PatientController();
            var task = db.DeletePatient(2);

            if (task.Success)
            {
                var patients = task.Data;
                foreach (var patient in patients)
                {
                    listView1.Items.Add(patient.Name);
                }
            }
            else
            {
                MessageBox.Show(task.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


   


