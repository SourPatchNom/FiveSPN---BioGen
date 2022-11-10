using System;

namespace FiveSpn.BioGen.Server.Classes
{
    public class GlobalRandom
    {
        private static readonly GlobalRandom instance = new GlobalRandom();

        static GlobalRandom()
        {
            
        }

        private GlobalRandom()
        {
            
        }

        public static GlobalRandom Instance
        {
            get { return instance; }
        }

        private static Random _random = new Random();

        public static int GetRandomNumberInRange(int start, int end)
        {
            return _random.Next(start, end);
        }
    }
}