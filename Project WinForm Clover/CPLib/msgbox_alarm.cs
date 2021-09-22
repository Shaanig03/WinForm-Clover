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

namespace CPLib
{
    public partial class msgbox_alarm : Form
    {
        public msgbox_alarm()
        {
            InitializeComponent();
        }

        private void Msgbox_alarm_Load(object sender, EventArgs e)
        {

        }
        public void MakeChanges(string msg, string title, string f_pic)
        {
            Image img = null;

            
            // if f_pic is a file, load the image from the file
            if (File.Exists(f_pic))
            {
                img = Image.FromFile(f_pic);
            } else if (Directory.Exists(f_pic))
            {
                // if its a directory, get files and select random, and load the image
                List<string> files = Extra.GetFiles(f_pic, alarm.pic_exts);
                if(files.Count > 0)
                {
                    Random ran = new Random();
                    string file = files[ran.Next(files.Count)];

                    Debug.WriteLine(file);
                    img = Image.FromFile(file);
                }
            }

            // set picture
            if(img != null)
            {
                pic.Image = img;
            }
            
            // set message text and title 
            txt_msg.Text = msg;
            this.Text = title;
        }
    }
}
