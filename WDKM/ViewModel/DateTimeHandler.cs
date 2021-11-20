using System;
using System.Globalization;
using System.Threading;
using System.Timers;

namespace WDKM.ViewModel
{
    public class DateTimeHandler : ViewModel
    {
        private string _Time;
        public string Time { get => _Time; set { _Time = value; OnPropertyChanged(); } }
        public string DayOfWeek { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        private readonly System.Timers.Timer Count;
        public string Summary { get; set; }
        public DateTimeHandler()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            DayOfWeek = DateTime.Now.DayOfWeek.ToString();
            Month = DateTime.Now.ToString("MMMM");
            Year = DateTime.Now.Year.ToString();

            UpdateDateTime();

            Count = new System.Timers.Timer(1000);
            Count.Elapsed += Count_Elapsed;
            Count.Start();
            Summary = $"\n{Time} {DayOfWeek} {Month} {Year}";
        }

        private void Count_Elapsed(object sender, ElapsedEventArgs e) => UpdateDateTime();
        private void UpdateDateTime()
        {
            Time = DateTime.Now.ToString("H:mm:ss");
        }
        public string GetCurrentDate()
        {
            UpdateDateTime();
            return Summary;
        }
    }
}
