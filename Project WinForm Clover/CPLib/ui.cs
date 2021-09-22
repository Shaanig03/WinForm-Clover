using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using CompAssistLib;
using System.Xml;   
namespace CPLib
{
    public partial class ui : Form
    {
        public TabControl tabCtrl;
        public ui()
        {
            InitializeComponent();
            if (vars.hidden)
            {
                this.Hide();
            }
        }

        
        // work on message box and alarm sound, and alarm picture
        private void Form1_Load(object sender, EventArgs e)
        {
            // change this (if your having issues with the keys of a different software/application)
            KeyManager.keys_id = 351426;

            // prevents same two application from running
            Process proc = Process.GetCurrentProcess();
            string procName = proc.ProcessName;
            string procPath = proc.MainModule.FileName;

            string execPath = Application.ExecutablePath;

            Process[] procs = Process.GetProcessesByName(procName);
            int i = 0;
            foreach(Process _proc in procs)
            {
                if(_proc.ProcessName == procName && _proc.MainModule.FileName == execPath)
                {

                    i++;
                    if (i > 1)
                    {
                        Application.Exit();
                    }
                }
            }
            //

            tabCtrl = tabControl1;

            // alarm

            alarm.txt_alarm = aat_txt_alarm;
            alarm.txt_alarm_desc = aat_txt_desc;
            alarm.cb_sun = aat_cb_sun;
            alarm.cb_mon = aat_cb_mon;
            alarm.cb_tues = aat_cb_tues;
            alarm.cb_wednesday = aat_cb_wed;
            alarm.cb_thursday = aat_cb_thurs;
            alarm.cb_friday = aat_cb_friday;
            alarm.cb_saturday = aat_cb_saturday;
            alarm.cb_repeats = aat_cb_repeats;
            alarm.lb = aat_lb_list;

            alarm.btn_alarmPic = aat_btn_alarmPic;
            alarm.btn_alarmSound = aat_btn_alarmSound;
            alarm.btn_stopSound = aat_btn_stopSound;
            alarm.num_alarmVolume = aat_num_alarmvolume;

            // create commandbar ui
            ui_cmdbar cmdbarDialog = new ui_cmdbar();
            vars.cmdbarUI = cmdbarDialog;
            cmdbarDialog.Show();


            // mods tab
            Mods.lb = mod_lb_mods;
            Mods.txt_modName = mod_txt_name;
            Mods.txt_modDesc = mod_txt_desc;

            // rmsgs

            RMsgs.btn_add = rmsg_btn_add;
            RMsgs.btn_show = rmsg_btn_show;
            RMsgs.btn_remove = rmsg_btn_remove;

            // load vars
            vars.Load(this);

           

            

            // threading ( onLoad hide )
            System.Threading.Thread thread = new System.Threading.Thread(OnLoadHide);
            thread.Start();

            Test();
        }
        void Test()
        {
            vars.log(KeyManager.keys_id.ToString());
        }
        ///////////////////////////////////// hides the application on start
        void OnLoadHide()
        {
            System.Threading.Thread.Sleep(10);
           
            vars.mainUI.Invoke(new HideOnStartDelegate(HideOnStart), vars.hidden, vars.cmdbar_hidden);
        }
        delegate void HideOnStartDelegate(bool hidden, bool cmdbar_hidden);
        void HideOnStart(bool hidden, bool cmdbar_hidden)
        {
            if (hidden) { vars.mainUI.Hide(); }
            if (cmdbar_hidden) { vars.cmdbarUI.Hide(); }
        }
        /////////////////////////////////////

        protected override void WndProc(ref Message m)
        {
            // key ( hide and show )
            if (m.IsKey(vars.key_hideAndShow))
            {
                if (vars.hidden)
                {
                    vars.hidden = false;
                    this.Show();
                }
                else
                {
                    vars.hidden = true;
                    this.Hide();
                }
            }

            // key ( quick note )
            if (m.IsKey(vars.key_openQuickNotes))
            {
                if (File.Exists(vars.quickNote))
                {
                    Process.Start(vars.quickNote);
                }
            }

            // key ( restart application )
            if (m.IsKey(vars.key_restartApp))
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }

            

            // key cmdbar ( hide and show )
            if (m.IsKey(vars.key_hideAndShow_cmdBar))
            {
                if (vars.cmdbarUI != null)
                {
                    if (vars.cmdbar_hidden)
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

            // key cmdbar ( command enter )
            if (m.IsKey(vars.key_cmdEnter))
            {
                if (vars.cmdbarUI != null)
                {
                    // execute cmd
                    string line = vars.cmdbarUI.cmdBox.Text;
                    CPCmdBar.ExecuteCmd(line);
                    vars.cmdbarUI.cmdBox.Text = "";

                    // update log
                    ui_cmdbar.UpdateLog();
                }
            }
            // key cmdbar ( open files path )
            if (m.IsKey(vars.key_openFilesPath))
            {
                Process.Start(vars.p_files);
            }
            base.WndProc(ref m);
        }


        // aat = alarm and timer
        
        // button alarm add
        private void Aat_btn_add_Click(object sender, EventArgs e)
        {
            // message alarm & note
            string msgAlarm = aat_txt_alarm.Text;
            string msgNote = aat_txt_desc.Text;

           
            // add alarm
            if(msgNote != "")
            {
                alarm.AddAlarm(msgAlarm, msgNote);
            }
            else
            {
                // if message note is empty then the put the alarm's name in the message
                string[] lines = msgAlarm.Split();
                if (lines.Length > 0)
                {
                    alarm.AddAlarm(msgAlarm, "");
                }
            }
        }

        // button alarm remove
        private void Aat_btn_remove_Click(object sender, EventArgs e)
        {
            alarm.RemoveSelectedAlarm();
        }   

        private void Mod_btn_modsFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(vars.p_mods))
            {
                Process.Start(vars.p_mods);
            }
            
        }
    }
}
