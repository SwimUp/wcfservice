using System.IO;
using System.Web;

namespace WCFservice
{
    public class Service1 : IService
    {
        public bool GetStatus()
        {
            return true;
        }

        public Stream DownloadFile(string fileName)
        {
            string downloadFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Files/"), fileName);

            if (!File.Exists(downloadFilePath))
                throw new FileNotFoundException(string.Concat("Файл с именем ", fileName, "не найден. Путь файлов: ", downloadFilePath));

            FileStream fs = null;
            try
            {
                fs = new FileStream(downloadFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch
            {
                if (fs != null)
                    fs.Close();
            }

            return fs;
        }

        public void UploadFile(FileTransferRequest request)
        {
            string FilePath = HttpContext.Current.Server.MapPath("~/Files/") + request.FileName;
            
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                request.Data.CopyTo(fs);
            }
            
        }
    }
}
