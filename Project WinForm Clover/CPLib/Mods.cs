using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;


namespace CPLib
{
    public static class Mods
    {
        public static Dictionary<string, Mod> List = new Dictionary<string, Mod>();
        public static ListBox lb;
        public static TextBox txt_modName;
        public static TextBox txt_modDesc;

        // load mods from a path
        public static void Load(string path)
        {
            // load each mod
            string[] mods = Directory.GetDirectories(path);
            foreach(string _mod in mods)
            {
                LoadMod(_mod);
            }

            // add listbox click event
            lb.SelectedValueChanged += Lb_SelectedValueChanged;
            ListMods();
        }

        private static void Lb_SelectedValueChanged(object sender, EventArgs e)
        {
            Mod mod;
            if(lb.SelectedIndex == -1) { return; }
            if(!List.TryGetValue(lb.SelectedItem as string, out mod)) { return; }

            txt_modName.Text = mod.name;
            string f_modinfo = mod.p_mod + @"\info.txt";

            if (File.Exists(f_modinfo))
            {
                txt_modDesc.Text = File.ReadAllText(f_modinfo);
            }
            


        }

        // loads a mod
        public static void LoadMod(string path)
        {
            // check for the mod path
            if (!Directory.Exists(path)) { vars.log(string.Format("invalid path, could not load mod", path), true, true); return; }

            string f_mod = path + @"\mod.xml";

            // xml
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(f_mod);

            // mod name and desc
            string modName = xdoc.SelectSingleNode("mod/name").InnerText;
            string modDesc = xdoc.SelectSingleNode("mod/desc").InnerText;

            // create a new mod class
            Mod mod = new Mod();
            mod.name = modName;
            mod.desc = modDesc;
            mod.p_mod = path;
            mod.assemblies = vars.LoadAssembliesFromPath(path, mod); // load assemblies




            // add it to mod list
            List.Add(modName, mod);

            vars.log(string.Format("Mod [{0}] has been loaded", modName));
        }



        public static void ListMods()
        {
            lb.Items.Clear();

            foreach(KeyValuePair<string, Mod> _keyvalue in List)
            {
                lb.Items.Add(_keyvalue.Key);
            }
        }
    }

    
    public class Mod
    {
        public string name;
        public string desc;
        public string p_mod;

        public List<string> assemblies = new List<string>();
    }
}
