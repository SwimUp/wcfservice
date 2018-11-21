using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ServerConsole
{
    public static class DatabaseUtility
    {
        public static MySqlConnection Connection;

        public static void CreateDBConnection(string Host, string DataBase, string UserName, string Password)
        {
            string connection = string.Concat("Database=", DataBase, ";Data Source=", Host, ";User Id=", UserName, ";Password=",Password, ";charset=cp1251");

            Connection = new MySqlConnection(connection);

            if(LOGGER.Log != null)
                LOGGER.Log.Info("Установлено соединение с базой данных [" + connection + "]");
        }
        public static bool CloseConnection()
        {
            Connection.Close();
            LOGGER.Log.Info("Соединение закрыто.");

            return true;
        }
        public static bool InsertAGREEMENTData(AgreementMain main)
        {
            if (Connection == null)
                return false;

            if (LOGGER.Log != null)
                LOGGER.Log.Info("Загрузка AGREEMENT.xml в базу данных");

            string CommandTextAgreement = "INSERT into AGREEMENT (UNIQUE_ID, KADM, budgetId, budgetSumm, caption, dateFrom, dateTo, id) VALUES (@UNIQUE_ID, @KADM, @budgetId, @budgetSumm, @caption, @dateFrom, @dateTo, @id) ";
            string CommandTextAgreementOrg = "INSERT into AGREEMENT_ORG (UNIQUE_ID, agreementSumm, budgetReqsSumm, caption, id, subsidySumm, AgreementID) VALUES (@UNIQUE_ID, @agreementSumm, @budgetReqsSumm, @caption, @id, @subsidySumm, @AgreementID) ";
            string CommandTextSchedule = "INSERT into schedule (transferDate, transferSumm, AgreementOrgID, UNIQUE_ID) VALUES (@transferDate, @transferSumm, @AgreementOrgID, @UNIQUE_ID) ";
            string CommandTextBO = "INSERT into bo (UNIQUE_ID, Bo_number, amount, grbs, kcsr, kfsr, kvr, period, AgreementOrgID) VALUES (@UNIQUE_ID, @Bo_number, @amount, @grbs, @kcsr, @kfsr, @kvr, @period, @AgreementOrgID) ";

            MySqlCommand myCommand = new MySqlCommand(CommandTextAgreement, Connection);
            MySqlCommand myCommand2 = new MySqlCommand(CommandTextAgreementOrg, Connection);
            MySqlCommand myCommand3 = new MySqlCommand(CommandTextSchedule, Connection);
            MySqlCommand myCommand4 = new MySqlCommand(CommandTextBO, Connection);
            int allAGreeOrg = 0;
            int allSchedule = 0;
            int allBO = 0;
            for (int i = 0; i < main.agreements.Length; i++)
            {
                Agreement agr = main.agreements[i];

                myCommand.Parameters.AddWithValue("@UNIQUE_ID", i);
                myCommand.Parameters.AddWithValue("@KADM", agr.kadm);
                myCommand.Parameters.AddWithValue("@budgetId", agr.budgetId);
                myCommand.Parameters.AddWithValue("@budgetSumm", agr.budgetSumm);
                myCommand.Parameters.AddWithValue("@caption", agr.caption);
                myCommand.Parameters.AddWithValue("@dateFrom", agr.dateFrom);
                myCommand.Parameters.AddWithValue("@dateTo", agr.dateTo);
                myCommand.Parameters.AddWithValue("@id", agr.id);

                myCommand.ExecuteNonQuery();
                myCommand.Parameters.Clear();

                for (int i2 = 0; i2 < agr.agreementOrgs.Length; i2++)
                {
                    AgreementOrg org = agr.agreementOrgs[i2];

                    myCommand2.Parameters.AddWithValue("@UNIQUE_ID", allAGreeOrg);
                    myCommand2.Parameters.AddWithValue("@agreementSumm", org.agreementSumm);
                    myCommand2.Parameters.AddWithValue("@budgetReqsSumm", org.budgetReqsSumm);
                    myCommand2.Parameters.AddWithValue("@caption", org.caption);
                    myCommand2.Parameters.AddWithValue("@id", org.id);
                    myCommand2.Parameters.AddWithValue("@subsidySumm", org.subsidySumm);
                    myCommand2.Parameters.AddWithValue("@AgreementID", i);

                    myCommand2.ExecuteNonQuery();
                    myCommand2.Parameters.Clear();

                    for (int i3 = 0; i3 < org.Schedules.Length; i3++)
                    {
                        Schedule sch = org.Schedules[i3];

                        myCommand3.Parameters.AddWithValue("@transferDate", sch.transferDate);
                        myCommand3.Parameters.AddWithValue("@transferSumm", sch.transferSumm);
                        myCommand3.Parameters.AddWithValue("@AgreementOrgID", allAGreeOrg);
                        myCommand3.Parameters.AddWithValue("@UNIQUE_ID", allSchedule);

                        myCommand3.ExecuteNonQuery();
                        myCommand3.Parameters.Clear();

                        allSchedule++;

                    }

                    if (org.bos != null)
                    {
                        for (int i4 = 0; i4 < org.bos.Length; i4++)
                        {
                            BO bo = org.bos[i4];

                            myCommand4.Parameters.AddWithValue("@UNIQUE_ID", allBO);
                            myCommand4.Parameters.AddWithValue("@Bo_number", bo.boNumber);
                            myCommand4.Parameters.AddWithValue("@amount", bo.amount);
                            myCommand4.Parameters.AddWithValue("@grbs", bo.grbs);
                            myCommand4.Parameters.AddWithValue("@kcsr", bo.kcsr);
                            myCommand4.Parameters.AddWithValue("@kfsr", bo.kfsr);
                            myCommand4.Parameters.AddWithValue("@kvr", bo.kvr);
                            myCommand4.Parameters.AddWithValue("@period", bo.period);
                            myCommand4.Parameters.AddWithValue("@AgreementOrgID", allAGreeOrg);

                            myCommand4.ExecuteNonQuery();
                            myCommand4.Parameters.Clear();

                            allBO++;

                        }
                    }

                    allAGreeOrg++;

                }

            }

            return true;
        }
    }
}
