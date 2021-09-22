using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Xml;

using CPLib;


namespace SimpleCmds
{
    public static class Paths
    {
        public static XmlNode node_paths;
        public static string path_opened = "";

        public static string txt_path_set_replaced = "path <{0}> updated";
        public static string txt_path_created = "path <{0}> added";
        public static string txt_path_deleted = "path <{0}> deleted";
        public static string txt_path_list = @"path  <{0}>:  ""{1}""";
        public static string txt_browser_node_not_found = @"missing browser path, use /path set browser <your_browser_full_path.exe>";
        public static string txt_browser_path_not_set = @"browser path not set, use /path set browser <your_browser_full_path.exe>";
        

        public static void Load()
        {
            // "CP_Paths"
            node_paths = CPVars.RegisterVar("CP_Paths", "LIST,STRING");


            // if "CP_Paths" has zero child nodes
            if (!node_paths.HasChildNodes)
            {
                CPVars.NewListValue("browser", "", node_paths);
                CPVars.Save();
            }

            // commands
            // ------------------------------------
            // path set <name> <path>, sets a path

            // path delete <name>, deletes a path

            // path list, displays a list of paths

            // path <name>, opens a path

            CPCmdBar.RegisterCmd("path", "SimpleCmds", "SimpleCmds.Paths", "CMD_Path");

        }
        public static void CMD_Path(string txt, string[] args, LoadedAssembly assembly)
        {
            if(args.Length < 2) { return; }

            string secondParam = args[1];
            // path set <name> <path>
            if(secondParam == "set" && args.Length > 3)
            {
                string pathName = args[2];
                string path = args[3];

                int i = 0;
                foreach(string _str in args)
                {
                    if(i > 3)
                    {
                        path += " " + _str;
                    }
                    i++;
                }

              

                // check for a path with this name and update it
                if (node_paths.HasChildNodes)
                {
                    string xpath = string.Format("value[@name='{0}']", pathName); 

                    // update path and save
                    XmlNode valueNode = node_paths.SelectSingleNode(xpath);

                    if(valueNode != null)
                    {
                        valueNode.InnerText = path;
                        CPVars.Save();

                        vars.log(string.Format(txt_path_set_replaced, pathName));
                        return;
                    }
                }

                // create a path
                CPVars.NewListValue(pathName, path, node_paths);
                CPVars.Save();

                vars.log(string.Format(txt_path_created, pathName));

            } else if (secondParam == "delete" && args.Length > 2)
            {
                // path delete <name>
               


                if (node_paths.HasChildNodes)
                {
                    for (int i = 2; i < args.Length; i++)
                    {
                        string pathName = args[i];

                        // get node
                        string xpath = string.Format("value[@name='{0}']", pathName);
                        XmlNode valueNode = node_paths.SelectSingleNode(xpath);

                        // delete path
                        if (valueNode != null)
                        {
                            node_paths.RemoveChild(valueNode);
                            
                            vars.log(string.Format(txt_path_deleted, pathName));
                        }
                    }
                    CPVars.Save();
                }

            } else if(secondParam == "list")
            {
                // path list
                vars.log("-------------------------------------");
                vars.log("");

                foreach (XmlNode node in node_paths)
                {
                    string name = node.Attributes[0].Value;
                    string path = node.InnerText;
                    if(path == "") { path = "empty"; }
                    vars.log(string.Format(txt_path_list, name, path));
                }
            } else if(args.Length > 1)
            {
                // path <path_name>

                string path = args[1];
                string xpath = string.Format("value[@name='{0}']", args[1]);
                XmlNode valueNode = node_paths.SelectSingleNode(xpath);

                if(valueNode != null)
                {
                    OpenPath(valueNode.InnerText);
                }
            }

        }

        public static void OpenPath(string path)
        {
            if(path == "") { return; }  

            if (File.Exists(path))
            {
                Process.Start(path);
                path_opened = path;
            } else if (Directory.Exists(path))
            {
                Process.Start(path);
                path_opened = path;
            } else if(Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
            {
                XmlNode browserNode = node_paths.SelectSingleNode("value[@name='browser']");
                if(browserNode != null)
                {
                    string f_browser = browserNode.InnerText;
                    if (File.Exists(f_browser))
                    {
                        Process.Start(f_browser, path);
                    }
                    else
                    {
                        vars.log(txt_browser_path_not_set);
                    }
                    
                }
                else
                {
                    vars.log(txt_browser_node_not_found);
                }
                path_opened = path;
            }

        }
    }
}
