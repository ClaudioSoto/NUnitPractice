using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IInstallerHelperTests
    {
        void downloadFile(string customerName, string installerName);
    }
    public class FileRepository : IInstallerHelperTests
    {
        private string _setupDestinationFile;
        public void downloadFile(string customerName, string installerName)
        {
            var client = new WebClient();
            client.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);
        }
    }
}
