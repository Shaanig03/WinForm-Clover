using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CPLib
{
    public static class RMsgs
    {
        public static XmlNode node;

        public static Button btn_add;
        public static Button btn_show;
        public static Button btn_remove;

        public static List<RMsgItem> msgs = new List<RMsgItem>();
        public static void Load()
        {
            node = CPVars.RegisterVar("RMsgs", "");

            btn_add.Click += Btn_add_Click;
            btn_show.Click += Btn_show_Click;
            btn_remove.Click += Btn_remove_Click;


            if(node.ChildNodes.Count == 0)
            {
                XmlNode node_list = CPVars.doc.CreateNode(XmlNodeType.Element, "list", "");
                node.AppendChild(node_list);

                XmlNode node_showedMsgs = CPVars.doc.CreateNode(XmlNodeType.Element, "showed_msgs", "");
                node.AppendChild(node_showedMsgs);

                XmlNode node_today = CPVars.doc.CreateNode(XmlNodeType.Element, "today", "");
                node_today.InnerText = alarm.DateInStr(DateTime.Now);
                node.AppendChild(node_today);
                CPVars.Save();
            }

            Update();
        }

        private static void Btn_remove_Click(object sender, EventArgs e)
        {
            RemoveRMsg(alarm.txt_alarm.Text);
        }

        private static void Btn_add_Click(object sender, EventArgs e)
        {
            AddRMsg(alarm.txt_alarm.Text, alarm.txt_alarm_desc.Text, alarm.f_alarmPic);

        }

        private static void Btn_show_Click(object sender, EventArgs e)
        {
            if(msgs.Count == 0) { return; }

            Random ran = new Random();
            RMsgItem item = msgs[ran.Next(0, msgs.Count)];
            msgs.Remove(item);

            XmlNode node_rmsgItem = CPVars.doc.CreateNode(XmlNodeType.Element, "item", "");
            node_rmsgItem.InnerText = item.title;
            node.ChildNodes[1].AppendChild(node_rmsgItem);

            CPVars.Save();
            alarm.ShowMsg(item.desc, item.title, item.f_pic);
            
        }

        public static void AddRMsg(string title, string desc, string f_pic)
        {
            if(title == "") { vars.log("title is empty, type a name in the alarm textbox", true, true); return; }

            foreach(XmlNode childNode in node.ChildNodes[0].ChildNodes)
            {
                string childnode_title = childNode.ChildNodes[0].InnerText;
                if(childnode_title == title)
                {
                    vars.log("A picture note with this name already exists", true, true);
                    return;
                }
            }

            XmlDocument doc = CPVars.doc;
            XmlNode node_rmsg = doc.CreateNode(XmlNodeType.Element, "rmsg", "");

            XmlNode node_title = doc.CreateNode(XmlNodeType.Element, "title", "");
            XmlNode node_desc = doc.CreateNode(XmlNodeType.Element, "desc", "");
            XmlNode node_picture = doc.CreateNode(XmlNodeType.Element, "picture", "");

            node_title.InnerText = title;
            node_desc.InnerText = desc;
            node_picture.InnerText = f_pic;

            node_rmsg.AppendChild(node_title);
            node_rmsg.AppendChild(node_desc);
            node_rmsg.AppendChild(node_picture);

            node.ChildNodes[0].AppendChild(node_rmsg);
            CPVars.Save();
            Update();

            vars.log("picture note added", false, true);
        }
        public static void RemoveRMsg(string title)
        {
            if (title == "") { vars.log("title is empty", true, true); return; }

            
            foreach (XmlNode childNode in node.ChildNodes[0].ChildNodes)
            {
                string childnode_title = childNode.ChildNodes[0].InnerText;
                if (childnode_title == title)
                {
                    node.ChildNodes[0].RemoveChild(childNode);
                    CPVars.Save();
                    Update();

                    vars.log(string.Format("picture note '{0}' removed", title), false, true);
                    return;
                }
            }

            vars.log(string.Format("there is no picture note named '{0}'", title), true, true);
        }
        
        public static void Update()
        {
            string today = alarm.DateInStr(DateTime.Now);
            string date = node.ChildNodes[2].InnerText;

            if(today != date)
            {
                node.ChildNodes[1].RemoveAll();
                node.ChildNodes[2].InnerText = today;
            }

            XmlNode node_smsgs = node.ChildNodes[1];
            List<string> node_showedmsgs = new List<string>();

            foreach(XmlNode showedmsg in node_smsgs.ChildNodes)
            {
                node_showedmsgs.Add(showedmsg.InnerText);
            }

            foreach(XmlNode childNode in node.ChildNodes[0].ChildNodes)
            {
                string title = childNode.ChildNodes[0].InnerText;
                if (!node_showedmsgs.Contains(title)) {
                    string desc = childNode.ChildNodes[1].InnerText;
                    string f_pic = childNode.ChildNodes[2].InnerText;

                    RMsgItem item = new RMsgItem(title, desc, f_pic);
                }

                
            }

            CPVars.Save();
        }

        public class RMsgItem
        {
            public string title;
            public string desc;
            public string f_pic;

            public RMsgItem(string _title, string _desc, string _fpic)
            {
                title = _title;
                desc = _desc;
                f_pic = _fpic;

                RMsgs.msgs.Add(this);
            }
        }
    }

}
