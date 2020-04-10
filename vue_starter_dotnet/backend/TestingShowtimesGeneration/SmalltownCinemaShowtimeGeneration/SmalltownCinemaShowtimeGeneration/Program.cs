using System;
using System.Collections.Generic;

namespace SmalltownCinemaShowtimeGeneration
{
    class Program
    {
        
        
        public static void Main(string[] args)
        {
            Screen screen1 = new Screen(124);
            screen1.AddShowtimes();
            screen1.PrintShowtimes();
            Screen screen2 = new Screen(180);
            screen2.AddShowtimes();
            screen2.PrintShowtimes();
        }

        
    }
}
