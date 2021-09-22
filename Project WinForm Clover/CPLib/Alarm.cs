using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;

using CompAssistLib;
using System.Media;
using WMPLib;
using System.Speech.Synthesis;

namespace CPLib
{
    public static class alarm
    {
        // timer && alarms
        public static Timer timer = new Timer();
        public static List<AlarmItem> alarms = new List<AlarmItem>();

        // txtboxes
        public static TextBox txt_alarm; 
        public static TextBox txt_alarm_desc;

        // checkboxes
        public static CheckBox cb_sun;
        public static CheckBox cb_mon;
        public static CheckBox cb_tues;
        public static CheckBox cb_wednesday;
        public static CheckBox cb_thursday;
        public static CheckBox cb_friday;
        public static CheckBox cb_saturday;
        public static CheckBox cb_repeats;

        // listbox 
        public static ListBox lb;
        public static int lb_index = -1;

        // buttons
        public static Button btn_alarmSound;
        public static Button btn_alarmPic;
        public static Button btn_stopSound;

        // current date
        public static string todayIs;



         
        // picture && sound file
        public static string f_alarmPic = vars.p_pictures;
        public static string f_alarmSound = vars.p_sounds;
        
        // pic && sound extensions
        public static string[] pic_exts = new string[] { ".jpg", ".png", ".gif", ".tiff" };
        public static string[] sound_exts = new string[] { ".wav", ".au", ".snd", ".aif", ".aifc", ".aiff", ".mid", ".midi", ".rmi", ".mpg", ".mpeg", ".m1v", ".mp2", ".mp3", ".mpa", ".mpe", ".m3u", ".avi", ".wmd", ".dvr-ms", ".asx", ".wax", ".wvx", ".wmx", ".wpl", ".asf", ".wma", ".wmv", ".wm" };

        // sound player
        public static WindowsMediaPlayer soundPlayer = new WindowsMediaPlayer();

        // alarm sound volume (changer)
        public static NumericUpDown num_alarmVolume;

        


        // plays a sound
        /// <summary>
        /// plays a sound
        /// </summary>
        /// <param name="f_sound">a sound file or a directory containing sound files</param>
        public static void PlaySound(string f_sound)
        {
            if (soundPlayer.playState == WMPPlayState.wmppsPlaying) { return; }

            if (File.Exists(f_sound))
            {
                soundPlayer.URL = f_sound;
                soundPlayer.controls.play();

            }
            else if (Directory.Exists(f_sound))
            {
                List<string> files = Extra.GetFiles(f_sound, sound_exts);

                if (files.Count > 0)
                {
                    Random ran = new Random();
                    string file = files[ran.Next(files.Count)];

                    soundPlayer.URL = file;
                    soundPlayer.controls.play();
                }
            }
        }



        // shows a dialog like MessageBox.Show() but with a picture
        public static DialogResult ShowMsg(string msg, string title, string f_pic)
        {
            msgbox_alarm msgbox = new msgbox_alarm();
            msgbox.MakeChanges(msg, title, f_pic);
            return msgbox.ShowDialog();
        }

        // removes the selected alarm from the listbox
        public static void RemoveSelectedAlarm()
        {
            if (lb.SelectedIndex == -1) { return; }

            // load xml
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(vars.f_alarms);

            // get nodes
            XmlNode mainNode = xdoc.SelectSingleNode("list/alarms");
            XmlNodeList nodeList = xdoc.SelectNodes("list/alarms/alarm");
            XmlNode alarmedalarmsNode = xdoc.SelectSingleNode("list/alarmed");

            if (nodeList.Count == 0) { return; }

            // get node
            XmlNode alarmNode = nodeList[lb.SelectedIndex];
            string alarmName = alarmNode.SelectSingleNode("name").InnerText;

            // remove the selected alarm
            mainNode.RemoveChild(alarmNode);
            alarms.RemoveAll(a => a.name == alarmName);

            // remove it's name from alarmed alarms
            /* update #1
            string[] strs = alarmedalarmsNode.InnerText.Split(' '); 
            string newstr = "";
            foreach (string _str in strs)
            {
                if (_str != alarmName)
                {
                    newstr += _str + " ";
                }
            }
            alarmedalarmsNode.InnerText = newstr;
            */
            foreach(XmlNode childNode in alarmedalarmsNode)
            {
                if(childNode.InnerText == alarmName)
                {
                    alarmedalarmsNode.RemoveChild(childNode);
                }
            }
         

            // save
            xdoc.Save(vars.f_alarms);

            // update listbox
            UpdateLB();

            // update selected index
            int itemcount = lb.Items.Count;
            if (itemcount > 0 && lb.SelectedIndex == -1)
            {
                lb.SelectedIndex = itemcount - 1;
            }
        }

