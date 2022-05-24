using DentistToolClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static DentistToolClient.Globals;

namespace DentistToolClient.CRUD
{
    class TreatmentController
    {
        public ServiceResponse<int> AddTreatment(Treatment treat)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var jsonSettings = new JsonSerializerSettings();
            var payload = JsonConvert.SerializeObject(treat);
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("TreatmentController/AddTreatment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<int>>();
            readTask.Wait();
            return readTask.Result;

        }
        //
        public ServiceResponse<List<Treatment>> GetTreatmentPatientID(int ID)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("TreatmentController/GetbyPatientID?id=" + ID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Treatment>>>();
            readTask.Wait();
            return readTask.Result;

        }
        public ServiceResponse<Treatment> GetTreatment(int tID)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("TreatmentController/GetbyID?id=" + tID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Treatment>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<Treatment> GetTreatmentAppID(int ID)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("TreatmentController/GetbyAppID?id=" +ID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<Treatment>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<int> UpdateTreatment (Treatment treat)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            ////{"ID"=0,"appointment": 0,"timage": "string","treatment": "string","cost": 0,"patient": 0}
            var payload = "{\"id\"="+treat.id+"\"appointment\":" + treat.appointment + "," + "\"timage\":\"" + treat.timage + "\"," + "\"treatment\":\"" + treat.treatment + "\"," + "\"cost\":" + treat.cost + "\"patient\":" + treat.patient + "}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PutAsync("TreatmentController/EditTreatment", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<int>>();
            readTask.Wait();
            return readTask.Result;
        }


    }
}
