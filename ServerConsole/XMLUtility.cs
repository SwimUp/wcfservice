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
        public static object DeserializeData(string path, System.Type dataType)
        {
            XmlSerializer formatter = new XmlSerializer(dataType);

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                object data = formatter.Deserialize(fs);

                return data;
            }
        }
    }
}
