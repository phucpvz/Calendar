using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public class JobControlPainter
    {
        private Panel panelJobControl;
        private ComboBox comboBoxStatus;

        private static readonly List<Color> statusColors = new List<Color>
        {
            Color.GreenYellow, Color.LightBlue, Color.Yellow, Color.IndianRed
        };

        public Panel PanelJobControl { get => panelJobControl; set => panelJobControl = value; }
        public ComboBox ComboBoxStatus { get => comboBoxStatus; set => comboBoxStatus = value; }

        public JobControlPainter(Panel panel, ComboBox comboBox)
        {
            this.PanelJobControl = panel;
            this.ComboBoxStatus = comboBox;
            ComboBoxStatus.SelectedIndexChanged += ComboBoxStatus_SelectedIndexChanged;
        }

        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelJobControl.BackColor = statusColors[ComboBoxStatus.SelectedIndex];
        }
    }
}
