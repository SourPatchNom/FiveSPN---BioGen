using System;

namespace FiveSpn.BioGen.Server.Classes
{
    /// <summary>
    /// Generates a thread save random instance. Credits to Nick Chapsas - https://www.youtube.com/watch?v=WRB4OHpSXHs (If you C#, you should check him out!)
    /// </summary>
    public static class ConcurrentRandom
    {
        [ThreadStatic] 
        private static Random? _local;

        private static Random Instance => _local ??= new Random();
        
        public static int GetRandomNumberInRange(int start, int end)
        {
            return Instance.Next(start, end);
        }
    }
}