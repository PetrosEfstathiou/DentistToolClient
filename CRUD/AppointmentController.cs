using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using static DentistToolClient.Globals;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DentistToolClient.CRUD
{
    class AppointmentController
    {
        public ServiceResponse<List<Appointment>> GetAllAppointments()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("AppointmentController/GetAll");
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Appointment>>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<List<Appointment>> GetAppointmentsbyID(int id) 
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("AppointmentController/GetbyID?id=" + id.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Appointment>>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<Appointment> GetAppointmentsbyAppID(int id)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("AppointmentController/GetbyAppID?id=" + id.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Appointment>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<List<Appointment>> GetAppointmentsbyDate(DateTime date,int doc)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("AppointmentController/GetbyDate?date="+date+"&doctor="+doc.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Appointment>>>();
            readTask.Wait();
            return readTask.Result;
        }


        public ServiceResponse<Appointment> CancelAppointment(Appointment CAppointment) 
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var jsonSettings = new JsonSerializerSettings();
            var payload = JsonConvert.SerializeObject(CAppointment);
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PutAsync("AppointmentController/CancelAppointment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Appointment>>();
            readTask.Wait();
            return readTask.Result;
        }
        public ServiceResponse<List<Appointment>> AddAppointment(Appointment newAppointment)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var jsonSettings = new JsonSerializerSettings();
            var payload = JsonConvert.SerializeObject(newAppointment);
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("AppointmentController/AddAppointment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Appointment>>>();
            readTask.Wait();
            return readTask.Result;
        }
        public ServiceResponse<Appointment> UpdateAppointment(Appointment updatedAppointment)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var jsonSettings = new JsonSerializerSettings();
            var payload = JsonConvert.SerializeObject(updatedAppointment);
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PutAsync("AppointmentController/UpdateAppointment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Appointment>>();
            readTask.Wait();
            return readTask.Result;
        }
    }
}
