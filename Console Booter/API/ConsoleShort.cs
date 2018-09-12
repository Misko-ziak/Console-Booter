using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Booter.API
{
    class ConsoleShort
    {
        public static void WriteLine(string text, ConsoleColor color) { Console.ForegroundColor = color; Console.WriteLine(text); Console.ResetColor(); }
        public static void Space() { Console.WriteLine(""); }
        public static void Pause() {Console.ReadKey();}
    }
}
