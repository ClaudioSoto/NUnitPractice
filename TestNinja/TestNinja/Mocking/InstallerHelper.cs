using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IInstallerHelperTests _installerHelper;

        public InstallerHelper(IInstallerHelperTests installerHelper)
        {
            _installerHelper = installerHelper;

        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            //var client = new WebClient();
            try
            {
                /*
                client.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);
                */
                _installerHelper.downloadFile(customerName, installerName);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}