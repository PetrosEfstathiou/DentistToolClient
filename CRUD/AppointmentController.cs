using DentistToolClient.Models;
using System;
using System.Collections.Generic;
using static DentistToolClient.Globals;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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


        public ServiceResponse<List<Appointment>> CancelAppointment(Appointment CAppointment) 
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            //{"id": 0,"cancelled": true,"cancelReason": "string","dateTime": "2022-05-16T15:55:11.203Z","mduration": 0,"appReason": "string","patient": 0}
            var payload = "{\"id\":" + CAppointment.id + "," + "\"cancelled\":" + CAppointment.cancelled + "," + "\"cancelReason\":\"" + CAppointment.CancelReason + "\"," + "\"dateTime\":\"" + CAppointment.dateTime + "\"," + "\"mduration\":" + CAppointment.mduration + "," + "\"appReason\":\"" + CAppointment.AppReason + "\"," + "\"patient\":" + CAppointment.patient + "}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PutAsync("AppointmentController/CancelAppointment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Appointment>>>();
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
            //{"dateTime": "2022-05-16T15:39:35.732Z","mduration": 0,"appReason": "striasdasng","patient": 0}
            var payload = "{\"dateTime\":\"" + newAppointment.dateTime + "\"," + "\"mduration\":" + newAppointment.mduration + "," + "\"appReason\":\"" + newAppointment.AppReason + "\"," + "\"patient\":" + newAppointment.id + "}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("AppointmentController/AddAppointment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Appointment>>>();
            readTask.Wait();
            return readTask.Result;
        }
        public ServiceResponse<List<Appointment>> UpdateAppointment(Appointment updatedAppointment)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            //{"id": 0,"cancelled": true,"cancelReason": "string","dateTime": "2022-05-16T15:55:11.203Z","mduration": 0,"appReason": "string","patient": 0}
            var payload = "{\"id\":" + updatedAppointment.id + "," + "\"cancelled\":" + updatedAppointment.cancelled + "," + "\"cancelReason\":\"" + updatedAppointment.CancelReason + "\"," + "\"dateTime\":\"" + updatedAppointment.dateTime + "\"," + "\"mduration\":" + updatedAppointment.mduration + "," + "\"appReason\":\"" + updatedAppointment.AppReason + "\"," + "\"patient\":" + updatedAppointment.patient + "}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PutAsync("AppointmentController/UpdateAppointment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Appointment>>>();
            readTask.Wait();
            return readTask.Result;
        }
    }
}
