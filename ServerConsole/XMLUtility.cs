using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ServerConsole
{
    public static class XMLUtility
    {
        public static object DeserializeData(string Path, System.Type DataType)
        {
            XmlSerializer formatter = new XmlSerializer(DataType);

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                object data = formatter.Deserialize(fs);

                return data;
            }
        }
    }
}
