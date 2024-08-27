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
            showDays(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _month += 1;
            if(_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDays(_month, _year);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _month += 1;
            if (_month < 1)
            {
                _month = 12;
                _year -= 1;
            }
            showDays(_month, _year);
        }

        private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 1 and 9999.");
            }

            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
            }

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            lbMonth.Text = monthName.ToUpper() + " " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDayOfWeek = (int)startOfTheMonth.DayOfWeek;

           
            for (int i = 0; i < startDayOfWeek; i++)
            {
                ucDayrs uc = new ucDayrs(""); 
                flowLayoutPanel1.Controls.Add(uc);
            }

            
            for (int i = 1; i <= daysInMonth; i++)
            {
                ucDayrs uc = new ucDayrs(i.ToString());
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
        /*private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
           
            lbMonth.Text = monthName.ToUpper() + " " + year;
            DateTime startodTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 0; i < week; i++)
            {
                ucDayrs uc = new ucDayrs("");
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i <= day; i++) 
            {
                ucDayrs uc = new ucDayrs(i + "");
                flowLayoutPanel1.Controls.Add(uc);
            }
        }*/
    }
}