        // updates listbox
        public static void UpdateLB()
        {
            lb.Items.Clear();

            // load xml
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(vars.f_alarms);


            XmlNodeList nodeList = xdoc.SelectNodes("list/alarms/alarm");

            // loop through each alarm node and add it to listbox
            foreach (XmlNode node in nodeList)
            {
                string name = node.SelectSingleNode("name").InnerText;
                string alarmTime = node.SelectSingleNode("alarmTime").InnerText;
                string alarmLine = name + " " + alarmTime;
                string alarmLBItem = alarmLine.Replace('_', ' ');

                // if alarm isn't alarmed then add the + "[active]" part
                if (alarms.Find(a => a.name == name) != null)
                {
                    lb.Items.Add(alarmLBItem + "  [active]");
                }
                else
                {
                    lb.Items.Add(alarmLBItem);
                }


            }

            // update selected index
            if (lb_index != -1 && lb_index <= lb.Items.Count - 1) { lb.SelectedIndex = lb_index; }
        }

        
        /// <summary>
        /// adds an alarm
        /// </summary>
        /// <param name="str">example: test_alarm 3:50 PM</param>
        /// <param name="desc">alarm description</param>
        public static void AddAlarm(string str, string desc)
        {
            string[] strs = str.Split(' ');
            int length = strs.Length;

            if (length < 3) { vars.log("failed to add alarm", true, true); return; }

            // from str
            string alarmName = strs[0];
            string alarmTime = strs[length - 2];
            string alarmPeriod = strs[length - 1];

            // joined name 
            string joinedName = "";
            int i = 0;
            foreach(string _str in strs)
            {
                if (i < length - 2)
                {
                    if (i == 0) { joinedName += _str; } else
                    {
                        joinedName += " " + _str;
                    }
                }
                i++;
            }
            alarmName = joinedName;
            if(desc == "") { desc = joinedName; }


            string alarmTimePeriod = alarmTime + " " + alarmPeriod;
            DateTime alarmDate;




            // make a DateTime from alarmTimePeriod string
            if (DateTime.TryParseExact(alarmTimePeriod, "t", null, System.Globalization.DateTimeStyles.None, out alarmDate))
            {
                // load xml
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(vars.f_alarms);

                // loop through each alarm and check if this name is already taken
                foreach (XmlNode _node in xdoc.SelectNodes("list/alarms/alarm"))
                {
                    if (_node.SelectSingleNode("name").InnerText == alarmName)
                    {
                        vars.log("this alarm already exists", false, true);
                        return;
                    }
                }

                // create alarm elements
                XmlElement alarmNode = xdoc.CreateElement("alarm");

                XmlElement alarmNameNode = xdoc.CreateElement("name");
                XmlElement alarmDescNode = xdoc.CreateElement("desc");
                XmlElement alarmDayListNode = xdoc.CreateElement("dayList");
                XmlElement alarmTimeNode = xdoc.CreateElement("alarmTime");
                XmlElement alarmRepeatsNode = xdoc.CreateElement("repeats");
                XmlElement alarmPicture = xdoc.CreateElement("picture");
                XmlElement alarmSound = xdoc.CreateElement("sound");

                alarmNameNode.InnerText = alarmName; // alarm name
                alarmDescNode.InnerText = desc; // alarm note
                alarmDayListNode.InnerText = RepeatsFromCB(); // which days this alarm will be active
                alarmTimeNode.InnerText = alarmTimePeriod; // like -> 3:50 PM
                alarmRepeatsNode.InnerText = cb_repeats.Checked.ToString(); // repeats?
                alarmPicture.InnerText = alarm.f_alarmPic;
                alarmSound.InnerText = alarm.f_alarmSound;

                alarmNode.AppendChild(alarmNameNode);
                alarmNode.AppendChild(alarmDescNode);
                alarmNode.AppendChild(alarmDayListNode);
                alarmNode.AppendChild(alarmTimeNode);
                alarmNode.AppendChild(alarmRepeatsNode);
                alarmNode.AppendChild(alarmPicture);
                alarmNode.AppendChild(alarmSound);

                // add the new alarm
                XmlNode list = xdoc.SelectSingleNode("list/alarms");
                list.AppendChild(alarmNode);

                

                // if alarm doesn't repeat [#latestupdate]
                if (!cb_repeats.Checked)
                {
                    // remove the alarm's name from the alarmed list
                    XmlNode alarmedalarmsNode = xdoc.SelectSingleNode("list/alarmed");
                    foreach (XmlNode childNode in alarmedalarmsNode)
                    {
                        if (childNode.InnerText == joinedName)
                        {
                            alarmedalarmsNode.RemoveChild(childNode);
                        }
                    }
                }
                // -----------------------------------------

                // and save
                xdoc.Save(vars.f_alarms);


                // and update
                Update();
            }
            else
            {
                vars.log("failed to add alarm", true, true);
            }


        }


