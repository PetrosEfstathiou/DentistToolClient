using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static DentistToolClient.Globals;
using DentistToolClient.Models;
using System.Net;
using System.Text;
using System.Windows;

namespace DentistToolClient.CRUD
{
    class PatientController
    {
        public ServiceResponse<List<Patient>> GetAll()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", JWTtoken);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unauthorized user. Closing Application", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            var response = client.GetAsync("PatientController/GetAll");
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Patient>>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<Patient> GetSingle(int ID)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", JWTtoken);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unauthorized user. Closing Application", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            var response = client.GetAsync("PatientController/GetSingle?id=" + ID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Patient>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<List<Patient>> GetbyTel(int tel)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", JWTtoken);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unauthorized user. Closing Application", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            var response = client.GetAsync("PatientController/GetbyTel?tel=" + tel.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Patient>>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<List<Patient>> AddPatient(Patient p)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", JWTtoken);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unauthorized user. Closing Application", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            //{"name": "strin3g","surname": "string","email": "string", "telnum": "string",  "nation": "string",  "dob": "string",  "bloodtype": "string",  "address": "string"}
            var payload = "{\"Name\":\""+p.Name+"\","+"\"Surname\":\""+p.Surname+"\","+"\"email\":\"" + p.email + "\"," + "\"telnum\":\"" + p.telnum + "\"," + "\"nation\":\"" + p.nation + "\"," + "\"dob\":\"" + p.dob + "\"," + "\"bloodtype\":\"" + p.bloodtype + "\"," + "\"address\":\"" + p.address + "\"}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("PatientController/Newpatient",C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Patient>>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<Patient> UpdatePatient(Patient updatedp)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", JWTtoken);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unauthorized user. Closing Application", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            //{"id":"int","name": "strin3g","surname": "string","email": "string", "telnum": "string",  "nation": "string",  "dob": "string",  "bloodtype": "string",  "address": "string"}
            var payload = "{\"id\":" + updatedp.Id + "," + "\"Name\":\"" + updatedp.Name + "\"," + "\"Surname\":\"" + updatedp.Surname + "\"," + "\"email\":\"" + updatedp.email + "\"," + "\"telnum\":\"" + updatedp.telnum + "\"," + "\"nation\":\"" + updatedp.nation + "\"," + "\"dob\":\"" + updatedp.dob + "\"," + "\"bloodtype\":\"" + updatedp.bloodtype + "\"," + "\"address\":\"" + updatedp.address + "\"}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PutAsync("PatientController/UpdatePatient", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Patient>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<List<Patient>> DeletePatient(int ID)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", JWTtoken);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unauthorized user. Closing Application", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            var response = client.DeleteAsync("PatientController/DeletebyID?id=" + ID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Patient>>>();
            readTask.Wait();
            return readTask.Result;
        }




    }
}
