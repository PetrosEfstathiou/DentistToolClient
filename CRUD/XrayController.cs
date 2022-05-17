using DentistToolClient.Models;
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
    class XrayController
    {
        
        public ServiceResponse<int> AddXray(Xray xray)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            //{"patient": 0,"xrname": "string","xrimage": "string","xrcreated": "2022-05-16T16:21:34.764Z"}
            var payload = "{\"patient\":" + xray.patient + "," + "\"xrname\":\"" + xray.xrname + "\"," + "\"xrimage\":\"" + xray.xrimage + "\"," + "\"xrcreated\":\"" + xray.xrcreated + "\"}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("XrayController/AddXray", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<int>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<List<Xray>> GetXray(int pID)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.GetAsync("XrayController/GetbyID?id=" + pID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<List<Xray>>>();
            readTask.Wait();
            return readTask.Result;

        }

        public ServiceResponse<int> DeleteXray(int ID)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            var response = client.DeleteAsync("XrayController/DeletebyId?id=" + ID.ToString());
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<int>>();
            readTask.Wait();
            return readTask.Result;
        }




    }



}