        /// <summary>
        /// from alarms.xml load the alarms to the List
        /// </summary>
        public static void Update()
        {
            // today
            DateTime now = DateTime.Now;
            todayIs = DateInStr(now);

            // clear the current alarms
            alarms.Clear();

            // load xml document
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(vars.f_alarms);

            // main node
            XmlNode mainNode = xdoc.SelectSingleNode("list/alarms");

            // alarmed alarms node
            XmlNode alarmedNode = xdoc.SelectSingleNode("list/alarmed");

            // get alarmed date
            string alarmedDateTxt = alarmedNode.Attributes.GetNamedItem("date").InnerText;
            DateTime alarmedDate;
            DateTime.TryParse(alarmedDateTxt, out alarmedDate);

            // now

            string dayofweek = now.DayOfWeek.ToString();

            Debug.WriteLine(alarmedDateTxt);
            Debug.WriteLine(todayIs);

           

            // reset alarmed alarms
            if (alarmedDateTxt != todayIs)
            {
                // #02 update 1
                alarmedNode.RemoveAll();

                XmlAttribute att = xdoc.CreateAttribute("date");
                att.Value = todayIs;
                alarmedNode.Attributes.Append(att);

                /*
                //alarmedNode.InnerText = ""; // #01 update 1
                foreach(XmlNode childNode in alarmedNode.ChildNodes)
                {
                    alarmedNode.RemoveChild(childNode);
                    Debug.WriteLine(childNode.InnerText);
                }*/
                xdoc.Save(vars.f_alarms);
            }
            else {
                Debug.WriteLine("!!!");
            }

            // get alarmed alarms
            //string[] alarmed_alarms = alarmedNode.InnerText.Split(' '); // #01 update1
            List<string> alarmed_alarms = new List<string>();
            foreach (XmlNode childNode in alarmedNode)
            {
                alarmed_alarms.Add(childNode.InnerText);
            }

            Console.WriteLine(alarmed_alarms);

            // loop through each alarm node
            foreach (XmlNode alarmNode in mainNode.ChildNodes)
            {
                // get alarm info
                string name = alarmNode.SelectSingleNode("name").InnerText;
                string desc = alarmNode.SelectSingleNode("desc").InnerText;
                string days = alarmNode.SelectSingleNode("dayList").InnerText;
                string alarmTime = alarmNode.SelectSingleNode("alarmTime").InnerText;
                string repeats = alarmNode.SelectSingleNode("repeats").InnerText;
                string pic = alarmNode.SelectSingleNode("picture").InnerText;
                string sound = alarmNode.SelectSingleNode("sound").InnerText;

                // if this alarm wasn't alarmed then add it to the list
                if (!alarmed_alarms.Contains(name) && days.Contains(dayofweek))
                {
                    // adds alarm
                    DateTime alarmDate;
                    if (DateTime.TryParseExact(alarmTime, "t", null, System.Globalization.DateTimeStyles.None, out alarmDate))
                    {
                        string alarmLine = name + " " + alarmTime;

                        AlarmItem _alarm = new AlarmItem(name, desc, days, bool.Parse(repeats), alarmDate, alarmLine, pic, sound);
                        alarms.Add(_alarm);
                    }
                    else
                    {
                        vars.log(string.Format("failed to add alarm [{0}}", name));
                    }
                }




            }

            // save file
            xdoc.Save(vars.f_alarms);

            // updates listbox
            UpdateLB();
        }

        public static void Load()
        {

            // timer
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            // listbox (index) event
            lb.SelectedIndexChanged += Lb_SelectedIndexChanged;

            // button events
            btn_alarmPic.Click += Btn_alarmPic_Click;
            btn_alarmSound.Click += Btn_alarmSound_Click;
            btn_stopSound.Click += Btn_stopSound_Click;

            // xml settings
            Settings();

            // volume change event
            num_alarmVolume.ValueChanged += Num_alarmVolume_ValueChanged;


            // update
            Update();
            RMsgs.Load();
        }
        
