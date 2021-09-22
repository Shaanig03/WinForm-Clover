namespace CPLib
{
    partial class ui_cmdbar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbox_cmd = new System.Windows.Forms.TextBox();
            this.txtbox_log = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtbox_cmd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 51);
            this.panel1.TabIndex = 1;
            // 
            // txtbox_cmd
            // 
            this.txtbox_cmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbox_cmd.BackColor = System.Drawing.Color.White;
            this.txtbox_cmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_cmd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtbox_cmd.Location = new System.Drawing.Point(0, 7);
            this.txtbox_cmd.Multiline = true;
            this.txtbox_cmd.Name = "txtbox_cmd";
            this.txtbox_cmd.Size = new System.Drawing.Size(800, 36);
            this.txtbox_cmd.TabIndex = 2;
            this.txtbox_cmd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbox_log
            // 
            this.txtbox_log.BackColor = System.Drawing.Color.White;
            this.txtbox_log.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtbox_log.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtbox_log.Location = new System.Drawing.Point(0, 0);
            this.txtbox_log.Multiline = true;
            this.txtbox_log.Name = "txtbox_log";
            this.txtbox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbox_log.Size = new System.Drawing.Size(592, 399);
            this.txtbox_log.TabIndex = 2;
            this.txtbox_log.Text = "[log]: blah blah";
            // 
            // ui_cmdbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtbox_log);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ui_cmdbar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ui_cmdbar";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ui_cmdbar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtbox_cmd;
        private System.Windows.Forms.TextBox txtbox_log;
    }
}