using System.Text;
using System.Xml.Serialization;

namespace ServerConsole
{
    [XmlRoot("return")]
    public sealed class AgreementMain
    {
        [XmlElement("AGREEMENT")]
        public Agreement[] agreements { get; set; }
    }
    public sealed class Agreement
    {
        [XmlElement("AGREEMENT_ORG")]
        public AgreementOrg[] agreementOrgs { get; set; }

        [XmlAttribute]
        public string kadm { get; set; }

        [XmlAttribute]
        public ulong budgetId { get; set; }

        [XmlAttribute]
        public double budgetSumm { get; set; }

        [XmlAttribute()]
        public string caption { get; set; }

        [XmlAttribute]
        public string dateFrom { get; set; }

        [XmlAttribute]
        public string dateTo { get; set; }

        [XmlAttribute]
        public ulong id { get; set; }

        public string GetData()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(kadm.ToString());
            builder.AppendLine(budgetId.ToString());
            builder.AppendLine(budgetSumm.ToString());
            builder.AppendLine(caption);
            builder.AppendLine(dateFrom);
            builder.AppendLine(dateTo);
            builder.AppendLine(id.ToString());

            return builder.ToString();
        }
    }
    public sealed class AgreementOrg
    {
        [XmlElement("SCHEDULE")]
        public Schedule[] Schedules;

        [XmlElement("BO")]
        public BO[] bos;

        [XmlAttribute]
        public double agreementSumm { get; set; }

        [XmlAttribute]
        public double budgetReqsSumm { get; set; }

        [XmlAttribute()]
        public string caption { get; set; }

        [XmlAttribute]
        public ulong id { get; set; }

        [XmlAttribute]
        public double subsidySumm { get; set; }

        public string GetData()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(agreementSumm.ToString());
            builder.AppendLine(budgetReqsSumm.ToString());
            builder.AppendLine(caption);
            builder.AppendLine(id.ToString());
            builder.AppendLine(subsidySumm.ToString());

            return builder.ToString();
        }
    }
    public sealed class Schedule
    {
        [XmlAttribute]
        public string transferDate { get; set; }

        [XmlAttribute]
        public double transferSumm { get; set; }

        public string GetData()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(transferDate);
            builder.AppendLine(transferSumm.ToString());

            return builder.ToString();
        }
    }
    public sealed class BO
    {
        [XmlAttribute]
        public string boNumber { get; set; }

        [XmlAttribute]
        public double amount { get; set; }

        [XmlAttribute]
        public int grbs { get; set; }

        [XmlAttribute]
        public string kcsr { get; set; }

        [XmlAttribute]
        public int kfsr { get; set; }

        [XmlAttribute]
        public int kvr { get; set; }

        [XmlAttribute]
        public int period { get; set; }

        public string GetData()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(boNumber.ToString());
            builder.AppendLine(amount.ToString());
            builder.AppendLine(grbs.ToString());
            builder.AppendLine(kcsr);
            builder.AppendLine(kfsr.ToString());
            builder.AppendLine(kvr.ToString());
            builder.AppendLine(period.ToString());

            return builder.ToString();
        }
    }
}
