using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerConsole
{
    [XmlRoot("return")]
    public sealed class AGREEMENTMain
    {
        [XmlElement("AGREEMENT")]
        public AGREEMENT[] AGREEMENTs { get; set; }
    }
    public sealed class AGREEMENT
    {
        [XmlElement("AGREEMENT_ORG")]
        public AGREEMENT_ORG[] AGREEMENT_ORGs { get; set; }

        [XmlAttribute]
        public string KADM { get; set; }

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

            builder.AppendLine(KADM.ToString());
            builder.AppendLine(budgetId.ToString());
            builder.AppendLine(budgetSumm.ToString());
            builder.AppendLine(caption);
            builder.AppendLine(dateFrom);
            builder.AppendLine(dateTo);
            builder.AppendLine(id.ToString());

            return builder.ToString();
        }
    }
    public sealed class AGREEMENT_ORG
    {
        [XmlElement("SCHEDULE")]
        public SCHEDULE[] SCHEDULEs;

        [XmlElement("BO")]
        public BO[] BOs;

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
    public sealed class SCHEDULE
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
        public string Bo_number { get; set; }

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

            builder.AppendLine(Bo_number.ToString());
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
