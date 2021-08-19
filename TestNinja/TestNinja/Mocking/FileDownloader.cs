using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string customerName, string installerName);
    }

    public class FileDownloader : IFileDownloader
    {

        public void DownloadFile(string customerName, string installerName)
        {
            var client = new WebClient();

            client.DownloadFile(customerName, installerName);
        }
    }
}
