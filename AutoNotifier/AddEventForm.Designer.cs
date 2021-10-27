
namespace AutoNotifier
{
    partial class AddEventForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEventForm));
            this.lb_title = new System.Windows.Forms.Label();
            this.tb_header = new System.Windows.Forms.TextBox();
            this.tb_bottom = new System.Windows.Forms.TextBox();
            this.lb_header = new System.Windows.Forms.Label();
            this.lb_bottom = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.bt_apply = new System.Windows.Forms.Button();
            this.clb_eventHours = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_title.Location = new System.Drawing.Point(12, 9);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(98, 13);
            this.lb_title.TabIndex = 0;
            this.lb_title.Text = "Add Daily Event";
            // 
            // tb_header
            // 
            this.tb_header.Location = new System.Drawing.Point(108, 46);
            this.tb_header.Name = "tb_header";
            this.tb_header.Size = new System.Drawing.Size(100, 20);
            this.tb_header.TabIndex = 1;
            // 
            // tb_bottom
            // 
            this.tb_bottom.Location = new System.Drawing.Point(108, 72);
            this.tb_bottom.Name = "tb_bottom";
            this.tb_bottom.Size = new System.Drawing.Size(100, 20);
            this.tb_bottom.TabIndex = 2;
            // 
            // lb_header
            // 
            this.lb_header.AutoSize = true;
            this.lb_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_header.Location = new System.Drawing.Point(6, 49);
            this.lb_header.Name = "lb_header";
            this.lb_header.Size = new System.Drawing.Size(66, 13);
            this.lb_header.TabIndex = 3;
            this.lb_header.Text = "Header Text";
            // 
            // lb_bottom
            // 
            this.lb_bottom.AutoSize = true;
            this.lb_bottom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_bottom.Location = new System.Drawing.Point(6, 75);
            this.lb_bottom.Name = "lb_bottom";
            this.lb_bottom.Size = new System.Drawing.Size(64, 13);
            this.lb_bottom.TabIndex = 4;
            this.lb_bottom.Text = "Bottom Text";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_time.Location = new System.Drawing.Point(6, 115);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(66, 13);
            this.lb_time.TabIndex = 6;
            this.lb_time.Text = "Event Hours";
            // 
            // bt_apply
            // 
            this.bt_apply.Location = new System.Drawing.Point(12, 226);
            this.bt_apply.Name = "bt_apply";
            this.bt_apply.Size = new System.Drawing.Size(75, 23);
            this.bt_apply.TabIndex = 7;
            this.bt_apply.Text = "Apply";
            this.bt_apply.UseVisualStyleBackColor = true;
            this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
            // 
            // clb_eventHours
            // 
            this.clb_eventHours.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.clb_eventHours.CheckOnClick = true;
            this.clb_eventHours.FormattingEnabled = true;
            this.clb_eventHours.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.clb_eventHours.Location = new System.Drawing.Point(115, 115);
            this.clb_eventHours.Name = "clb_eventHours";
            this.clb_eventHours.ScrollAlwaysVisible = true;
            this.clb_eventHours.Size = new System.Drawing.Size(93, 94);
            this.clb_eventHours.TabIndex = 8;
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(220, 261);
            this.Controls.Add(this.clb_eventHours);
            this.Controls.Add(this.bt_apply);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.lb_bottom);
            this.Controls.Add(this.lb_header);
            this.Controls.Add(this.tb_bottom);
            this.Controls.Add(this.tb_header);
            this.Controls.Add(this.lb_title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEventForm";
            this.Text = "Add Daily Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.TextBox tb_header;
        private System.Windows.Forms.TextBox tb_bottom;
        private System.Windows.Forms.Label lb_header;
        private System.Windows.Forms.Label lb_bottom;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Button bt_apply;
        private System.Windows.Forms.CheckedListBox clb_eventHours;
    }
}