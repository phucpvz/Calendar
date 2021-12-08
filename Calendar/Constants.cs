using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    static class Constants
    {
        public const int NUMBERS_OF_DAYS_OF_WEEK = 7;
        public const int NUMBERS_OF_WEEKS_IN_MONTH = 6;

        public static int WIDTH_OF_BUTTON;
        public static int HEIGHT_OF_BUTTON;

        public static int DISTANCE;

        public static readonly List<string> DAYS_OF_WEEK = new List<string>()
        { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public static int NOTIFY_TIMEOUT = 10000;    // 10s
        public const int MILISECOND_TO_MINUTE = 60000;  //60s

        public const string TOOLTIP_STARTUP =
            "Để đảm bảo chương trình được khởi động mỗi khi bật máy tính:\n" +
            "Vào Task Manager > Startup > Tìm ứng dụng tên là Calendar và đặt Status tương ứng là Enabled.";

        private const int HOUR_LIMIT = 24;
        private const int MINUTE_LIMIT = 60;

        public static int[] GetHourNumbers()
        {
            int[] HOURS = new int[HOUR_LIMIT];
            for (int i = 0; i < HOUR_LIMIT; i++)
            {
                HOURS[i] = i;
            }
            return HOURS;
        }

        public static int[] GetMinuteNumbers()
        {
            int[] MINUTES = new int[MINUTE_LIMIT];
            for (int i = 0; i < MINUTE_LIMIT; i++)
            {
                MINUTES[i] = i;
            }
            return MINUTES;
        }
    }
}
