using System;
using System.Collections.Generic;
using System.Text;

namespace RecordCollection.Models
{
    public class Config
    {
        public static string firstName
            {
                get
                {
                    return "Alex";
                }
            }

        public static string pathCollection
        {
            get
            {
                return @"C:\Users\AFrankel\Desktop\Discogs Local\RecordCollection\RecordCollection\Data\collection.txt";
            }
        }

        public static string pathWishList
        {
            get
            {
                return @"C:\Users\AFrankel\Desktop\Discogs Local\RecordCollection\RecordCollection\Data\wishlist.txt";
            }
        }

        public static string pathSearch
        {
            get
            {
                return @"C:\Users\AFrankel\Desktop\Discogs Local\RecordCollection\RecordCollection\Data\searchresults.txt";
            }
        }
    }
}
