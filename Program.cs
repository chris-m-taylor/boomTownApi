using System;

using RestSharp;
using Newtonsoft.Json;


namespace boomTownApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Output Data

            // Contact api and get top level information
            var client = new RestClient("https://api.github.com/orgs/boomtownroi");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request).Content;
            Console.WriteLine(response);

            // turn JSON string into a c# object
            dynamic deserialize = JsonConvert.DeserializeObject(response);
            Console.WriteLine(deserialize.login);

            //contact 

            // get all urls and test if they return code 200 OK


            //2. Perform Verifications

        }
    }
}
