using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace MyLibrary
{
    public class MyNetStuff{
        public static void downloadFileAndWriteToHtml(){
            var myClient = new WebClient();
            Stream response = myClient.OpenRead("https://docs.microsoft.com/dotnet/");
            StreamReader sr = new StreamReader(response);
            string erkezett = sr.ReadToEnd();
            sr.Close();
            response.Close();

            writeToFile(erkezett, "myfile.html");
            
            System.Console.WriteLine("******************************finished******************************");
        }
        public static void learnWebRequest(){
            WebRequest request = WebRequest.Create("https://www.youtube.com/");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            System.Console.WriteLine(((HttpWebResponse) response).StatusDescription);
            using (Stream datastream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(datastream);
                string responseFromServer = reader.ReadToEnd();
                writeToFile(responseFromServer, "myfile2.html");
            }
            response.Close();
        }
        private static void writeToFile(string content, string fileName){
            string filepath = "./ignoredfiles/" + fileName;
            string filedir = Path.GetDirectoryName(filepath);
            if(!Directory.Exists(filedir)){
                Directory.CreateDirectory(filedir);
            }
            File.WriteAllText(filepath,content);
        }
        public static void sendDataWebRequest(){
            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                writeToFile(responseFromServer, "myfile2.html");
            }

            // Close the response.
            response.Close();
        }
    
        public static async Task<string> requestFromMoreSiteAsync(Uri[] uris){
            List<Task> requestList = new List<Task>();
            foreach(Uri uri in uris){
                System.Console.WriteLine(uri.DnsSafeHost);
                requestList.Add(requestFromSiteAsync(uri));
            }
            while(requestList.Count > 0){
                Task<Uri> finishedTask = (Task<Uri>) await Task.WhenAny(requestList);
                System.Console.WriteLine(finishedTask.Result.DnsSafeHost + " finished downloading");
                requestList.Remove(finishedTask);
            }

            // await requestFromSiteAsync(urls[0]);
            System.Console.WriteLine("all request completed");
            return "OK";
        }
        private static async Task<Uri> requestFromSiteAsync(Uri uri){
            await Task.Run(() => {
                WebRequest request = WebRequest.Create(uri);
                WebResponse response = request.GetResponse();
                System.Console.WriteLine(((HttpWebResponse) response).StatusDescription);
                using (Stream datastream = response.GetResponseStream()){
                    StreamReader sr = new StreamReader(datastream);
                    string responseFromServer = sr.ReadToEnd();
                    writeToFile(responseFromServer, uri.DnsSafeHost + ".html");
                }
                response.Close();
            });
            return uri;
        }
    }

        
}