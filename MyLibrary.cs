using System.IO;
using System.Net;

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
            WebRequest request = WebRequest.Create("https://docs.microsoft.com");
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
    }

        
}