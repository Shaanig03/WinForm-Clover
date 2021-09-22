using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;


using CompAssistLib;
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;

using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;
using System.Xml;

namespace CPLib
{
    public static class vars
    {
        // directories and file locations
        public static string p_files = Application.StartupPath + @"\Files";
        public static string p_sounds = p_files + @"\" + "Sounds";
        public static string p_mods = p_files + @"\Mods";
        public static string p_pictures = p_files + @"\" + "Pictures";
        //public static string p_data = p_files + @"\Data";
        public static string f_cpvars = p_files + @"\vars.xml";
        public static string f_settings = p_files + @"\settings.xml";
        public static string f_alarms = p_files + @"\alarms.xml";

        public static string quickNote = "";

        // refs
        public static XmlDocument xdoc_settings;
        public static ui mainUI;
        public static ui_cmdbar cmdbarUI;

        // keys
        public static int key_hideAndShow;
        public static int key_openQuickNotes;
        public static int key_restartApp;

        public static int key_hideAndShow_cmdBar;
        public static int key_cmdEnter;
        public static int key_openFilesPath;
        // other vars
        public static bool hidden = true;
        public static bool cmdbar_hidden = true;
        public static string str_log = "";
       
        // assembly list
        public static Dictionary<string, LoadedAssembly> assemblyList = new Dictionary<string, LoadedAssembly>();

        
        /// <summary>
        /// loop through each class and check for "OnLoad" method and execute it
        /// </summary>
        public static void ExecuteAssemblyLoadMethods()
        {
            foreach(KeyValuePair<string, LoadedAssembly> key in assemblyList)
            {
                Type[] types = key.Value.assembly.GetTypes();

                foreach (Type _type in types)
                {
                    MethodInfo method = _type.GetMethod("OnLoad");
                    if(method != null) { method.Invoke(null, new object[] { }); }
                }

            }
        }

        /// <summary>
        /// load assemblies from a path
        /// </summary>
        /// <param name="path">path</param>
        /// <returns>a list of loaded assembly names</returns>
        public static List<string> LoadAssembliesFromPath(string path, Mod mod = null)
        {
            List<string> files = Extra.GetFiles(path, new string[] { ".dll" });
            List<string> assemblyNames = new List<string>();

            foreach(string _file in files)
            {
                Assembly v_assembly = Assembly.LoadFrom(_file);
                string fileName = Path.GetFileNameWithoutExtension(_file);
                LoadedAssembly cPAssembly = new LoadedAssembly();
                cPAssembly.assembly = v_assembly;
                cPAssembly.mod = mod;

                assemblyList.Add(fileName, cPAssembly);
                assemblyNames.Add(fileName);
                vars.log(string.Format("assembly {0} has been added", fileName));
            }
            return assemblyNames;
        }

        // the main loader
        public static void Load(ui _mainUI)
        {
            mainUI = _mainUI;
            
            // create directories
            if (!Directory.Exists(p_files)) { Directory.CreateDirectory(p_files); }
            if (!Directory.Exists(p_sounds)) { Directory.CreateDirectory(p_sounds); }
            if (!Directory.Exists(p_pictures)) { Directory.CreateDirectory(p_pictures); }
            if (!Directory.Exists(p_mods)) { Directory.CreateDirectory(p_mods); }
            //if (!Directory.Exists(p_data)) { Directory.CreateDirectory(p_data); }

            

            // key list
            key_hideAndShow = KeyManager.AddKey(mainUI.Handle, new MKey
            {
                name = "hide_and_show",
                key = Keys.D1,
                modifier = 1
            }); // 0
            key_openQuickNotes = KeyManager.AddKey(mainUI.Handle, new MKey
            {
                name = "open_quickNotes",
                key = Keys.Q,
                modifier = 1
            }); // 1
            key_restartApp = KeyManager.AddKey(mainUI.Handle, new MKey
            {
                name = "restartApp",
                key = Keys.Oemtilde,
                modifier = 1
            }); // 2
            key_hideAndShow_cmdBar = KeyManager.AddKey(mainUI.Handle, new MKey
            {
                name = "hide_and_show_cmdbar",
                key = Keys.D3,
                modifier = 1
            }); // 3
            key_cmdEnter = KeyManager.AddKey(mainUI.Handle, new MKey
            {
                name = "cmdEnter",
                key = Keys.Enter,
                modifier = 1
            }); // 4 ( the index should be 4, remember in WndProc)

            key_openFilesPath = KeyManager.AddKey(mainUI.Handle, new MKey
            {
                name = "openFilesPath",
                key = Keys.NumPad5,
                modifier = 1
            }); // 5


            // settings
            if (!File.Exists(f_settings)) { Settings(); }
            xdoc_settings = new XmlDocument();
            xdoc_settings.Load(f_settings);

            // cp vars
            CPVars.Vars();

            // start this app on windows start?
            bool start_onWinStart = bool.Parse(xdoc_settings.SelectSingleNode("config/start_onWinStart").InnerText);
            SetStartOnWinStart(start_onWinStart);

            // alarm
            alarm.Load();

            // load mods
            Mods.Load(vars.p_mods);

            // execute assembly onLoad methods
            ExecuteAssemblyLoadMethods();

            UpdateVars();
        }

