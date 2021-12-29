using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public class ConsolePrinter:IPrinter
    {
        private ConsoleColor c;

        public ConsolePrinter(ConsoleColor c)
        {
            Console.ForegroundColor = c;
        }

        public ConsoleColor C { get => c; set => c = value; }

        public void print(Weather[] weathers)
        {
                for(int i=0;i<weathers.Length;i++)
                Console.WriteLine(weathers[i].ToString());
        }
    }
}
