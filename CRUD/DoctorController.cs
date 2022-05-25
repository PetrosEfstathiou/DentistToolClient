using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static DentistToolClient.Globals;

namespace DentistToolClient.CRUD
{
    class DoctorController
    {
        public ServiceResponse<List<Doctor>> GetAll()
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
            var response = client.GetAsync("DoctorController/GetAll");
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Doctor>>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<Doctor> GetSingle(int ID)
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
            var response = client.GetAsync("DoctorController/GetSingle?id=" + ID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Doctor>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<List<Doctor>> AddDoctor(Doctor d)
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
            //{"specialty": "string","name": "string","surname": "string","email": "string","telnum": "string","address": "string"}
            var payload = "{\"specialty\":\"" + d.specialty + "\"," +"\"name\":\"" + d.Name + "\"," + "\"surname\":\"" + d.Surname + "\"," + "\"email\":\"" + d.email + "\"," + "\"telnum\":\"" + d.telnum + "\"," + "\"address\":\"" + d.address + "\"}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("DoctorController/AddDoctor", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Doctor>>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<Doctor> UpdateDoctor(Doctor updatedd)
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
            //{"id": 1,"specialty": "string","name": "string","surname": "string","email": "string","telnum": "string","address": "string"}
            var payload = "{\"id\":" + updatedd.Id + "," + "\"specialty\":\"" + updatedd.specialty + "\"," + "\"name\":\"" + updatedd.Name + "\"," + "\"surname\":\"" + updatedd.Surname + "\"," + "\"email\":\"" + updatedd.email + "\"," + "\"telnum\":\"" + updatedd.telnum + "\"," + "\"address\":\"" + updatedd.address + "\"}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PutAsync("DoctorController/UpdateDoctor", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Doctor>>();
            readTask.Wait();
            return readTask.Result;
        }


    }
}