        // start this application on windows start?
        public static void SetStartOnWinStart(bool start)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appName = Application.ProductName;
            if (start) { reg.SetValue(appName, Application.ExecutablePath); } else { reg.DeleteValue(appName, false); }

        }

        // log
        public static void log(string txt, bool error = false, bool show = false)
        {
            string _txt;

            if (!error)
            {
                _txt = string.Format("[log]: {0}", txt);
                str_log += _txt + Environment.NewLine;
                if (show) { MessageBox.Show(_txt, "Msg", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                _txt = string.Format("[log >> error]: {0}", txt);
                str_log += _txt + Environment.NewLine;
                if (show) { MessageBox.Show(_txt, "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            // updates command bar log
            ui_cmdbar.UpdateLog();

        }
        public static void clearLog()
        {
            str_log = "";
            ui_cmdbar.UpdateLog();
        }

        public static void UpdateVars()
        {

            // update quickNote
            XmlNode quickNoteNode = xdoc_settings.SelectSingleNode("config/paths/quickNote");
            if (quickNote != null)
            {
                quickNote = quickNoteNode.InnerText;
                if (quickNote != "" && !File.Exists(quickNote)) { vars.log("quickNote file is null", true, true); }
            }
            else { Debug.Fail("XmlNode quickNote is null"); }



            // update keys
            UpdateKeys();
        }

        // creates settings.xml
        public static void Settings()
        {
            // xml settings
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;

            // creates a new xml file
            XmlWriter writer = XmlWriter.Create(f_settings, settings);


            writer.WriteStartElement("config");


            writer.WriteStartElement("keys");
            foreach (MKey mkey in KeyManager.definedKeys)
            {
                writer.WriteStartElement(mkey.name);
                writer.WriteAttributeString("key", mkey.key.ToString());
                writer.WriteAttributeString("modifier", mkey.modifier.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // keys

            // paths
            writer.WriteStartElement("paths");

            // quick note
            writer.WriteStartElement("quickNote");
            string f_quickNote = vars.p_files + @"\quickNote.txt";
            if (!File.Exists(f_quickNote))
            {
                FileStream f = File.Create(f_quickNote);
                f.Close();
            }
            writer.WriteString(f_quickNote);
            writer.WriteEndElement();

            writer.WriteEndElement(); // paths



            writer.WriteStartElement("start_onWinStart");
            writer.WriteString("true");
            writer.WriteEndElement(); // start_onWinStart

            writer.WriteEndElement(); // config
            writer.Close();
        }

        // update keys
        public static void UpdateKeys()
        {
            // get keylist node
            XmlNode mainNode = xdoc_settings.SelectSingleNode("config/keys");

            if (mainNode == null) { Debug.Fail("[error][UpdateKeys()]: nodeList is null"); return; }

            // loop through each key node
            int i = 0;
            foreach (XmlNode node in mainNode.ChildNodes)
            {
                // get key and modifier
                XmlNode keyNode = node.Attributes.GetNamedItem("key");
                XmlNode modifierNode = node.Attributes.GetNamedItem("modifier");

                Keys key;
                int modifier;

                if (!Enum.TryParse(keyNode.InnerText, out key)) { Debug.Fail(string.Format("[error][UpdateKeys()]: key[{0}] key is null ", node.Name)); return; }
                if (!int.TryParse(modifierNode.InnerText, out modifier)) { Debug.Fail(string.Format("[error][UpdateKeys()]: key[{0}] modifier is null ", node.Name)); return; }

                // update key
                KeyManager.definedKeys[i].key = key;
                KeyManager.definedKeys[i].modifier = modifier;

                KeyManager.UpdateKey(mainUI.Handle, i);
                i++;
            }
        }

    }
   
    public class LoadedAssembly
    {
        public Assembly assembly;
        public Mod mod;
        public List<string> cmds = new List<string>();
    }
}
