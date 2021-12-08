
namespace Calendar
{
    partial class JobControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSaved = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxJobDescription = new System.Windows.Forms.TextBox();
            this.checkBoxDone = new System.Windows.Forms.CheckBox();
            this.cbxFromHour = new System.Windows.Forms.ComboBox();
            this.cbxToMinute = new System.Windows.Forms.ComboBox();
            this.cbxFromMinute = new System.Windows.Forms.ComboBox();
            this.cbxToHour = new System.Windows.Forms.ComboBox();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.textBoxJobDescription);
            this.panelMain.Controls.Add(this.checkBoxDone);
            this.panelMain.Location = new System.Drawing.Point(2, 2);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(842, 41);
            this.panelMain.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxToHour);
            this.panel2.Controls.Add(this.cbxFromMinute);
            this.panel2.Controls.Add(this.cbxToMinute);
            this.panel2.Controls.Add(this.cbxFromHour);
            this.panel2.Controls.Add(this.labelSaved);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.comboBoxStatus);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(404, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 36);
            this.panel2.TabIndex = 2;
            // 
            // labelSaved
            // 
            this.labelSaved.AutoSize = true;
            this.labelSaved.BackColor = System.Drawing.Color.White;
            this.labelSaved.ForeColor = System.Drawing.Color.Red;
            this.labelSaved.Location = new System.Drawing.Point(332, 10);
            this.labelSaved.Name = "labelSaved";
            this.labelSaved.Size = new System.Drawing.Size(49, 13);
            this.labelSaved.TabIndex = 9;
            this.labelSaved.Text = "Chưa lưu";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(386, 3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(45, 26);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(242, 6);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(85, 21);
            this.comboBoxStatus.TabIndex = 7;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đến";
            // 
            // textBoxJobDescription
            // 
            this.textBoxJobDescription.Location = new System.Drawing.Point(26, 10);
            this.textBoxJobDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxJobDescription.Name = "textBoxJobDescription";
            this.textBoxJobDescription.Size = new System.Drawing.Size(374, 20);
            this.textBoxJobDescription.TabIndex = 1;
            this.textBoxJobDescription.TextChanged += new System.EventHandler(this.textBoxJobDescription_TextChanged);
            // 
            // checkBoxDone
            // 
            this.checkBoxDone.AutoSize = true;
            this.checkBoxDone.Location = new System.Drawing.Point(7, 12);
            this.checkBoxDone.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxDone.Name = "checkBoxDone";
            this.checkBoxDone.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDone.TabIndex = 0;
            this.checkBoxDone.UseVisualStyleBackColor = true;
            this.checkBoxDone.CheckedChanged += new System.EventHandler(this.checkBoxDone_CheckedChanged);
            // 
            // cbxFromHour
            // 
            this.cbxFromHour.FormattingEnabled = true;
            this.cbxFromHour.Location = new System.Drawing.Point(24, 6);
            this.cbxFromHour.Name = "cbxFromHour";
            this.cbxFromHour.Size = new System.Drawing.Size(40, 21);
            this.cbxFromHour.TabIndex = 10;
            this.cbxFromHour.SelectedIndexChanged += new System.EventHandler(this.cbxFromHour_SelectedIndexChanged);
            // 
            // cbxToMinute
            // 
            this.cbxToMinute.FormattingEnabled = true;
            this.cbxToMinute.Location = new System.Drawing.Point(196, 6);
            this.cbxToMinute.Name = "cbxToMinute";
            this.cbxToMinute.Size = new System.Drawing.Size(40, 21);
            this.cbxToMinute.TabIndex = 11;
            this.cbxToMinute.SelectedIndexChanged += new System.EventHandler(this.cbxToMinute_SelectedIndexChanged);
            // 
            // cbxFromMinute
            // 
            this.cbxFromMinute.FormattingEnabled = true;
            this.cbxFromMinute.Location = new System.Drawing.Point(70, 6);
            this.cbxFromMinute.Name = "cbxFromMinute";
            this.cbxFromMinute.Size = new System.Drawing.Size(40, 21);
            this.cbxFromMinute.TabIndex = 13;
            this.cbxFromMinute.SelectedIndexChanged += new System.EventHandler(this.cbxFromMinute_SelectedIndexChanged);
            // 
            // cbxToHour
            // 
            this.cbxToHour.FormattingEnabled = true;
            this.cbxToHour.Location = new System.Drawing.Point(150, 6);
            this.cbxToHour.Name = "cbxToHour";
            this.cbxToHour.Size = new System.Drawing.Size(40, 21);
            this.cbxToHour.TabIndex = 14;
            this.cbxToHour.SelectedIndexChanged += new System.EventHandler(this.cbxToHour_SelectedIndexChanged);
            // 
            // JobControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "JobControl";
            this.Size = new System.Drawing.Size(846, 46);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.CheckBox checkBoxDone;
        private System.Windows.Forms.TextBox textBoxJobDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelSaved;
        private System.Windows.Forms.ComboBox cbxFromHour;
        private System.Windows.Forms.ComboBox cbxFromMinute;
        private System.Windows.Forms.ComboBox cbxToMinute;
        private System.Windows.Forms.ComboBox cbxToHour;
    }
}
