using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.digital.vackarklocka
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn");
            AlarmClock Clock1 = new AlarmClock();
            Console.WriteLine(Clock1.ToString());

            ViewTestHeader("Test 2.\nTest av konstruktor med två parametrar, <9, 42>");
            AlarmClock Clock2 = new AlarmClock(9, 42);
            Console.WriteLine(Clock2.ToString());

            ViewTestHeader("Test 3.\nTest av konstruktor med fyra parametrar, <13, 24, 7, 35>");
            AlarmClock Clock3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(Clock3.ToString());

            ViewTestHeader("Test 4.\n Ställer befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.");
            Clock3.Hour = 23;
            Clock3.Minute = 58;
            run(Clock3, 13);

            ViewTestHeader("Test 5.\nStäller in befintligt AlarmClock-objet till tiden 6:12 och alarmtiden till 6:15 och låter tiden gå 6 minuter.");
            Clock3.Hour = 6;
            Clock3.Minute = 12;
            Clock3.AlarmHour = 6;
            Clock3.AlarmMinute = 15;
            run(Clock3, 6);

            ViewTestHeader("Test 6.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tillsdelas felaktiga värden.");
            try
            {
                Clock3.Hour = 24;
            }
            catch (ArgumentException)
            {
                ViewErrorMessage("Timmen är inte i intervallet 0-23.");
            }
            try
            {
                Clock3.Minute = 60;
            }
            catch (ArgumentException)
            {
                ViewErrorMessage("Minuten är inte i intervallet 0-59");
            }
            try
            {
                Clock3.AlarmHour = 24;
            }
            catch (ArgumentException)
            {
                ViewErrorMessage("Alarmtimmen är inte i intervallet 0-23.");
            }
            try
            {
                Clock3.AlarmMinute = 60;
            }
            catch (ArgumentException)
            {
                ViewErrorMessage("Alarmminuten är inte i intervallet 0-59");
            }

            ViewTestHeader("Test 7.\nTestar konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiva värden.");
            try
            {
                AlarmClock Clock4 = new AlarmClock(24, 0);
            }
            catch (ArgumentException)
            {
                ViewErrorMessage("Timmen är inte i intervallet 0-23.");
            }
            
            try
            {
                AlarmClock Clock5 = new AlarmClock(0, 0, 24, 0);
            }
            catch (ArgumentException)
            {
                ViewErrorMessage("Alarmtimmen är inte i intervallet 0-23");
            }
            

        }
        private static void run(AlarmClock clock,int minute)
        {
             Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔══════════════════════════════════════╗ ");
            Console.WriteLine(" ║       Väckarklockan URLED <TM>       ║ "); 
            Console.WriteLine(" ║        Modellnr.:1DV402S2L2A         ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════╝ ");
            Console.ResetColor();
            
            for (int i = 0; i < minute; i++)
            { 
                if (clock.TickTock() == true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("♫" + clock.ToString() + " BEEP, BEEP, BEEP!!!");
                }
                else
                {
                    Console.ResetColor(); 
                    Console.WriteLine(" " + clock.ToString());
                }      
            }
        }
        private static void ViewErrorMessage(string str)
        { 
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        private static void ViewTestHeader(string head)
        {
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(head);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
