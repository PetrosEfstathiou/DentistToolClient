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
    class TreatmentCostController
    {
        public ServiceResponse<List<TreatmentCost>> GetAll()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("TreatmentCostController/GetAll");
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<TreatmentCost>>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<List<TreatmentCost>> AddTC(TreatmentCost newTC)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var jsonSettings = new JsonSerializerSettings();
            var payload = JsonConvert.SerializeObject(newTC);
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("TreatmentCostController/AddTreatmentCost", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<TreatmentCost>>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<List<TreatmentCost>> DeleteTC(int id)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.DeleteAsync("TreatmentCostController/DeleteTreatmentCostDeletebyId?id="+id.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<TreatmentCost>>>();
            readTask.Wait();
            return readTask.Result;
        }

    }
}
