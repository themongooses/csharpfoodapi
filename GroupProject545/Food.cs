namespace GroupProject545
{
    public class Food
    {
        public int fk_nfact_id { get; set; }
        public int food_id { get; set; }
        public string food_name { get; set; }
        public bool in_fridge { get; set; }
        public Nutrition nutrition { get; set; }
    }
}