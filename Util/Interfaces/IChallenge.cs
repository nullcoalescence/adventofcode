namespace adventofcode.Util.Interfaces
{
    internal interface IChallenge
    {
        public int Year { get; }
        public int Day { get; }
        public void Run();
    }
}
