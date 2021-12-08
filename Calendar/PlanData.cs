using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    [Serializable]
    public class PlanData
    {
        private List<PlanItem> jobs;
        public List<PlanItem> Jobs { get => jobs; set => jobs = value; }
    }
}
