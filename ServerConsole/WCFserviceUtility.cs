using System.IO;
using ServerConsole.ServiceReference1;

namespace ServerConsole
{
    public static class WCFserviceUtility
    {
        public static ServiceClient Client { get; private set; }

        public static bool CreateConnection()
        {
            Client = new ServiceClient();
            return CheckConnection();
        }

        public static bool CheckConnection()
        {
            return Client.GetStatus();
        }

        public static bool CloseClient()
        {
            Client.Close();
            LOGGER.Log.Info("Соединение с сервером WCF закрыто.");

            return true;
        }

        public static bool DownloadFile(string FilePath, string outFileName = null)
        {
            if (Client == null)
                return false;

            string fileName = outFileName ?? FilePath;

            using (Stream str = Client.DownloadFile(FilePath))
            {
                using (FileStream s = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    str.CopyTo(s);
                }
            }

            return true;
        }

        public static bool UploadFileToServer(string FilePath)
        {
            if (Client == null)
                return false;

            if (!File.Exists(FilePath))
                return false;

            using (FileStream inputStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                Client.UploadFile(FilePath, inputStream);
            }

            return true;
        }
    }
}
