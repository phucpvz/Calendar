using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private List<List<Button>> matrix;
        private PlanData myJobs;

        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public PlanData MyJobs { get => myJobs; set => myJobs = value; }

        public Form1()
        {
            InitializeComponent();

            // Kiểm tra đã đăng ký khởi động cùng máy tính trước đó?
            checkBoxStartup.Checked = ApplicationStartup.IsRegistered();
            toolTipStartup.SetToolTip(checkBoxStartup, Constants.TOOLTIP_STARTUP);

            InitializeMatrixValue();
            LoadMatrix();
            new CalendarPainter(dateTimePicker, Matrix);
            //SetDefaultDate();

            MyJobs = Controller.DeserializeFromXML() as PlanData;
            if (MyJobs == null)
            {
                SetDefaultJob();
            }
            else
            {
                int length = MyJobs.Jobs.Count;
                for (int i = 0; i < length; i++)
                {
                    MyJobs.Jobs[i].Saved = true;
                }
            }
        }

        private void SetDefaultJob()
        {
            MyJobs = new PlanData();
            MyJobs.Jobs = new List<PlanItem>()
            {
                new PlanItem()
                {
                    JobDate = DateTime.Now,
                    JobName = "Miêu tả kế hoạch của bạn ở đây!",
                    FromTime = new Point(0, 0),
                    ToTime = new Point(23, 59),
                    Status = PlanItem.ListStatus[(int)EPlanItem.COMING],
                    Saved = false
                },
            };
        }

        private void InitializeMatrixValue()
        {
            Constants.WIDTH_OF_BUTTON = btnMonday.Width;
            Constants.HEIGHT_OF_BUTTON = btnMonday.Height;
            Constants.DISTANCE = btnMonday.Margin.All * 2;
        }

        private void LoadMatrix()
        {
            Matrix = new List<List<Button>>();

            Button btnOld = new Button() { Width = 0, Height = 0, Location = new Point(-Constants.DISTANCE, 0) };
            for (int i = 0; i < Constants.NUMBERS_OF_WEEKS_IN_MONTH; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Constants.NUMBERS_OF_DAYS_OF_WEEK; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Constants.WIDTH_OF_BUTTON,
                        Height = Constants.HEIGHT_OF_BUTTON,
                    };
                    btn.Location = new Point(btnOld.Location.X + btnOld.Width + Constants.DISTANCE, btnOld.Location.Y);

                    btn.Click += Btn_Click;

                    panelMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    btnOld = btn;
                }

                btnOld = new Button()
                {
                    Width = 0,
                    Height = 0,
                    Location = new Point(-Constants.DISTANCE, btnOld.Location.Y + btnOld.Height + Constants.DISTANCE)
                };
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string text = (sender as Button).Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            DailyPlan dailyPlan = new DailyPlan(
                new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, Int32.Parse(text)),
                MyJobs);
            dailyPlan.FormClosing += DailyPlan_FormClosing;
            dailyPlan.ShowDialog();
        }

        // Tải lại dữ liệu lên form chính
        private void DailyPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyJobs = Controller.DeserializeFromXML() as PlanData;
            if (MyJobs == null)
            {
                SetDefaultJob();
            }
        }

        private void SetDefaultDate()
        {
            dateTimePicker.Value = DateTime.Now;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddMonths(-1);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddMonths(1);
        }

        private void timerNotify_Tick(object sender, EventArgs e)
        {
            if (MyJobs == null || MyJobs.Jobs == null)
            {
                return;
            }

            DateTime now = DateTime.Now;
            List<PlanItem> todayJobs = MyJobs.Jobs.Where(p => p.JobDate.Date == now.Date).ToList();

            notifyIcon.ShowBalloonTip(Constants.NOTIFY_TIMEOUT, "Kế hoạch trong ngày",
                string.Format("Bạn có {0} công việc trong ngày hôm nay!", todayJobs.Count), ToolTipIcon.Info);
        }

        private void checkBoxNotify_CheckedChanged(object sender, EventArgs e)
        {
            bool enabledNotify = checkBoxNotify.Checked;

            numericNotifyTime.Enabled = enabledNotify;

            if (enabledNotify)
            {
                SetNotifyTime();
                //timerNotify.Interval = 5000;

                timerNotify.Enabled = true;
                //timerNotify.Start();
            }
            else
            {
                timerNotify.Enabled = false;
                //timerNotify.Stop();
            }
        }

        private void numericNotifyTime_ValueChanged(object sender, EventArgs e)
        {
            SetNotifyTime();
        }

        private void SetNotifyTime()
        {
            timerNotify.Interval = (int)numericNotifyTime.Value * Constants.MILISECOND_TO_MINUTE;
        }

        // CheckBox: Khởi động cùng máy tính
        private void checkBoxStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStartup.Checked)
            {
                ApplicationStartup.AddRegistry();
            }
            else
            {
                ApplicationStartup.RemoveRegistry();
            }
        }
    }
}
