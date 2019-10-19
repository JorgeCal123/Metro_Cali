using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
   public class GenericTime
    {
        public static String POST_MERIDIEM = "PM";
        public static String ANTE_MERIDIEM = "AM";
        private int year;
        private int day;
        private int month;
        private int minute;
        private int hour;
        private int second;
        private String meridiem;



        public GenericTime(int year, int day, int month, int minute, int hour, int second, String meridiem)
        {
            this.year = year;
            this.day = day;
            this.month = month;
            this.minute = minute;
            this.hour = hour;
            this.second = second;
            this.meridiem = meridiem;
        }

        public int Year { get => year; set => year = value; }
        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Minute { get => minute; set => minute = value; }
        public int Hour { get => hour; set => hour = value; }
        public int Second { get => second; set => second = value; }


        public void passSecond()
        {

            if (second != 60)
            {
                second++;
            }
            else
            {
                second = 0;
                passminute();
            }


        }

        private void passminute()
        {

            if (minute != 60)
            {
                minute++;
            }
            else
            {
                minute = 0;
                passHour();
            }
        }

        private void passHour()
        {
            if (hour != 12)
            {
                hour++;
            }
            else if (meridiem.Equals(POST_MERIDIEM))
            {
                meridiem = ANTE_MERIDIEM;
                passDay();
            }
            else
            {
                meridiem = POST_MERIDIEM;
            }
        }

        private void passDay()
        {
            if (day != 30)
            {
                day++;
            }
            else
            {
                day = 0;
                passMonth();
            }
        }

        private void passMonth()
        {
            if (month != 12)
            {
                month++;
            }
            else
            {
                month = 0;
                passYear();
            }
        }

        public String parseMonth(int name)
        {
            String value = "";

            if (name == (12))
            {
                value = "DIC";
            }
            else if (name == (11))
            {
                value = "NOV";
            }
            else if (name == (10))
            {
                value = "OCT";
            }
            else if (name == (09))
            {
                value = "SEP";
            }
            else if (name == (08))
            {
                value = "AGO";
            }
            else if (name == (07))
            {
                value = "JUL";
            }
            else if (name == (06))
            {
                value = "JUN";
            }
            else if (name == (05))
            {
                value = "MAY";
            }
            else if (name == (04))
            {
                value = "ABR";
            }
            else if (name == (03))
            {
                value = "MAR";
            }
            else if (name == (02))
            {
                value = "FEB";
            }
            else if (name == (01))
            {
                value = "ENE";
            }

            return value;
        }
        private void passYear()
        {
            year++;
        }

        public String generateDataTime()
        {
            string actual = day + "-" + parseMonth(month) + "-" + year + " " + hour + "." + minute + "." + second+" "+meridiem;

            return actual;


        }
        public String showTime()
        {
            string actual = "Fecha: "+day + " " + parseMonth(month) + " " + year + "\nHora:  " + hour + ":" + minute + ":" + second +" "+ meridiem;

            return actual;


        }

    }
}
