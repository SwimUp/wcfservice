using System;
using System.IO;
using System.Net;
using MySql.Data.MySqlClient;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            LOGGER.InitLogger();

            if (!WCFserviceUtility.CreateConnection())
            {
                Console.WriteLine("Нет соединения");
                LOGGER.Log.Error("Попытка соединения со службой WCF (неудача)");
                Console.ReadKey();

                WCFserviceUtility.Client.Close();
                return;
            }

            Console.WriteLine("Соединение установлено");
            LOGGER.Log.Info("Соединение с службой WCF установлено");

            /* Загрузка файла с любого другого удаленного сервера
            if(!File.Exists("AGREEMENT.xml"))
            {
                WebClient web = new WebClient();
                web.DownloadFile("http://localhost/Files/AGREEMENT.xml", "AGREEMENT.xml");
                LOGGER.Log.Info("Загрузка файла AGREEMENT.xml");
            }
            ==================================================================== */

            /* Загрузка файла с веб-сервера посредством службы
            if (!File.Exists("AGREEMENT.xml"))
                WCFserviceUtility.DownloadFile("AGREEMENT.xml");
            ============================================================= */

            /* Десериализация, загрузка в БД*/
            AgreementMain main = (AgreementMain)XMLUtility.DeserializeData("AGREEMENT.xml", typeof(AgreementMain));

            DatabaseUtility.CreateDBConnection("localhost", "agreement", "root", "admin");
            DatabaseUtility.Connection.Open();

            DatabaseUtility.InsertAGREEMENTData(main);

            DatabaseUtility.CloseConnection();


            /*
            DatabaseUtility.CreateDBConnection("localhost", "log", "root", "admin");
            DatabaseUtility.Connection.Open();
            string CommandText = "Select * from logdb";
            MySqlCommand myCommand = new MySqlCommand(CommandText, DatabaseUtility.Connection);

            MySqlDataReader MyDataReader = myCommand.ExecuteReader();

            while (MyDataReader.Read())
            {
                Console.WriteLine(MyDataReader.GetValue(0));
                Console.WriteLine(MyDataReader.GetValue(1));
                Console.WriteLine(MyDataReader.GetValue(2));
                Console.WriteLine(MyDataReader.GetValue(3));
            }

            MyDataReader.Close();
            DatabaseUtility.Connection.Clone();
            */

            /*
             * Загрузка файлов
            string[] path = new string[4]
            {
                "SUBSIDY.xml",
                "LIST_SERVICE_WORK.xml",
                "INDUSTRY_LIST.xml",
                "AGREEMENT.xml"
            };
            for (int i = 0; i < path.Length; i++)
            {
                bool result = UploadFileToServer(path[i]);
                Console.WriteLine("result: " + result);
            }
            */

            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();

            WCFserviceUtility.CloseClient();
        }
    }
}
