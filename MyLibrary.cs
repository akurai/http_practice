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



            string filepath = "./ignoredfiles/myfile.html";
            string filedir = Path.GetDirectoryName(filepath);
            if(!Directory.Exists(filedir)){
                Directory.CreateDirectory(filedir);
            }
            File.WriteAllText(filepath,erkezett);
            
            

            System.Console.WriteLine("******************************downloaded******************************");

    }
    }
}