using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public class CalendarPainter
    {
        private DateTimePicker datePicker;
        private List<List<Button>> matrix;

        public DateTimePicker DatePicker { get => datePicker; set => datePicker = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        public CalendarPainter(DateTimePicker datePiker, List<List<Button>> matrix)
        {
            DatePicker = datePiker;
            DatePicker.ValueChanged += DatePicker_ValueChanged;

            Matrix = matrix;
            PaintMatrix();
        }

        private void ClearMatrix()
        {
            Button btn;
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }
        }

        private void PaintMatrix()
        {
            ClearMatrix();

            DateTime selectedDate = DatePicker.Value;
            DateTime firstDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            DateTime now = DateTime.Now;

            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int column = Constants.DAYS_OF_WEEK.IndexOf(firstDate.DayOfWeek.ToString());
            int row = 0;

            for (int i = 1; i <= daysInMonth; i++)
            {
                Button btn = Matrix[row][column];
                btn.Text = i.ToString();

                if (i.ToString() == now.Day.ToString()
                    && selectedDate.Month == now.Month
                    && selectedDate.Year == now.Year)
                {
                    btn.BackColor = Color.GreenYellow;
                }

                if (i.ToString() == selectedDate.Day.ToString())
                {
                    btn.ForeColor = Color.Red;
                }

                ++column;

                if (column >= 7)
                {
                    ++row;
                    column = 0;
                }
            }
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            PaintMatrix();
        }
    }
}
