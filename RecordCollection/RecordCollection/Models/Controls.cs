using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RecordCollection.Models;

namespace RecordCollection.Models
{
    public class Controls
    {
        //Header

        public static void Header()
        {
            Console.WriteLine($"Welcome {Config.firstName.ToString()}, to your");
            Console.WriteLine(@"    ____                           __   ______      ____          __  _           ");
            Console.WriteLine(@"   / __ \___  _________  _________/ /  / ____/___  / / /__  _____/ /_(_)___  ____ ");
            Console.WriteLine(@"  / /_/ / _ \/ ___/ __ \/ ___/ __  /  / /   / __ \/ / / _ \/ ___/ __/ / __ \/ __ \");
            Console.WriteLine(@" / _, _/  __/ /__/ /_/ / /  / /_/ /  / /___/ /_/ / / /  __/ /__/ /_/ / /_/ / / / /");
            Console.WriteLine(@"/_/ |_|\___/\___/\____/_/   \__,_/   \____/\____/_/_/\___/\___/\__/_/\____/_/ /_/ ");
            Console.WriteLine(@"");
        }
        //View collection
        public static void ViewCollection ()
        {
            List<string> headerList = new List<string>();
            headerList.Add ("ID");
            headerList.Add("Title");
            headerList.Add("Artist");
            headerList.Add("Released");
            headerList.Add("Label");
            headerList.Add("Price Paid");
            Console.WriteLine("Your collection contains: ");
            Console.WriteLine($"{headerList[0],-8}{headerList[1],-32}{headerList[2],-24}{headerList[3],-16}{headerList[4],-20}{headerList[5],-20}");

            using (StreamReader sr = new StreamReader(Config.pathCollection))
            {
                
                while (!sr.EndOfStream)
                {
                    string[] lineFormat = new string[6];
                    lineFormat = (sr.ReadLine().Split("|"));
                    Console.WriteLine($"{lineFormat[0],-4}\t{lineFormat[1],-30}\t{lineFormat[2],-20}\t{lineFormat[3],-9}\t{lineFormat[4],-20}\t{decimal.Parse(lineFormat[5]),-8}");

                }
            }
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
            Header();
            Menu.MenuList();
        }

        //Add to collection
        public static void AddToCollection()
        {
            int keyCount = 0;
            using (StreamReader sr = new StreamReader(Config.pathCollection))
            {
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    keyCount++;
                }
            }
            string title = "";
            string artist = "";
            string released = "";
            string label = "";
            decimal pricePaid = 0.00M;
           
            Console.WriteLine("Add a new record: \n");
            Console.WriteLine("Please enter a title:");
            title = Console.ReadLine();
            Console.WriteLine("Please enter an artist:");
            artist = Console.ReadLine();
            Console.WriteLine("Please enter a release year:");
            released = Console.ReadLine();
            Console.WriteLine("Please enter a label:");
            label = Console.ReadLine();
            Console.WriteLine("Please enter a price paid:");

            bool validPrice = false;
            while(validPrice == false)
            {
                try
                {
                    pricePaid = decimal.Parse(Console.ReadLine());
                    validPrice = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("You did not enter a valid dollar amount!\n Please reenter a valid price paid.");
                }
            }


            using (StreamWriter sw = new StreamWriter(Config.pathCollection, true))
            {
                sw.WriteLine($"{keyCount}|{title}|{artist}|{released}|{label}|{pricePaid}");
            }
            Console.WriteLine("Record Added!\npress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Header();
            Menu.MenuList();
        }

        //Remove from collection
        public static void Remove()
        {
            Header();
            Console.Clear();
            Console.WriteLine("Please enter a ID to remove.");
            string iD = "";
            iD = Console.ReadLine();

            int iDINT = 0;
            iDINT = Int32.Parse(iD);

            Dictionary<int, Records> removeDictionary = new Dictionary<int, Records>();

            string input = "";
            string[] inputSplit = null;
            using (StreamReader sr = new StreamReader(Config.pathCollection))
            {
                while (!sr.EndOfStream)
                {
                    input = sr.ReadLine();
                    inputSplit = input.Split("|");
                    int lineID = int.Parse(inputSplit[0]);

                    if (inputSplit[0] != iD)
                    {
                        Records record = new Records(lineID, inputSplit[1], inputSplit[2], inputSplit[3], inputSplit[4], decimal.Parse(inputSplit[5]));
                        removeDictionary.Add(lineID, record);
                    }

                }
            }
            using (StreamWriter sw = new StreamWriter(Config.pathCollection, false))
            {
                foreach (KeyValuePair<int, Records> entry in removeDictionary)
                {
                    sw.WriteLine($"{entry.Key}|{entry.Value.Title}|{entry.Value.Artist}|{entry.Value.Released}|{entry.Value.Label}|{entry.Value.PricePaid}");
                }

            }

            Console.Clear();
            Console.WriteLine("Record Removed!");
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadKey();
            Console.Clear();
            Header();
            Menu.MenuList();

        }


        //Random selection to play
        public static void RandomPlay()
        {
            int keyCount = 0;
            Dictionary<int, Records> randomDictionary = new Dictionary<int, Records>();
            string input = "";
            string[] inputSplit = new string[6];

            using (StreamReader sr = new StreamReader(Config.pathCollection))
            {
                while (!sr.EndOfStream)
                {
                    input = sr.ReadLine();
                    inputSplit = input.Split("|");
                    Records record = new Records(int.Parse(inputSplit[0]), inputSplit[1], inputSplit[2], inputSplit[3], inputSplit[4], decimal.Parse(inputSplit[5]));
                    randomDictionary.Add(int.Parse(inputSplit[0]), record);
                    keyCount++;
                }
            }
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, keyCount);

            Console.WriteLine($"We randomly selected {randomDictionary[randomNumber].Title} by {randomDictionary[randomNumber].Artist} for you to listen to!");
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadKey();
            Console.Clear();
            Header();
            Menu.MenuList();



        }


