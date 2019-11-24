using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using RecordCollection.Models;

namespace RecordCollection.Models
{
    public class Menu
    {
       public static void MenuList()
        {


            Console.WriteLine("" +
                "\t1) View collection\n" +
                "\t2) Add to collection\n" +
                "\t3) Remove from collection\n" +
                "\t3) TODO - Wishlist\n" +
                "\t4) TODO - Sell\n" +
                "\t5) TODO - Buy\n" +
                "\t6) Random pick to play\n" +
                "\t7) Search\n" +
                "\t8) Collection value\n" +
                "\t0) Exit");

            int choice = 9999;
            Console.WriteLine("Please enter a number: ");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You did not enter a correct value!");
                Console.ReadKey();
                Console.Clear();
                Controls.Header();
                MenuList();
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Controls.Header();
                    Controls.ViewCollection();
                    break;
                case 2:
                    Console.Clear();
                    Controls.Header();
                    Controls.AddToCollection();
                    break;
                case 3:
                    Console.Clear();
                    Controls.Header();
                    Controls.Remove();
                    break;
                case 4:
                    Console.WriteLine("Vowel");
                    break;
                case 5:
                    Console.WriteLine("Vowel");
                    break;
                case 6:
                    Console.Clear();
                    Controls.Header();
                    Controls.RandomPlay();
                    break;
                case 7:
                    Console.Clear();
                    Controls.Header();
                    Controls.Search();
                    break;
                case 8:
                    Console.Clear();
                    Controls.Header();
                    Controls.CollectionValue();
                    break;
                case 9:
                    Console.WriteLine("Vowel");
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("  _______ _                 _     __     __         ");
                    Console.WriteLine(" |__   __| |               | |    \\ \\   / /         ");
                    Console.WriteLine("    | |  | |__   __ _ _ __ | | __  \\ \\_/ /__  _   _ ");
                    Console.WriteLine("    | |  | '_ \\ / _` | '_ \\| |/ /   \\   / _ \\| | | |");
                    Console.WriteLine("    | |  | | | | (_| | | | |   <     | | (_) | |_| |");
                    Console.WriteLine("    |_|  |_| |_|\\__,_|_| |_|_|\\_\\    |_|\\___/ \\__,_|");
                    Console.WriteLine("");
                    Console.WriteLine("   _____                                           _       _ ");
                    Console.WriteLine("  / ____|                         /\\              (_)     | |");
                    Console.WriteLine(" | |     ___  _ __ ___   ___     /  \\   __ _  __ _ _ _ __ | |");
                    Console.WriteLine(" | |    / _ \\| '_ ` _ \\ / _ \\   / /\\ \\ / _` |/ _` | | '_ \\| |");
                    Console.WriteLine(" | |___| (_) | | | | | |  __/  / ____ \\ (_| | (_| | | | | |_|");
                    Console.WriteLine("  \\_____\\___/|_| |_| |_|\\___| /_/   \\ \\_\\__, |\\__,_|_|_| |_(_)");
                    Console.WriteLine("                                        __/ |                ");
                    Console.WriteLine("                                       |___/                 ");

                    break;

            }


        }

    }
}
