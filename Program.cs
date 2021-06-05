using System;

using RestSharp;
using Newtonsoft.Json;

namespace boomTownApi
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Return ID's

            // Contact api and get top level information
            var client = new RestClient("https://api.github.com/orgs/boomtownroi");
            var request = new RestRequest(Method.GET);

            // store response and get the content and status code
            var response = client.Execute(request);
            var content = response.Content; // replace with response.Content

            // turn JSON string into a c# object
            dynamic jsonObject = JsonConvert.DeserializeObject(content);

            // search for specifc string in any url's
            string urlInfo = urlSearcher(jsonObject, "https://api.github.com/orgs/BoomTownROI");

            Console.WriteLine("Paths and corresponding id's or status codes if failed---------\n");
            Console.WriteLine(urlInfo);

            //2. Perform Verifications

            DateTime created_at = DateTime.Parse((string)jsonObject.created_at);
            DateTime updated_at = DateTime.Parse((string)jsonObject.updated_at);

            int dateRelation = DateTime.Compare(created_at, updated_at); // if less 0, created_at is earlier than updated at
            if (dateRelation < 0){
                Console.WriteLine($"The created_at date ({created_at}), is earlier than the updated_at date ({updated_at})");
            }
            else{
                Console.WriteLine($"The created_at date ({created_at}), is NOT earlier than the updated_at date ({updated_at})");
            }
            Console.WriteLine();

            // store needed values before changing client
            int publicReposNum = (int)jsonObject.public_repos;
            // Make request to repo and deserialize the response content
            client = new RestClient("https://api.github.com/orgs/boomtownroi/repos");
            response = client.Execute(request);
            content = response.Content;
            jsonObject = JsonConvert.DeserializeObject(content);

            //number of repos
            int totalRepos = numObjects(jsonObject);
            bool repoFlag = false;
            if (totalRepos == publicReposNum){ repoFlag = true; }
            Console.WriteLine($"The public_repos attribute is {publicReposNum} and total repos is {totalRepos} therefore it is {repoFlag} that they are the same.\n");


            


        }
        private static int numObjects(dynamic jsonObject){
            int count = 0;
            foreach (var entry in jsonObject){
                count++;
                //Console.WriteLine(entry.Name);
            }
            return count;
        }

        // static method to search all urls containing a certain string specified as searchUrl
        // Returns a string with the formatted response based on status codes and id attributes.
        private static string urlSearcher(dynamic jsonObject, string searchUrl){
            // string to return found information
            string returnString = "";
            foreach (var entry in jsonObject){
                string key = entry.Name;
                string value = entry.Value;

                //check to see if key has url in it
                if (key.Contains("url")){
                    //check to see if searchUrl is in the value of the entry but not the same string (avoiding infinite searching)
                    if (value.Contains(searchUrl) && (value != searchUrl)){  
                        returnString += $"{value}: " + urlIds(value) + "\n\n"; // call helper method to return formatted string of Id's for one url
                        //break; // TAKE THIS OUT WHEN NOT TESTING
                    }
                }
            }
            return returnString;
        }
        private static string urlIds(string url){
            
            string returnString = "";
            
            //format client and response and check if status code is 200
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            dynamic jsonObject = JsonConvert.DeserializeObject(response.Content);

            int statusCode = (int)response.StatusCode;
            if (!(statusCode == 200)){
                //return statusCode code 
                returnString += $"Returned status code {statusCode}";
            }
            else{
                //loop through all entries with name "id" and return in format of (id's: 123, 123213, 123123)
                foreach (var entry in jsonObject){ // outer JSON object
                    foreach (var childEntry in entry){ // Each JSON object
                        if ((string)childEntry.Name == "id"){
                            returnString += (string)childEntry.Value + ", ";
                        }
                    }
                }
            }
            return returnString;
        }
    }
}
