using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using Tp3.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://localhost:44344/");

            var requestToken = new RestRequest("api/authenticate/token", Method.POST);
            requestToken.AddJsonBody(JsonConvert.SerializeObject(new
            {
                Email = "christian@gmail.com",
                Password = "123456"
            }));

            var token = client.Post<String>(requestToken);
            JObject rss = JObject.Parse(token.Content);
            string rssToken = (string)rss["token"];

            var request = new RestRequest("api/amigos",Method.GET, DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + rssToken);

            var response = client.Get<List<Amigo>>(request);
            Console.WriteLine(response.Content);
            
        }
    }
}
