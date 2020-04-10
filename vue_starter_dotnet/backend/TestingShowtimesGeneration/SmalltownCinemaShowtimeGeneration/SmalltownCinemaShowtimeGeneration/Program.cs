using System;
using System.Collections.Generic;

namespace SmalltownCinemaShowtimeGeneration
{
    class Program
    {
        
        
        public static void Main(string[] args)
        {
            Screen screen1 = new Screen(124, 0);
            screen1.AddShowtimes();
            screen1.PrintShowtimes();
            Console.WriteLine();
            Screen screen2 = new Screen(124, 15);
            screen2.AddShowtimes();
            screen2.PrintShowtimes();
        }

        
    }
}
