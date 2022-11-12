using System;

namespace FiveSpn.BioGen.Server.Classes
{
    public static class BirthdayGenerator
    {
        public static DateTime GetRandomAdultBirthday()
        {
            var utcNow = DateTime.UtcNow;
            var old = new DateTime(utcNow.Year - 65, utcNow.Month, utcNow.Day);
            var young = new DateTime(utcNow.Year - 18, utcNow.Month, utcNow.Day);
            var maxDaysToAdd = (utcNow.Date - old).Days - (utcNow.Date - young).Days;
            return old.AddDays(ConcurrentRandom.GetRandomNumberInRange(0, maxDaysToAdd));
        }
        
    }
}