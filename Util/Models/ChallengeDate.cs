namespace adventofcode.Util.Models
{
    class ChallengeDate
    {
        public int Year { get; set; }
        public int Day { get; set; }

        public override string ToString()
        {
            return $"Year {Year} - Day #{Day}";
        }
    }
}
