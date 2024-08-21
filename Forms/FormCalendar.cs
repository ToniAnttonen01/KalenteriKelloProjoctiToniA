using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalenteriKelloProjoctiToniA.Forms
{
    public partial class FormCalendar : System.Windows.Forms.Form
    {
        public static int _year, _month;
        public FormCalendar()
        {
            InitializeComponent();
        }

        private void FormCalendar_Load(object sender, EventArgs e)
        {

        }

        private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
           
            label1.Text = monthName.ToUpper() + " " + year;
            DateTime startodTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d"));
            for (int i = 1; i <= week; i++)
            {
                ucDayrs uc = new ucDayrs("");
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i <= day; i++) 
            {
                ucDayrs uc = new ucDayrs(i + "");
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
    }
}
