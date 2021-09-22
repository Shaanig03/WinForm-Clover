using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using CompAssistLib;
using System.Xml;

namespace CPLib
{
    
    // control panel command bar
    public static class CPCmdBar
    {
        public static Dictionary<string, CPCmdLine> Cmds = new Dictionary<string, CPCmdLine>();


        // registers a command
        public static void RegisterCmd(string line, string assemblyName, string assemblyClass, string assemblyMethod)
        {
            // get assembly
            LoadedAssembly v_assembly;
            
            if(!vars.assemblyList.TryGetValue(assemblyName, out v_assembly)) { vars.log(string.Format("RegisterCmd(): cmd [{0}], assembly is null", line), true, true); return; }
            Assembly a_assembly = v_assembly.assembly;

            // get assembly class
            Type type = a_assembly.GetType(assemblyClass);
            if(type == null) { vars.log(string.Format("RegisterCmd(): cmd [{0}], assembly class is null", line), true, true); return; }

            // get method
            MethodInfo method = type.GetMethod(assemblyMethod);
            if (method == null) { vars.log(string.Format("RegisterCmd(): cmd [{0}], method is null", line), true, true); return; }

            // create a new cmd
            CPCmdLine cp_cmdline = new CPCmdLine();

            cp_cmdline.line = line;
            cp_cmdline.assemblyName = assemblyName;
            cp_cmdline.assemblyClass = assemblyClass;
            cp_cmdline.assemblyMethod = assemblyMethod;

            cp_cmdline.method = method;


            // get cmd's assembly and mod
            foreach(KeyValuePair<string, LoadedAssembly> keyValue in vars.assemblyList)
            {
                LoadedAssembly cp_assembly = keyValue.Value;

                if (cp_assembly.assembly == a_assembly)
                {
                    // assembly and mod
                    Mod mod = cp_assembly.mod;
                    cp_cmdline.assembly = cp_assembly;
                    cp_cmdline.mod = mod;


                    // cmd info
                    string p_mod = cp_cmdline.mod.p_mod + @"\" + "cmd_infos";
                    string f_mod = p_mod + @"\" + line + ".txt";

                    if (Directory.Exists(p_mod) && File.Exists(f_mod))
                    {
                        cp_cmdline.info = File.ReadAllText(f_mod);
                    }
                }
            }


            // register command
            Cmds.Add(line, cp_cmdline);

            vars.log(string.Format("command [{0}] registered", line));
        }

        // executes a command
        public static void ExecuteCmd(string txt)
        {
            string[] args = txt.Split(' ');
            if(args.Length == 0) { return; }

            string line = args[0];

            CPCmdLine cmdline;
            if(!Cmds.TryGetValue(line, out cmdline)) { return; }

            cmdline.method.Invoke(null, new object[] { txt, args, cmdline.assembly });
        }

        public static void Hide(bool hidden)
        {
            if (!hidden)
            {
                vars.cmdbar_hidden = false;
                vars.cmdbarUI.Show();
                vars.cmdbarUI.Activate();

                // changes the cmd enter key modifier to 0 when cmdbar is opened
                KeyManager.definedKeys[4].modifier = 0;
                KeyManager.UpdateKey(vars.mainUI.Handle, 4);
            }
            else
            {
                vars.cmdbar_hidden = true;
                vars.cmdbarUI.Hide();

                // changes the cmd enter key modifier to 1 when cmdbar is opened
                KeyManager.definedKeys[4].modifier = 1;
                KeyManager.UpdateKey(vars.mainUI.Handle, 4);
            }
        }

        
    }

    // control panel command class
    public class CPCmdLine
    {
        public string line;

        public string assemblyName;
        public string assemblyClass;
        public string assemblyMethod;

        public LoadedAssembly assembly;
        public Mod mod;
        public MethodInfo method;

        public string info;
    }
    

   
}
