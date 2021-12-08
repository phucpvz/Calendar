using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class JobControl : UserControl
    {
        private PlanItem job;
        public PlanItem Job { get => job; set => job = value; }

        private event EventHandler edited;
        public event EventHandler Edited
        {
            add { edited += value; }
            remove { edited -= value; }
        }

        private event EventHandler deleted;
        public event EventHandler Deleted
        {
            add { deleted += value; }
            remove { deleted -= value; }
        }

        private event EventHandler statusChanged;
        public event EventHandler StatusChanged
        {
            add { statusChanged += value; }
            remove { statusChanged -= value; }
        }

        public JobControl(DailyPlan parent, PlanItem job)
        {
            InitializeComponent();
            labelSaved.BackColor = Color.White;

            new JobControlPainter(panelMain, comboBoxStatus);

            this.Job = job;

            // Biến cờ hiệu
            comboBoxStatus.Tag = true;
            checkBoxDone.Tag = true;

            ShowInfo();

            parent.Saved += Parent_Saved;
        }

        private void Parent_Saved(object sender, EventArgs e)
        {
            Job.Saved = true;
            ShowSaved();
        }

        // Hiển thị các thông tin trên thanh công việc
        private void ShowInfo()
        {
            textBoxJobDescription.Text = Job.JobName;
            cbxFromHour.DataSource = Constants.GetHourNumbers();
            cbxFromMinute.DataSource = Constants.GetMinuteNumbers();
            cbxToHour.DataSource = Constants.GetHourNumbers();
            cbxToMinute.DataSource = Constants.GetMinuteNumbers();

            cbxFromHour.SelectedIndex = Job.FromTime.X;
            cbxFromMinute.SelectedIndex = Job.FromTime.Y;
            cbxToHour.SelectedIndex = Job.ToTime.X;
            cbxToMinute.SelectedIndex = Job.ToTime.Y;

            // Xem xét trạng thái công việc có đúng với thời gian hiện tại không
            ChangeJobStatusByTimeNow();

            int idx = PlanItem.ListStatus.IndexOf(Job.Status);
            comboBoxStatus.DataSource = PlanItem.ListStatus;
            comboBoxStatus.SelectedIndex = idx;

            checkBoxDone.Checked = (PlanItem.ListStatus.IndexOf(Job.Status) == (int)EPlanItem.DONE);

            // Label mặc định là "Chưa lưu" nên phải kiểm tra lại
            if (Job.Saved)
            {
                ShowSaved();
            }
        }

        private void ChangeJobStatusByTimeNow()
        {
            // Lấy cả ngày giờ
            DateTime now = DateTime.Now;
            DateTime fromTime = new DateTime
                (Job.JobDate.Year, Job.JobDate.Month, Job.JobDate.Day, Job.FromTime.X, Job.FromTime.Y, 0);
            DateTime toTime = new DateTime
                (Job.JobDate.Year, Job.JobDate.Month, Job.JobDate.Day, Job.ToTime.X, Job.ToTime.Y, 0);

            // Nếu trạng thái là DONE thì bỏ qua
            if (PlanItem.ListStatus.IndexOf(Job.Status) == (int)EPlanItem.DONE)
            {
                return;
            }

            if (DateTime.Compare(now, fromTime) < 0)
            {
                Job.Status = PlanItem.ListStatus[(int)EPlanItem.COMING];
            }
            else if (DateTime.Compare(now, toTime) > 0)
            {
                Job.Status = PlanItem.ListStatus[(int)EPlanItem.MISSED];
            }
            else
            {
                Job.Status = PlanItem.ListStatus[(int)EPlanItem.DOING];
            }
        }

        private void ShowSaved()
        {
            labelSaved.Text = "Đã lưu";
            labelSaved.ForeColor = Color.Blue;
        }

        private void ShowNotSaved()
        {
            labelSaved.Text = "Chưa lưu";
            labelSaved.ForeColor = Color.Red;
        }

        private void NotifyEdited()
        {
            // Mẹo: Khi chưa có ủy thác 
            // => Sự thay đổi lúc khởi tạo => Không đặt trạng thái công việc là "Chưa lưu"
            if (edited != null)
            {
                // Hiển thị trạng thái chưa lưu (vào file), nghĩa là đã có sự chỉnh sửa
                Job.Saved = false;
                ShowNotSaved();

                edited(this, new EventArgs());
            }
        }

        private void NotityDeleted()
        {
            if (deleted != null)
            {
                deleted(this, new EventArgs());
            }
        }

        private void NotifyStatusChanged()
        {
            if (statusChanged != null)
            {
                statusChanged(this, new EventArgs());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            NotityDeleted();
        }

        private void checkBoxDone_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu comboBox đã được thay đổi, checkBox không được thay đổi giá trị của comboBox ở lần này!
            if ((bool)checkBoxDone.Tag == false)
            {
                checkBoxDone.Tag = true;
                return;
            }

            // Ra hiệu cho comboBox không được thay đổi lại giá trị đã gán cho!
            comboBoxStatus.Tag = false;

            comboBoxStatus.SelectedIndex = checkBoxDone.Checked ? (int)EPlanItem.DONE : (int)EPlanItem.DOING;
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Job.Status = PlanItem.ListStatus[comboBoxStatus.SelectedIndex];
            NotifyEdited();
            NotifyStatusChanged();

            // Nếu checkBox đã được thay đổi, comboBox không được thay đổi giá trị của checkBox ở lần này!
            if ((bool)comboBoxStatus.Tag == false)
            {
                comboBoxStatus.Tag = true;
                return;
            }

            // Ra hiệu cho checkBox không được thay đổi lại giá trị đã gán cho!
            checkBoxDone.Tag = false;

            checkBoxDone.Checked = (comboBoxStatus.SelectedIndex == (int)EPlanItem.DONE);
        }

        private void textBoxJobDescription_TextChanged(object sender, EventArgs e)
        {
            Job.JobName = textBoxJobDescription.Text;
            NotifyEdited();
        }

        private void cbxFromHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mẹo: Khi chưa có ủy thác 
            // => Sự thay đổi lúc khởi tạo => Không tạo lại thời gian
            if (edited != null)
            {
                Job.FromTime = new Point(cbxFromHour.SelectedIndex, Job.FromTime.Y);
                NotifyEdited();
            }
        }

        private void cbxFromMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edited != null)
            {
                Job.FromTime = new Point(Job.FromTime.X, int.Parse(cbxFromMinute.SelectedItem.ToString()));
                NotifyEdited();
            }
            
        }

        private void cbxToHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edited != null)
            {
                Job.ToTime = new Point(int.Parse(cbxToHour.SelectedItem.ToString()), Job.ToTime.Y);
                NotifyEdited();
            }
            
        }

        private void cbxToMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edited != null)
            {
                Job.ToTime = new Point(Job.ToTime.X, int.Parse(cbxToMinute.SelectedItem.ToString()));
                NotifyEdited();
            }
        }
    }
}
