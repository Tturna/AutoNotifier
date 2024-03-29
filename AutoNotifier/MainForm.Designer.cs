﻿
namespace AutoNotifier
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.bt_addEvent = new System.Windows.Forms.Button();
            this.bt_clearevents = new System.Windows.Forms.Button();
            this.bt_quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AutoNotifier";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // bt_addEvent
            // 
            this.bt_addEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_addEvent.Location = new System.Drawing.Point(13, 13);
            this.bt_addEvent.Name = "bt_addEvent";
            this.bt_addEvent.Size = new System.Drawing.Size(75, 23);
            this.bt_addEvent.TabIndex = 0;
            this.bt_addEvent.Text = "Add Event";
            this.bt_addEvent.UseVisualStyleBackColor = true;
            this.bt_addEvent.Click += new System.EventHandler(this.bt_addEvent_Click);
            // 
            // bt_clearevents
            // 
            this.bt_clearevents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_clearevents.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_clearevents.Location = new System.Drawing.Point(12, 117);
            this.bt_clearevents.Name = "bt_clearevents";
            this.bt_clearevents.Size = new System.Drawing.Size(95, 23);
            this.bt_clearevents.TabIndex = 1;
            this.bt_clearevents.Text = "Clear Events";
            this.bt_clearevents.UseVisualStyleBackColor = true;
            this.bt_clearevents.Click += new System.EventHandler(this.bt_clearevents_Click);
            // 
            // bt_quit
            // 
            this.bt_quit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_quit.Location = new System.Drawing.Point(13, 186);
            this.bt_quit.Name = "bt_quit";
            this.bt_quit.Size = new System.Drawing.Size(75, 23);
            this.bt_quit.TabIndex = 2;
            this.bt_quit.Text = "Quit";
            this.bt_quit.UseVisualStyleBackColor = true;
            this.bt_quit.Click += new System.EventHandler(this.bt_quit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.bt_quit);
            this.Controls.Add(this.bt_clearevents);
            this.Controls.Add(this.bt_addEvent);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button bt_addEvent;
        private System.Windows.Forms.Button bt_clearevents;
        private System.Windows.Forms.Button bt_quit;
    }
}

