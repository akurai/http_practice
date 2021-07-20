using System.IO;
using System.Net;
using MyLibrary;
using System.Threading.Tasks;
using System;

namespace csharp_network_stuff
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //MyLibrary.MyNetStuff.downloadFileAndWriteToHtml();
            // MyLibrary.MyNetStuff.learnWebRequest();
            //MyLibrary.MyNetStuff.sendDataWebRequest();
            Uri[] urls = {
                new Uri("http://www.google.com"), 
                new Uri("http://www.youtube.com"), 
                new Uri("http://www.docs.microsoft.com"),
                new Uri("http://10.207.9.141/anti-doksik"),
                };
            await MyLibrary.MyNetStuff.requestFromMoreSiteAsync(urls);
        }
    }
}
