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
    public partial class DailyPlan : Form
    {
        private PlanData myJobs;
        private List<JobControl> jobControls;
        private FlowLayoutPanel fPanel;
        private bool savedAllChanges = true;

        public PlanData MyJobs { get => myJobs; set => myJobs = value; }
        public bool SavedAllChanges { get => savedAllChanges; set => savedAllChanges = value; }
        public List<JobControl> JobControls { get => jobControls; set => jobControls = value; }

        private event EventHandler saved;
        public event EventHandler Saved
        {
            add { saved += value; }
            remove { saved -= value; }
        }

        public DailyPlan(DateTime date, PlanData myJobs)
        {
            InitializeComponent();

            this.MyJobs = myJobs;

            fPanel = new FlowLayoutPanel();
            fPanel.Width = panelJobs.Width;
            fPanel.Height = panelJobs.Height;
            fPanel.AutoScroll = true;
            panelJobs.Controls.Add(fPanel);

            CreateListJobControls();

            this.dateTimePicker.Value = date;
        }

        // Hiển thị thông tin trên thanh trạng thái
        private void ShowStatusBar()
        {
            List<JobControl> listJC = GetJobControlsByDate(dateTimePicker.Value);
            int total = listJC.Count;
            int done = 0;
            int doing = 0;
            int coming = 0;
            int missed = 0;
            for (int i = 0; i < total; i++)
            {
                int idx = PlanItem.ListStatus.IndexOf(listJC[i].Job.Status);
                switch (idx)
                {
                    case (int)EPlanItem.DONE:
                        ++done;
                        break;
                    case (int)EPlanItem.DOING:
                        ++doing;
                        break;
                    case (int)EPlanItem.COMING:
                        ++coming;
                        break;
                    case (int)EPlanItem.MISSED:
                        ++missed;
                        break;
                    default:
                        break;
                }
            }
            labelStatusBar.Text = string.Format
                ("Tổng: {0} việc | DONE: {1} | DOING: {2} | COMING: {3} | MISSED: {4}", total, done, doing, coming, missed);
        }

        private void CreateListJobControls()
        {
            JobControls = new List<JobControl>();
            if (MyJobs != null && MyJobs.Jobs != null)
            {
                int count = MyJobs.Jobs.Count;
                for (int i = 0; i < count; i++)
                {
                    JobControls.Add(CreateAJobControl(MyJobs.Jobs[i]));
                }
            }
        }

        private JobControl CreateAJobControl(PlanItem job)
        {
            JobControl aJob = new JobControl(this, job);
            aJob.Edited += AJob_Edited;
            aJob.Deleted += AJob_Deleted;
            aJob.StatusChanged += AJob_StatusChanged;
            return aJob;
        }

        private void AJob_StatusChanged(object sender, EventArgs e)
        {
            ShowStatusBar();
        }

        private void NotifySaved()
        {
            if (saved != null)
            {
                saved(this, new EventArgs());
            }
        }

        // Người dùng chọn ngày khác
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ShowJobsByDate(dateTimePicker.Value);
            ShowStatusBar();
        }

        // Lấy các thanh công việc theo ngày được chọn
        private List<JobControl> GetJobControlsByDate(DateTime date)
        {
            return JobControls.Where(jc => jc.Job.JobDate == date).ToList();
        }

        // Hiển thị danh sách công việc theo ngày được chọn lên bảng
        private void ShowJobsByDate(DateTime date)
        {
            fPanel.Controls.Clear();

            if (JobControls != null)
            {
                List<JobControl> listJC = GetJobControlsByDate(date);
                for (int i = 0; i < listJC.Count; i++)
                {
                    fPanel.Controls.Add(listJC[i]);
                }
            }
        }

        // Sự kiện: Nhấn vào nút xóa trên thanh công việc
        private void AJob_Deleted(object sender, EventArgs e)
        {
            JobControl aJob = sender as JobControl;
            PlanItem job = aJob.Job;

            fPanel.Controls.Remove(aJob);
            MyJobs.Jobs.Remove(job);
            JobControls.Remove(aJob);

            ShowStatusBar();
            SavedAllChanges = false;
        }

        // Sự kiện: Thông tin trên trên thanh công việc bị thay đổi
        private void AJob_Edited(object sender, EventArgs e)
        {
            SavedAllChanges = false;
        }

        // Nút: Hôm trước
        private void btnPreviousDate_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        // Nút: Hôm sau
        private void btnNextDate_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }

        // Menu: Thêm việc
        private void toolStripAddJob_Click(object sender, EventArgs e)
        {
            PlanItem item = new PlanItem()
            {
                JobDate = dateTimePicker.Value,
                Status = PlanItem.ListStatus[(int)EPlanItem.COMING],
                Saved = false
            };

            MyJobs.Jobs.Add(item);
            JobControl aJob = CreateAJobControl(item);
            JobControls.Add(aJob);
            fPanel.Controls.Add(aJob);

            ShowStatusBar();
            SavedAllChanges = false;
        }

        // Menu: Hôm nay
        private void toolStripToday_Click(object sender, EventArgs e)
        {
            // Chỉ quan tâm đến ngày, bỏ qua thời gian
            dateTimePicker.Value = DateTime.Now.Date;
        }

        // Lưu vào file
        private void SaveToFile()
        {
            if (MyJobs != null)
            {
                if (Controller.SerializeToXML(MyJobs))
                {
                    SavedAllChanges = true;
                }
            }
        }

        // Menu: Lưu lại
        private void toolStripSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
            // Thông báo đã lưu để thay đổi text trên các JobControl
            // P/S: Chỉ khi nhấn nút lưu lại mới cần thông báo, lưu lúc thoát không cần thông báo lại!
            NotifySaved();
        }

        // Khi đóng form Kế hoạch trong ngày
        private void DailyPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SavedAllChanges)
            {
                DialogResult choice = MessageBox.Show("Bạn chưa lưu lại các thay đổi!\n" +
                   "\nBạn có muốn lưu lại các thay đổi vào file data.xml không?",
                   "Warning: Plan Changed But Not Be Saved!",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (choice == DialogResult.Yes)
                {
                    SaveToFile();
                }
                else if (choice == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
