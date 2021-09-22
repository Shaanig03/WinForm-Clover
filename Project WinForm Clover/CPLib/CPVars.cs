using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Xml;

namespace CPLib
{

    // Control Panel Variables
    public static class CPVars
    {
        public static XmlDocument doc;
        private static bool loaded = false;

        // creates vars.xml
        public static void Vars()
        {
            if (loaded) { return; }

            // file
            string f_cpvars = vars.f_cpvars;

            // creates vars.xml file
            if (!File.Exists(f_cpvars))
            {
                XmlWriter writer = Extra.NewXmlWriter(f_cpvars);
                writer.WriteStartElement("vars");
                writer.WriteEndElement();
                writer.Close();
            }

            // loads the file
            doc = Extra.XmlDoc(f_cpvars);
            loaded = true;
        }


        public static XmlNode GetVar(string name)
        {
            foreach(XmlNode node in doc.SelectNodes("vars/var"))
            {
                if(node.Attributes[0].Value == name)
                {
                    return node;
                }
            }
            return null;
        }

        public static XmlNode RegisterVar(string name, string type)
        {
            XmlNode node = GetVar(name);
            if (node != null) { return node; }

            XmlNode nodeVar = doc.CreateNode(XmlNodeType.Element, "var", "");
            XmlAttribute nodeA1 = doc.CreateAttribute("name");
            
            XmlAttribute nodeA2 = doc.CreateAttribute("type");
            nodeA1.Value = name;
            nodeA2.Value = type;

            nodeVar.Attributes.Append(nodeA1);
            nodeVar.Attributes.Append(nodeA2);

            doc.SelectSingleNode("vars").AppendChild(nodeVar);
            Save();

            return nodeVar;
        }

        public static XmlNode NewListValue(string name, string txt, XmlNode parent)
        {
            XmlNode node_value = CPVars.doc.CreateNode(XmlNodeType.Element, "value", "");
            if(txt != "") { node_value.InnerText = txt; }

            XmlAttribute attri = CPVars.doc.CreateAttribute("name");
            attri.Value = name;
            node_value.Attributes.Append(attri);

            parent.AppendChild(node_value);
            return node_value;
        }
        public static void Save()
        {
            doc.Save(vars.f_cpvars);
        }
    }
}
