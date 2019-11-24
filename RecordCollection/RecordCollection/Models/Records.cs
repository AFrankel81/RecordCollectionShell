using System;
using System.Collections.Generic;
using System.Text;

namespace RecordCollection.Models
{
    public class Records
    {
        public Records(int iD, string title, string artist, string released, string label, decimal pricePaid)
        {
            this.Title = title;
            this.Artist = artist;
            this.Released = released;
            this.Label = label;
            this.PricePaid = pricePaid;
        }

        public string Title { get; set; }
        public string Artist { get; set; }
        public string Released { get; set; }
        public string Label { get; set; }
        public decimal PricePaid { get; set; } 

    }

}
