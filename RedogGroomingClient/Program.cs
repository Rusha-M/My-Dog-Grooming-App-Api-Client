using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiProjectReDogGrooming.Models;

namespace RedogGroomingClient
{
    class Program
    {
        static async Task DoWork()
        {
            HttpClient theClient = new HttpClient();
            theClient.BaseAddress = new Uri("https://localhost:44360/");
            theClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await theClient.GetAsync("api/Client");
            if(response.IsSuccessStatusCode)
            {
                var returnedClient = await response.Content.ReadAsAsync<IEnumerable<Client>>();
                foreach(Client cl in returnedClient)
                {
                    Console.WriteLine(cl.ClientID);
                }
            }
        }
        static void Main(string[] args)
        {
            DoWork().Wait();
            
        }
    }
}
