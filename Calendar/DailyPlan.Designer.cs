
namespace Calendar
{
    partial class DailyPlan
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNextDate = new System.Windows.Forms.Button();
            this.btnPreviousDate = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panelJobs = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripAddJob = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripToday = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labelStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panelJobs);
            this.panel1.Location = new System.Drawing.Point(9, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 488);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNextDate);
            this.panel3.Controls.Add(this.btnPreviousDate);
            this.panel3.Controls.Add(this.dateTimePicker);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(867, 38);
            this.panel3.TabIndex = 1;
            // 
            // btnNextDate
            // 
            this.btnNextDate.Location = new System.Drawing.Point(798, 2);
            this.btnNextDate.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.Size = new System.Drawing.Size(67, 26);
            this.btnNextDate.TabIndex = 2;
            this.btnNextDate.Text = "Hôm sau";
            this.btnNextDate.UseVisualStyleBackColor = true;
            this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
            // 
            // btnPreviousDate
            // 
            this.btnPreviousDate.Location = new System.Drawing.Point(2, 2);
            this.btnPreviousDate.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousDate.Name = "btnPreviousDate";
            this.btnPreviousDate.Size = new System.Drawing.Size(67, 26);
            this.btnPreviousDate.TabIndex = 1;
            this.btnPreviousDate.Text = "Hôm trước";
            this.btnPreviousDate.UseVisualStyleBackColor = true;
            this.btnPreviousDate.Click += new System.EventHandler(this.btnPreviousDate_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(342, 3);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(204, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // panelJobs
            // 
            this.panelJobs.Location = new System.Drawing.Point(2, 46);
            this.panelJobs.Margin = new System.Windows.Forms.Padding(2);
            this.panelJobs.Name = "panelJobs";
            this.panelJobs.Size = new System.Drawing.Size(867, 440);
            this.panelJobs.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddJob,
            this.toolStripToday,
            this.toolStripSave});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(891, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripAddJob
            // 
            this.toolStripAddJob.Name = "toolStripAddJob";
            this.toolStripAddJob.Size = new System.Drawing.Size(73, 20);
            this.toolStripAddJob.Text = "Thêm việc";
            this.toolStripAddJob.Click += new System.EventHandler(this.toolStripAddJob_Click);
            // 
            // toolStripToday
            // 
            this.toolStripToday.Name = "toolStripToday";
            this.toolStripToday.Size = new System.Drawing.Size(68, 20);
            this.toolStripToday.Text = "Hôm nay";
            this.toolStripToday.Click += new System.EventHandler(this.toolStripToday_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.ShortcutKeyDisplayString = "";
            this.toolStripSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripSave.Size = new System.Drawing.Size(54, 20);
            this.toolStripSave.Text = "Lưu lại";
            this.toolStripSave.Click += new System.EventHandler(this.toolStripSave_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatusBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 515);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(891, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // labelStatusBar
            // 
            this.labelStatusBar.Name = "labelStatusBar";
            this.labelStatusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // DailyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 537);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DailyPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kế hoạch trong ngày";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyPlan_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelJobs;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddJob;
        private System.Windows.Forms.ToolStripMenuItem toolStripToday;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.Button btnPreviousDate;
        private System.Windows.Forms.ToolStripMenuItem toolStripSave;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labelStatusBar;
    }
}