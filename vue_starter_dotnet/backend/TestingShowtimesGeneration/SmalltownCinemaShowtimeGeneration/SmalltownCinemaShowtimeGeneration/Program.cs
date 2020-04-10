using System;
using System.Collections.Generic;

namespace SmalltownCinemaShowtimeGeneration
{
    class Program
    {


        public static void Main(string[] args)
        {
            
            Console.WriteLine("All screens list: ");
            List<Screen> screens = new List<Screen>();
            screens.Add(new Screen(142, 0, 1, 1));
            screens.Add(new Screen(142, 5, 1, 2));
            screens.Add(new Screen(124, 0, 2, 3));
            screens.Add(new Screen(124, 5, 2, 4));
            screens.Add(new Screen(141, 0, 3, 5));
            screens.Add(new Screen(141, 5, 3, 6));
            screens.Add(new Screen(141, 10, 3, 7));
            foreach (var screen in screens)
            {
                screen.AddShowtimes();
                
            }
        }


    }
}
