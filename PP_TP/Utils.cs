using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_TP
{
    public static class Utils
    {

        public static void PrintError(string s)
        {

            Console.ForegroundColor = System.ConsoleColor.Red;

            Console.WriteLine(s);

            Console.ForegroundColor = System.ConsoleColor.Green;

        }

        public static void PrintListItem(string s)
        {

            Console.ForegroundColor = System.ConsoleColor.White;

            Console.WriteLine(s);

            Console.ForegroundColor = System.ConsoleColor.Green;

        }

        public static void PrintEaster(string s)
        {

            Console.ForegroundColor = System.ConsoleColor.Yellow;

            Console.WriteLine(s);

            Console.ForegroundColor = System.ConsoleColor.Green;

        }

    }
}