        // stop's alarm sound
        private static void Btn_stopSound_Click(object sender, EventArgs e)
        {
            soundPlayer.controls.stop();
        }

        // change alarm's volume
        private static void Num_alarmVolume_ValueChanged(object sender, EventArgs e)
        {
            // check for the alarm file
            string alarmfile = vars.f_alarms;
            if (!File.Exists(alarmfile)) { vars.log("alarms.xml is missing", true, true); return; }

            // load xml
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(alarmfile);

            // current alarm volume
            int volume = (int)num_alarmVolume.Value;

            // update volume && save it to xml
            soundPlayer.settings.volume = volume;
            xdoc.SelectSingleNode("list/alarm_soundvolume").InnerText = volume.ToString();
            xdoc.Save(alarmfile);
        }

        // browse alarm picture
        private static void Btn_alarmPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = f_alarmPic;
            fileDialog.ValidateNames = false;
            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = true;
            fileDialog.FileName = "Folder or File Selection";

            bool saving = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                if (File.Exists(file))
                {
                    f_alarmPic = file;
                    saving = true;
                }
                else if (Directory.Exists(Path.GetDirectoryName(file)))
                {
                    f_alarmPic = Path.GetDirectoryName(file);
                    saving = true;
                }
            }

            // save alarm picture
            if (saving)
            {
                XmlDocument xdoc = new XmlDocument();
                string f_alarms = vars.f_alarms;
                xdoc.Load(f_alarms);

                string alarmPic = xdoc.SelectSingleNode("list/alarm_picture").InnerText = f_alarmPic;

                xdoc.Save(f_alarms);
            }
        }

        private static void Btn_alarmSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = f_alarmSound;
            fileDialog.ValidateNames = false;
            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = true;
            fileDialog.FileName = "Folder or File Selection";

            bool saving = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                if (File.Exists(file))
                {
                    f_alarmSound = file;
                    saving = true;
                }
                else if (Directory.Exists(Path.GetDirectoryName(file)))
                {
                    f_alarmSound = Path.GetDirectoryName(file);
                    saving = true;
                }
            }

            // save alarm sound
            if (saving)
            {

                XmlDocument xdoc = new XmlDocument();
                string f_alarms = vars.f_alarms;
                xdoc.Load(f_alarms);


                string alarmPic = xdoc.SelectSingleNode("list/alarm_sound").InnerText = f_alarmSound;

                xdoc.Save(f_alarms);
            }
        }

        // listbox event
        private static void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_index = lb.SelectedIndex;
        }

        // empty string list
        public static List<string> notes = new List<string>();
        public static List<string> names = new List<string>();
        public static List<AlarmItem> alarmedList = new List<AlarmItem>();

        // timer
        private static void Timer_Tick(object sender, EventArgs e)
        {
            // get current time
            DateTime now = DateTime.Now;

            // if its a new day then update
            if (DateInStr(now) != todayIs)
            {
                Update();
            }

            // clears the notes and names




            bool saving = false;

            // loops through each alarm
            foreach (AlarmItem item in alarms)
            {
                // on alarm
                if (now >= item.alarmTime)
                {
                    item.del = true; // check delete as true
                    notes.Add(item.desc); // add alarm description to List<note>
                    names.Add(item.name); // add alarm name to List<name>
                    alarmedList.Add(item);
                    Debug.WriteLine("item repeats: " + item.repeats);

                    saving = true; // set saving as true
                }
            }

            // on saving
            if (saving)
            {


                // load the alarms.xml
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(vars.f_alarms);

                // mark the alarmed alarms inside xml
                XmlNode alarmedalarmsNode = xdoc.SelectSingleNode("list/alarmed");
                foreach (string _name in names)
                {
                    //alarmedalarmsNode.InnerText += " " + _name + " "; // update #1
                    XmlNode alarmedAlarmNode = xdoc.CreateNode(XmlNodeType.Element, "alarm", "");
                    alarmedAlarmNode.InnerText = _name;
                    alarmedalarmsNode.AppendChild(alarmedAlarmNode);
                }


                // loop through each alarm, and check if the alarmed alarm has repeating set to false, if false then delete the alarm from xml
                int i = 0;
                foreach (XmlNode _alarmNode in xdoc.SelectNodes("list/alarms/alarm"))
                {
                    string _alarmName = _alarmNode.SelectSingleNode("name").InnerText;
                    bool _repeats = bool.Parse(_alarmNode.SelectSingleNode("repeats").InnerText);
                    if (names.Contains(_alarmName) && !_repeats)
                    {
                        _alarmNode.ParentNode.RemoveChild(_alarmNode);
                    }
                    i++;
                }

                // clear the notes

                names.Clear();


                // deletes the alarmed alarms
                alarms.RemoveAll(a => a.del == true);
                xdoc.Save(vars.f_alarms); // save xml
                // update listbox
                UpdateLB();
            }

            // display message boxes and play alarm
            if (alarmedList.Count > 0)
            {

                AlarmItem alarmedAlarm = alarmedList[0];
                Image pic = null;

                // play alarm sound
                PlaySound(alarmedAlarm.f_sound);

                // picture && message
                string f_pic = alarmedAlarm.f_pic;
                string msg = alarmedAlarm.desc;

                // set picture
                if (File.Exists(f_pic))
                {
                    pic = Image.FromFile(f_pic);
                }

                // show messageBox

                alarmedList.RemoveAt(0);
                ShowMsg(msg, alarmedAlarm.name, f_pic);
            }
            /*
            // display notes
            if(notes.Count > 0)
            {
                string note = notes[0];
                notes.RemoveAt(0);
                Image img;

                MessageBox.Show(note);
                
            }
            */
            /*
            // displays messages
            foreach(string str in notes)
            {
                MessageBox.Show(str);
            }
            notes.Clear();*/
        }

        public static void Settings()
        {
            if (File.Exists(vars.f_alarms))
            {
                // load if file exists

                // load xml
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(vars.f_alarms);

                // set alarm picture && sound

                string alarmPic = xdoc.SelectSingleNode("list/alarm_picture").InnerText;
                string alarmSound = xdoc.SelectSingleNode("list/alarm_sound").InnerText;

                f_alarmPic = alarmPic;
                f_alarmSound = alarmSound;

                // set volume
                int volume = int.Parse(xdoc.SelectSingleNode("list/alarm_soundvolume").InnerText);
                num_alarmVolume.Value = volume;
                soundPlayer.settings.volume = volume;

                return;
            }


            // xml settings
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;

            // creates a new xml file
            XmlWriter writer = XmlWriter.Create(vars.f_alarms, settings);


            writer.WriteStartElement("list");

            writer.WriteStartElement("alarms");
            writer.WriteEndElement();

            writer.WriteStartElement("alarmed");
            writer.WriteAttributeString("date", DateInStr(DateTime.Now));
            writer.WriteEndElement();

            writer.WriteStartElement("alarm_sound");
            writer.WriteString(alarm.f_alarmSound);
            writer.WriteEndElement();

            writer.WriteStartElement("alarm_picture");
            writer.WriteString(alarm.f_alarmPic);
            writer.WriteEndElement();

            writer.WriteStartElement("alarm_soundvolume");
            writer.WriteString("50");
            writer.WriteEndElement();

            writer.WriteEndElement(); // list


            writer.Close();
        }

        public static string DateInStr(DateTime date)
        {
            string str = string.Format("{0}/{1}/{2}", date.Month, date.Day, date.Year);
            return str;

        }
        public static string RepeatsFromCB()
        {
            string str = "";
            if (cb_sun.Checked) { str += " Sunday"; }
            if (cb_mon.Checked) { str += " Monday"; }
            if (cb_tues.Checked) { str += " Tuesday"; }
            if (cb_wednesday.Checked) { str += " Wednesday"; }
            if (cb_thursday.Checked) { str += " Thursday"; }
            if (cb_friday.Checked) { str += " Friday"; }
            if (cb_saturday.Checked) { str += " Saturday"; }
            if (str == "") { return DateTime.Now.DayOfWeek.ToString(); }
            return str;
        }
    }

    public class AlarmItem
    {
        public string name;
        public string desc;
        public string days;
        public bool repeats = true;

        public DateTime alarmTime;
        public string alarmLine;
        public bool del = false;


        public string f_pic;
        public string f_sound;
        public AlarmItem(string _name, string _desc, string _days, bool _repeats, DateTime _alarmTime, string _alarmLine, string _pic, string _sound)
        {
            name = _name;
            desc = _desc;
            days = _days;
            repeats = _repeats;
            alarmTime = _alarmTime;
            alarmLine = _alarmLine;
            f_pic = _pic;
            f_sound = _sound;
        }
    }
}
