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
    class AuthorizationController
    {
        public ServiceResponse<int> Register(User user)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            //{"username": "string","password": "string","macadd": "string"}
            var payload = "{\"username\":\"" + user.Username + "\"," + "\"password\":\"" + user.Password + "\"," + "\"macadd\":\"" + user.macadd + "\"}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("Auth/RegisterUser", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<int>>();
            readTask.Wait();
            return readTask.Result;
        }

        public ServiceResponse<string> Login(User user)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "text/plain");
            //{"username": "string","password": "string","macadd": "string"}
            var payload = "{\"username\":\"" + user.Username + "\"," + "\"password\":\"" + user.Password + "\"," + "\"macadd\":\"" + user.macadd + "\"}";
            HttpContent C = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("Auth/Login", C);
            response.Wait();
            var data = response.Result;
            var readTask = data.Content.ReadAsAsync<ServiceResponse<string>>();
            readTask.Wait();
            return readTask.Result;
        }

    }
}
