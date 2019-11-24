using RecordCollection.Models;
using System;

namespace RecordCollection
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;


            Controls.Header();
            Menu.MenuList();
            
            Console.ReadKey();

        }
    }
}
