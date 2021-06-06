# boomTownApi
This code is the result of a coding exersize to contact the GitHub API for BoomTown! and perform various tasks.

## How to Run  
1. Download the code and change your working directory to the file you have downloaded.
2. Make sure you have .NET installed on your computer by typing `dotnet` into your command line.
3. To run type `dotnet run` in the folder than houses the program.cs.

## The Prompt
Using the GitHub API and an object-oriented language of choice (preferably C#), pull top-level details for the BoomTownROI organization at:
https://api.github.com/orgs/boomtownroi
From the top-level organization details result object, complete the following:
1. Output Data:
- Follow all urls containing "api.github.com/orgs/BoomTownROI" in the path, and for responses with a 200 status code, retrieve and display all 'id' keys/values in the response objects. For all non-200 status codes, give some indication of the failed request. HINT: Devise a way for the end user to make sense of the id values, related to the original resource route used to retrieve the data.
2. Perform Verifications:
- On the top-level BoomTownROI organization details object, verify that the 'updated_at' value is later than the 'created_at' date.
- On the top-level details object, compare the 'public_repos' count against the repositories array returned from following the 'repos_url', verifying that the counts match. HINT: The public repositories resource only returns a default limit of 30 repo objects per request.

## Development Process
The first step I took when recieving the task was to use Postman to contact the API so I could get a look at the data I would be working with. I also noticed that the preferred language was c# so I decided to go with .NET although I only had experience with Node.js prior to this assignment.  

After recieving the json object, I saw that Postman was using a library called RestSharp to send requests. I looked into the library and decided it would be a good choice to also use this library in my code. The next road bump that I hit was working with the json objects inside of c#. I found a library called JSON.NET that seemed to be very popular with other c# developers and also had decent documentation. I then made the first step of calling the top level repository and began building out helper functions when I started to loop through the lower level urls inside of the response object.  

This was a great experience and if I were to do it again I would most likely take more advantage of the JSON.NET library as I could have simplified some processes if I had. This was only a short assignment but I am glad I decided to tackle the project using c# and .NET as I now feel much more comfortable in it than I did before.

