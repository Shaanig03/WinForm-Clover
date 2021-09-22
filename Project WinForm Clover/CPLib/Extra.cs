using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;

namespace CPLib
{
    public static class Extra
    {
        public static List<string> GetFiles(string path, string[] exts)
        {
            List<string> list = new List<string>();
            string[] files = Directory.GetFiles(path);

            foreach (string _file in files)
            {
                if (exts.Contains(Path.GetExtension(_file)))
                {
                    list.Add(_file);
                }

            }

            return list;
        }

        public static XmlWriter NewXmlWriter(string f)
        {
            // xml settings
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;

            // creates a new xml file
            XmlWriter writer = XmlWriter.Create(f, settings);
            return writer;
        }

        public static XmlDocument XmlDoc(string f)
        {
            // xml xml doc
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(f);
            return xdoc;
        }
    }
}
