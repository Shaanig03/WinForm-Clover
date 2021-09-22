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


namespace CPLib
{
    public partial class ui_cmdbar : Form
    {
        public TextBox cmdBox;
        public TextBox logBox;
        public ui_cmdbar()
        {
            InitializeComponent();
        }

        private void Ui_cmdbar_Load(object sender, EventArgs e)
        {
            cmdBox = txtbox_cmd;
            logBox = txtbox_log;
        }

        public static void UpdateLog()
        {
            if(vars.cmdbarUI != null)
            {
                vars.cmdbarUI.logBox.Text = "";
                vars.cmdbarUI.logBox.AppendText(vars.str_log);
            }
            
        }

        protected override void WndProc(ref Message m)
        {
            
            base.WndProc(ref m);
        }
    }
}
