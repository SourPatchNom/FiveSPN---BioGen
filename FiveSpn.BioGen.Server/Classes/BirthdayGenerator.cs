using System;
using FiveSpnAiInteractServer.Classes;

namespace FiveSpn.BioGen.Server.Classes
{
    public static class AiRandomBirthdayGenerator
    {
        public static DateTime GetRandomAdultBirthday()
        {
            DateTime old = new DateTime(DateTime.UtcNow.Year - 65, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            DateTime young = new DateTime(DateTime.UtcNow.Year - 18, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            int maxDaysToAdd = (DateTime.Today - old).Days - (DateTime.Today - young).Days;
            return old.AddDays(GlobalRandom.GetRandomNumberInRange(0, maxDaysToAdd));
        }
        
    }
}