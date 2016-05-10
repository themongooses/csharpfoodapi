using System;

namespace GroupProject545
{

    public class Menu
    {
        public DateTime date { get; set; }
        public int id { get; set; }
        public Recipe[] recipes { get; set; }
        public string time_of_day { get; set; }
    }
}