using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using CPLib;

namespace SimpleCmds
{
    public static class Main
    {
        public static string txt_ShowHelp_CmdNotFound = "there is no cmd named <{0}>";

        public static void OnLoad()
        {
            Paths.Load();

            // commands
            CPCmdBar.RegisterCmd("help", "SimpleCmds", "SimpleCmds.Main", "CMD_Help");
            CPCmdBar.RegisterCmd("log", "SimpleCmds", "SimpleCmds.Main", "CMD_Log");
            CPCmdBar.RegisterCmd("say", "SimpleCmds", "SimpleCmds.Main", "CMD_Say");
            CPCmdBar.RegisterCmd("kill", "SimpleCmds", "SimpleCmds.Main", "CMD_Kill");
        }

        public static void CMD_Kill(string txt, string[] args, LoadedAssembly assembly)
        {
            if(args.Length < 1) { return; }

            int i = 0;
            foreach(string _arg in args)
            {
                if(i != 0)
                {
                    Process[] procs = Process.GetProcessesByName(_arg);
                    foreach(Process proc in procs)
                    {
                        proc.Kill();
                        vars.log("killed " + proc.ProcessName);
                    }
                }
                i++;
            }
        }

        public static void CMD_Help(string txt, string[] args, LoadedAssembly assembly)
        {
            // help
            if (args.Length == 1)
            {
                vars.log("displaying commands:");
                vars.log("");
                vars.log("---------------------------------------------------");
                foreach (KeyValuePair<string, CPCmdLine> _keyvalue in CPCmdBar.Cmds)
                {
                    ShowCmdInfo(_keyvalue.Key);
                }

                return;
            }

            // help <command_name> <command_name> etc...
            int i = 0;
            foreach (string _str in args)
            {
                if (i != 0) { ShowCmdInfo(_str); }

                i++;
            }
        }

        public static void ShowCmdInfo(string line)
        {
            CPCmdLine cmdLine;

            if (!CPCmdBar.Cmds.TryGetValue(line, out cmdLine))
            {
                vars.log(string.Format(txt_ShowHelp_CmdNotFound, line));
                return;
            }
            string info = cmdLine.info;
            if (info != "" != string.IsNullOrWhiteSpace(info)) { vars.log(cmdLine.info); vars.log("---------------------------------------------------"); }
            
        }


        public static void CMD_Log(string txt, string[] args, LoadedAssembly assembly)
        {
            if(args.Length < 2) { return; }

            string _param = args[1];
            if(_param == "clear")
            {
                vars.clearLog();
            } else if(_param == "copy")
            {
                Clipboard.SetText(vars.str_log);
                vars.log("log copied to clipboard");
            }

        }
        public static void CMD_Say(string txt, string[] args, LoadedAssembly assembly)
        {
            if(args.Length < 2) { return; }

            string str = txt.Substring(3, txt.Length-3);
            vars.log(str);
        }
    }
}
