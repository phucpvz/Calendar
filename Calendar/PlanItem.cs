using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calendar
{
    public class PlanItem
    {
        private DateTime jobDate;
        private string jobName;
        private Point fromTime;
        private Point toTime;
        private string status;

        private bool saved = true;
        
        public DateTime JobDate { get => jobDate; set => jobDate = value; }
        public string JobName { get => jobName; set => jobName = value; }
        public Point FromTime { get => fromTime; set => fromTime = value; }
        public Point ToTime { get => toTime; set => toTime = value; }
        public string Status { get => status; set => status = value; }

        [XmlIgnoreAttribute]
        public bool Saved { get => saved; set => saved = value; }

        public static readonly List<string> ListStatus = new List<string>()
        {
            "DONE", "DOING", "COMING", "MISSED"
        };
    }

    public enum EPlanItem
    {
        DONE, DOING, COMING, MISSED
    }
}
