using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.digital.vackarklocka
{
    class AlarmClock
    {
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;

        public int AlarmHour
        {
            get { return _alarmHour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException();
                }
                _alarmHour = value;
            }
        }
        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException();
                }
                _alarmMinute = value;
            }
        }
        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException();
                }
                _hour = value;
            }
        }
        public int Minute
        {
            get { return _minute; }
            set
            {

                if (value < 0 || value > 59)
                {
                    throw new ArgumentException();
                }
                _minute = value;
            }
        }

        
        public AlarmClock()
            : this(0, 0)
        {
            
        }

        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)
        {
            
        }

        
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }

        

        public bool TickTock()
        {
            
            if (Minute < 59)
            {
                ++Minute;
            }
            else
            {
                Minute = 0;

                if (Hour < 23)
                {
                    Hour++;
                }
                else
                {
                    Hour = 0;
                }
            }
            if (Hour == AlarmHour && Minute == AlarmMinute)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return string.Format(" {0,4}:{1:00} <{2}:{3:00}>", Hour, Minute, AlarmHour, AlarmMinute);
        }
    }
}