        //Collection total value

        public static void CollectionValue()
        {
            decimal collectionValue = 0.00M;
            decimal highestPrice = 0.00M;
            string highestPriceTitle = "";
            string highestPriceArtist = "";
            int collectionCount = 0;
            decimal avgPrice = 0.00M;
            using (StreamReader sr = new StreamReader(Config.pathCollection))
            {
                while(!sr.EndOfStream)
                {
                    string[] line = new string[6];
                    line = sr.ReadLine().Split("|");
                    collectionValue += decimal.Parse(line[5]);

                    if (decimal.Parse(line[5]) > highestPrice)
                    {
                        highestPrice = decimal.Parse(line[5]);
                        highestPriceTitle = line[1];
                        highestPriceArtist = line[2];

                    }

                    collectionCount++;
                    avgPrice = collectionValue / collectionCount;
                }
            }
            Console.WriteLine($"Your collection is worth {collectionValue:C}!\n");
            Console.WriteLine($"Your collection has an average price of {avgPrice:C} \n");
            Console.WriteLine($"Your Highest priced record is: {highestPriceTitle} by {highestPriceArtist} at {highestPrice:C}\n");
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadKey();
            Console.Clear();
            Header();
            Menu.MenuList();
        }

        //Search
        public static void Search()
        {
            string input = "";
            Console.WriteLine("Please enter a search term:");
            input = Console.ReadLine().ToLower();
            bool found = false;

            using (StreamReader sr = new StreamReader(Config.pathCollection))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string lineSearchFormat = line.ToLower();
                    string lineOutputFormat = line.Replace("|","\t");
                    if (lineSearchFormat.Contains(input))
                    {
                        Console.WriteLine(lineOutputFormat);
                        found = true;

                    }
                }
            }
            if (!found)
            {
                Console.WriteLine($"Sorry, nothing found for the search key {input}!");
            }

            Console.WriteLine("");
            Console.WriteLine("Would you like to search again (Y/N)?");
            string searchAgain = Console.ReadLine().Trim('0', '1').ToLower();
            Console.WriteLine(searchAgain);
            Console.ReadKey();
            if (searchAgain == "y")
            {
                Console.Clear();
                Header();
                Search();
            }
            else if (searchAgain == "n")
            {
                Console.Clear();
                Header();
                Menu.MenuList();
            }
            else
            {
                Console.WriteLine("You did not enter a valid answer.  You are being taken back to the main menu.");
                Console.ReadKey();
                Console.Clear();
                Header();
                Menu.MenuList();
            }

        }
    }
}
