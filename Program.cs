using System;

using RestSharp;


namespace boomTownApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.github.com/orgs/boomtownroi");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request).Content;
            Console.WriteLine(response);
        }
    }
}
