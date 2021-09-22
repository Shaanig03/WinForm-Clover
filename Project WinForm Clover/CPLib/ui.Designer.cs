namespace CPLib
{
    partial class ui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAlarm = new System.Windows.Forms.TabPage();
            this.rmsg_btn_remove = new System.Windows.Forms.Button();
            this.rmsg_btn_add = new System.Windows.Forms.Button();
            this.rmsg_btn_show = new System.Windows.Forms.Button();
            this.aat_btn_stopSound = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.aat_num_alarmvolume = new System.Windows.Forms.NumericUpDown();
            this.aat_btn_alarmPic = new System.Windows.Forms.Button();
            this.aat_btn_alarmSound = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.aat_grpbox = new System.Windows.Forms.GroupBox();
            this.aat_cb_repeats = new System.Windows.Forms.CheckBox();
            this.aat_cb_wed = new System.Windows.Forms.CheckBox();
            this.aat_cb_saturday = new System.Windows.Forms.CheckBox();
            this.aat_cb_sun = new System.Windows.Forms.CheckBox();
            this.aat_cb_friday = new System.Windows.Forms.CheckBox();
            this.aat_cb_mon = new System.Windows.Forms.CheckBox();
            this.aat_cb_thurs = new System.Windows.Forms.CheckBox();
            this.aat_cb_tues = new System.Windows.Forms.CheckBox();
            this.aat_btn_remove = new System.Windows.Forms.Button();
            this.aat_btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.aat_txt_desc = new System.Windows.Forms.TextBox();
            this.aat_txt_alarm = new System.Windows.Forms.TextBox();
            this.aat_lb_list = new System.Windows.Forms.ListBox();
            this.tabMods = new System.Windows.Forms.TabPage();
            this.mod_btn_modsFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mod_txt_desc = new System.Windows.Forms.TextBox();
            this.mod_txt_name = new System.Windows.Forms.TextBox();
            this.mod_lb_mods = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aat_num_alarmvolume)).BeginInit();
            this.aat_grpbox.SuspendLayout();
            this.tabMods.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAlarm);
            this.tabControl1.Controls.Add(this.tabMods);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 426);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAlarm
            // 
            this.tabAlarm.Controls.Add(this.rmsg_btn_remove);
            this.tabAlarm.Controls.Add(this.rmsg_btn_add);
            this.tabAlarm.Controls.Add(this.rmsg_btn_show);
            this.tabAlarm.Controls.Add(this.aat_btn_stopSound);
            this.tabAlarm.Controls.Add(this.label2);
            this.tabAlarm.Controls.Add(this.aat_num_alarmvolume);
            this.tabAlarm.Controls.Add(this.aat_btn_alarmPic);
            this.tabAlarm.Controls.Add(this.aat_btn_alarmSound);
            this.tabAlarm.Controls.Add(this.label1);
            this.tabAlarm.Controls.Add(this.aat_grpbox);
            this.tabAlarm.Controls.Add(this.aat_btn_remove);
            this.tabAlarm.Controls.Add(this.aat_btn_add);
            this.tabAlarm.Controls.Add(this.label3);
            this.tabAlarm.Controls.Add(this.aat_txt_desc);
            this.tabAlarm.Controls.Add(this.aat_txt_alarm);
            this.tabAlarm.Controls.Add(this.aat_lb_list);
            this.tabAlarm.Location = new System.Drawing.Point(4, 22);
            this.tabAlarm.Name = "tabAlarm";
            this.tabAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlarm.Size = new System.Drawing.Size(792, 400);
            this.tabAlarm.TabIndex = 0;
            this.tabAlarm.Text = "Alarm and Timer ♣";
            this.tabAlarm.UseVisualStyleBackColor = true;
            // 
            // rmsg_btn_remove
            // 
            this.rmsg_btn_remove.BackColor = System.Drawing.Color.White;
            this.rmsg_btn_remove.Location = new System.Drawing.Point(510, 334);
            this.rmsg_btn_remove.Name = "rmsg_btn_remove";
            this.rmsg_btn_remove.Size = new System.Drawing.Size(262, 23);
            this.rmsg_btn_remove.TabIndex = 39;
            this.rmsg_btn_remove.Text = "Remove Picture Note";
            this.rmsg_btn_remove.UseVisualStyleBackColor = false;
            // 
            // rmsg_btn_add
            // 
            this.rmsg_btn_add.BackColor = System.Drawing.Color.White;
            this.rmsg_btn_add.Location = new System.Drawing.Point(510, 305);
            this.rmsg_btn_add.Name = "rmsg_btn_add";
            this.rmsg_btn_add.Size = new System.Drawing.Size(262, 23);
            this.rmsg_btn_add.TabIndex = 38;
            this.rmsg_btn_add.Text = "Add Picture Note";
            this.rmsg_btn_add.UseVisualStyleBackColor = false;
            // 
            // rmsg_btn_show
            // 
            this.rmsg_btn_show.BackColor = System.Drawing.Color.White;
            this.rmsg_btn_show.Location = new System.Drawing.Point(510, 276);
            this.rmsg_btn_show.Name = "rmsg_btn_show";
            this.rmsg_btn_show.Size = new System.Drawing.Size(262, 23);
            this.rmsg_btn_show.TabIndex = 37;
            this.rmsg_btn_show.Text = "Picture Note";
            this.rmsg_btn_show.UseVisualStyleBackColor = false;
            // 
            // aat_btn_stopSound
            // 
            this.aat_btn_stopSound.BackColor = System.Drawing.Color.White;
            this.aat_btn_stopSound.Location = new System.Drawing.Point(558, 48);
            this.aat_btn_stopSound.Name = "aat_btn_stopSound";
            this.aat_btn_stopSound.Size = new System.Drawing.Size(92, 23);
            this.aat_btn_stopSound.TabIndex = 36;
            this.aat_btn_stopSound.Text = "stop sound";
            this.aat_btn_stopSound.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "volume:";
            // 
            // aat_num_alarmvolume
            // 
            this.aat_num_alarmvolume.BackColor = System.Drawing.Color.White;
            this.aat_num_alarmvolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aat_num_alarmvolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aat_num_alarmvolume.Location = new System.Drawing.Point(713, 51);
            this.aat_num_alarmvolume.Name = "aat_num_alarmvolume";
            this.aat_num_alarmvolume.Size = new System.Drawing.Size(59, 20);
            this.aat_num_alarmvolume.TabIndex = 34;
            this.aat_num_alarmvolume.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // aat_btn_alarmPic
            // 
            this.aat_btn_alarmPic.BackColor = System.Drawing.Color.White;
            this.aat_btn_alarmPic.Location = new System.Drawing.Point(460, 48);
            this.aat_btn_alarmPic.Name = "aat_btn_alarmPic";
            this.aat_btn_alarmPic.Size = new System.Drawing.Size(92, 23);
            this.aat_btn_alarmPic.TabIndex = 30;
            this.aat_btn_alarmPic.Text = "alarm picture";
            this.aat_btn_alarmPic.UseVisualStyleBackColor = false;
            // 
            // aat_btn_alarmSound
            // 
            this.aat_btn_alarmSound.BackColor = System.Drawing.Color.White;
            this.aat_btn_alarmSound.Location = new System.Drawing.Point(362, 48);
            this.aat_btn_alarmSound.Name = "aat_btn_alarmSound";
            this.aat_btn_alarmSound.Size = new System.Drawing.Size(92, 23);
            this.aat_btn_alarmSound.TabIndex = 29;
            this.aat_btn_alarmSound.Text = "alarm sound";
            this.aat_btn_alarmSound.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "alarm:";
            // 
            // aat_grpbox
            // 
            this.aat_grpbox.Controls.Add(this.aat_cb_repeats);
            this.aat_grpbox.Controls.Add(this.aat_cb_wed);
            this.aat_grpbox.Controls.Add(this.aat_cb_saturday);
            this.aat_grpbox.Controls.Add(this.aat_cb_sun);
            this.aat_grpbox.Controls.Add(this.aat_cb_friday);
            this.aat_grpbox.Controls.Add(this.aat_cb_mon);
            this.aat_grpbox.Controls.Add(this.aat_cb_thurs);
            this.aat_grpbox.Controls.Add(this.aat_cb_tues);
            this.aat_grpbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aat_grpbox.Location = new System.Drawing.Point(292, 181);
            this.aat_grpbox.Name = "aat_grpbox";
            this.aat_grpbox.Size = new System.Drawing.Size(212, 196);
            this.aat_grpbox.TabIndex = 23;
            this.aat_grpbox.TabStop = false;
            // 
            // aat_cb_repeats
            // 
            this.aat_cb_repeats.AutoSize = true;
            this.aat_cb_repeats.Checked = true;
            this.aat_cb_repeats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_repeats.Location = new System.Drawing.Point(126, 26);
            this.aat_cb_repeats.Name = "aat_cb_repeats";
            this.aat_cb_repeats.Size = new System.Drawing.Size(66, 17);
            this.aat_cb_repeats.TabIndex = 23;
            this.aat_cb_repeats.Text = "Repeats";
            this.aat_cb_repeats.UseVisualStyleBackColor = true;
            // 
            // aat_cb_wed
            // 
            this.aat_cb_wed.AutoSize = true;
            this.aat_cb_wed.Checked = true;
            this.aat_cb_wed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_wed.Location = new System.Drawing.Point(18, 95);
            this.aat_cb_wed.Name = "aat_cb_wed";
            this.aat_cb_wed.Size = new System.Drawing.Size(83, 17);
            this.aat_cb_wed.TabIndex = 19;
            this.aat_cb_wed.Text = "Wednesday";
            this.aat_cb_wed.UseVisualStyleBackColor = true;
            // 
            // aat_cb_saturday
            // 
            this.aat_cb_saturday.AutoSize = true;
            this.aat_cb_saturday.Checked = true;
            this.aat_cb_saturday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_saturday.Location = new System.Drawing.Point(17, 164);
            this.aat_cb_saturday.Name = "aat_cb_saturday";
            this.aat_cb_saturday.Size = new System.Drawing.Size(68, 17);
            this.aat_cb_saturday.TabIndex = 22;
            this.aat_cb_saturday.Text = "Saturday";
            this.aat_cb_saturday.UseVisualStyleBackColor = true;
            // 
            // aat_cb_sun
            // 
            this.aat_cb_sun.AutoSize = true;
            this.aat_cb_sun.Checked = true;
            this.aat_cb_sun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_sun.Location = new System.Drawing.Point(18, 26);
            this.aat_cb_sun.Name = "aat_cb_sun";
            this.aat_cb_sun.Size = new System.Drawing.Size(62, 17);
            this.aat_cb_sun.TabIndex = 16;
            this.aat_cb_sun.Text = "Sunday";
            this.aat_cb_sun.UseVisualStyleBackColor = true;
            // 
            // aat_cb_friday
            // 
            this.aat_cb_friday.AutoSize = true;
            this.aat_cb_friday.Checked = true;
            this.aat_cb_friday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_friday.Location = new System.Drawing.Point(18, 141);
            this.aat_cb_friday.Name = "aat_cb_friday";
            this.aat_cb_friday.Size = new System.Drawing.Size(54, 17);
            this.aat_cb_friday.TabIndex = 21;
            this.aat_cb_friday.Text = "Friday";
            this.aat_cb_friday.UseVisualStyleBackColor = true;
            // 
            // aat_cb_mon
            // 
            this.aat_cb_mon.AutoSize = true;
            this.aat_cb_mon.Checked = true;
            this.aat_cb_mon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_mon.Location = new System.Drawing.Point(18, 49);
            this.aat_cb_mon.Name = "aat_cb_mon";
            this.aat_cb_mon.Size = new System.Drawing.Size(64, 17);
            this.aat_cb_mon.TabIndex = 17;
            this.aat_cb_mon.Text = "Monday";
            this.aat_cb_mon.UseVisualStyleBackColor = true;
            // 
            // aat_cb_thurs
            // 
            this.aat_cb_thurs.AutoSize = true;
            this.aat_cb_thurs.Checked = true;
            this.aat_cb_thurs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_thurs.Location = new System.Drawing.Point(18, 118);
            this.aat_cb_thurs.Name = "aat_cb_thurs";
            this.aat_cb_thurs.Size = new System.Drawing.Size(70, 17);
            this.aat_cb_thurs.TabIndex = 20;
            this.aat_cb_thurs.Text = "Thursday";
            this.aat_cb_thurs.UseVisualStyleBackColor = true;
            // 
            // aat_cb_tues
            // 
            this.aat_cb_tues.AutoSize = true;
            this.aat_cb_tues.Checked = true;
            this.aat_cb_tues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aat_cb_tues.Location = new System.Drawing.Point(18, 72);
            this.aat_cb_tues.Name = "aat_cb_tues";
            this.aat_cb_tues.Size = new System.Drawing.Size(67, 17);
            this.aat_cb_tues.TabIndex = 18;
            this.aat_cb_tues.Text = "Tuesday";
            this.aat_cb_tues.UseVisualStyleBackColor = true;
            // 
            // aat_btn_remove
            // 
            this.aat_btn_remove.BackColor = System.Drawing.Color.White;
            this.aat_btn_remove.Location = new System.Drawing.Point(327, 48);
            this.aat_btn_remove.Name = "aat_btn_remove";
            this.aat_btn_remove.Size = new System.Drawing.Size(29, 23);
            this.aat_btn_remove.TabIndex = 15;
            this.aat_btn_remove.Text = "-";
            this.aat_btn_remove.UseVisualStyleBackColor = false;
            this.aat_btn_remove.Click += new System.EventHandler(this.Aat_btn_remove_Click);
            // 
            // aat_btn_add
            // 
            this.aat_btn_add.BackColor = System.Drawing.Color.White;
            this.aat_btn_add.Location = new System.Drawing.Point(292, 48);
            this.aat_btn_add.Name = "aat_btn_add";
            this.aat_btn_add.Size = new System.Drawing.Size(29, 23);
            this.aat_btn_add.TabIndex = 14;
            this.aat_btn_add.Text = "+";
            this.aat_btn_add.UseVisualStyleBackColor = false;
            this.aat_btn_add.Click += new System.EventHandler(this.Aat_btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "alarms.xml";
            // 
            // aat_txt_desc
            // 
            this.aat_txt_desc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aat_txt_desc.Location = new System.Drawing.Point(298, 80);
            this.aat_txt_desc.Multiline = true;
            this.aat_txt_desc.Name = "aat_txt_desc";
            this.aat_txt_desc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.aat_txt_desc.Size = new System.Drawing.Size(480, 95);
            this.aat_txt_desc.TabIndex = 2;
            // 
            // aat_txt_alarm
            // 
            this.aat_txt_alarm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aat_txt_alarm.Location = new System.Drawing.Point(292, 22);
            this.aat_txt_alarm.Name = "aat_txt_alarm";
            this.aat_txt_alarm.Size = new System.Drawing.Size(480, 20);
            this.aat_txt_alarm.TabIndex = 1;
            // 
            // aat_lb_list
            // 
            this.aat_lb_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aat_lb_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aat_lb_list.FormattingEnabled = true;
            this.aat_lb_list.HorizontalScrollbar = true;
            this.aat_lb_list.ItemHeight = 15;
            this.aat_lb_list.Location = new System.Drawing.Point(22, 22);
            this.aat_lb_list.Name = "aat_lb_list";
            this.aat_lb_list.Size = new System.Drawing.Size(236, 349);
            this.aat_lb_list.TabIndex = 0;
            // 
            // tabMods
            // 
            this.tabMods.Controls.Add(this.mod_btn_modsFolder);
            this.tabMods.Controls.Add(this.label6);
            this.tabMods.Controls.Add(this.label5);
            this.tabMods.Controls.Add(this.mod_txt_desc);
            this.tabMods.Controls.Add(this.mod_txt_name);
            this.tabMods.Controls.Add(this.mod_lb_mods);
            this.tabMods.Location = new System.Drawing.Point(4, 22);
            this.tabMods.Name = "tabMods";
            this.tabMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabMods.Size = new System.Drawing.Size(792, 400);
            this.tabMods.TabIndex = 1;
            this.tabMods.Text = "Mods";
            this.tabMods.UseVisualStyleBackColor = true;
            // 
            // mod_btn_modsFolder
            // 
            this.mod_btn_modsFolder.BackColor = System.Drawing.Color.White;
            this.mod_btn_modsFolder.Location = new System.Drawing.Point(22, 7);
            this.mod_btn_modsFolder.Name = "mod_btn_modsFolder";
            this.mod_btn_modsFolder.Size = new System.Drawing.Size(236, 23);
            this.mod_btn_modsFolder.TabIndex = 9;
            this.mod_btn_modsFolder.Text = "mods";
            this.mod_btn_modsFolder.UseVisualStyleBackColor = false;
            this.mod_btn_modsFolder.Click += new System.EventHandler(this.Mod_btn_modsFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "mod info:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "mod name:";
            // 
            // mod_txt_desc
            // 
            this.mod_txt_desc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mod_txt_desc.Location = new System.Drawing.Point(283, 87);
            this.mod_txt_desc.Multiline = true;
            this.mod_txt_desc.Name = "mod_txt_desc";
            this.mod_txt_desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mod_txt_desc.Size = new System.Drawing.Size(478, 295);
            this.mod_txt_desc.TabIndex = 5;
            // 
            // mod_txt_name
            // 
            this.mod_txt_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mod_txt_name.Location = new System.Drawing.Point(283, 33);
            this.mod_txt_name.Name = "mod_txt_name";
            this.mod_txt_name.Size = new System.Drawing.Size(478, 20);
            this.mod_txt_name.TabIndex = 2;
            // 
            // mod_lb_mods
            // 
            this.mod_lb_mods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod_lb_mods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mod_lb_mods.FormattingEnabled = true;
            this.mod_lb_mods.ItemHeight = 15;
            this.mod_lb_mods.Location = new System.Drawing.Point(22, 33);
            this.mod_lb_mods.Name = "mod_lb_mods";
            this.mod_lb_mods.Size = new System.Drawing.Size(236, 349);
            this.mod_lb_mods.TabIndex = 1;
            // 
            // ui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "ui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "♣";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAlarm.ResumeLayout(false);
            this.tabAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aat_num_alarmvolume)).EndInit();
            this.aat_grpbox.ResumeLayout(false);
            this.aat_grpbox.PerformLayout();
            this.tabMods.ResumeLayout(false);
            this.tabMods.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAlarm;
        private System.Windows.Forms.TabPage tabMods;
        private System.Windows.Forms.ListBox aat_lb_list;
        private System.Windows.Forms.TextBox aat_txt_desc;
        private System.Windows.Forms.TextBox aat_txt_alarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button aat_btn_remove;
        private System.Windows.Forms.Button aat_btn_add;
        private System.Windows.Forms.GroupBox aat_grpbox;
        private System.Windows.Forms.CheckBox aat_cb_wed;
        private System.Windows.Forms.CheckBox aat_cb_saturday;
        private System.Windows.Forms.CheckBox aat_cb_sun;
        private System.Windows.Forms.CheckBox aat_cb_friday;
        private System.Windows.Forms.CheckBox aat_cb_mon;
        private System.Windows.Forms.CheckBox aat_cb_thurs;
        private System.Windows.Forms.CheckBox aat_cb_tues;
        private System.Windows.Forms.CheckBox aat_cb_repeats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aat_btn_alarmSound;
        private System.Windows.Forms.Button aat_btn_alarmPic;
        private System.Windows.Forms.NumericUpDown aat_num_alarmvolume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button aat_btn_stopSound;
        private System.Windows.Forms.TextBox mod_txt_desc;
        private System.Windows.Forms.TextBox mod_txt_name;
        private System.Windows.Forms.ListBox mod_lb_mods;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button mod_btn_modsFolder;
        private System.Windows.Forms.Button rmsg_btn_add;
        private System.Windows.Forms.Button rmsg_btn_show;
        private System.Windows.Forms.Button rmsg_btn_remove;
    }
}

