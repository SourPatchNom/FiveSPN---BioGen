using System;

namespace FiveSpn.BioGen.Library.Classes
{
    public class GeneratedProfile
    {
        public string FirstName;
        public string LastName;
        public bool Gender;
        public DateTime Birthday;
        public int VehicleNetId;
        public DateTime VehicleRegistrationExpiration;
        public DateTime VehicleInsuranceExpiration;

        // public GeneratedProfile(bool gender)
        // {
        //     FirstName = AiRandomNameManager.GetAiFirstName(gender);
        //     LastName = AiRandomNameManager.GetAiSurname();
        //     Gender = gender;
        //     Birthday = AiRandomBirthdayGenerator.GetRandomAdultBirthday();
        //     VehicleNetId = -1;
        //     VehicleRegistrationExpiration = DateTime.UtcNow;
        //     VehicleInsuranceExpiration = DateTime.UtcNow;
        // }
        //
        // public GeneratedProfile(bool gender, int vehicleNetId)
        // {
        //     FirstName = AiRandomNameManager.GetAiFirstName(gender);
        //     LastName = AiRandomNameManager.GetAiSurname();
        //     Gender = gender;
        //     Birthday = AiRandomBirthdayGenerator.GetRandomAdultBirthday();
        //     VehicleNetId = vehicleNetId;
        //     GenerateExpirationDates();
        // }
        //
        // private void GenerateExpirationDates()
        // {
        //     //Registration
        //     DateTime registrationExpiration = DateTime.UtcNow;
        //     if (GlobalRandom.GetRandomNumberInRange(0, 100) < 5)
        //     {
        //         int year = GlobalRandom.GetRandomNumberInRange(0, 2);
        //         int month = GlobalRandom.GetRandomNumberInRange(1, 12);
        //         if (year == 0 && registrationExpiration.Month <= month) year++;
        //         year = registrationExpiration.Year - year;
        //         int day = GlobalRandom.GetRandomNumberInRange(1, DateTime.DaysInMonth(year, month));
        //         registrationExpiration = new DateTime(year, month, day);
        //     }
        //     else
        //     {
        //         registrationExpiration = registrationExpiration.AddDays(GlobalRandom.GetRandomNumberInRange(30, 750));
        //     }
        //     VehicleRegistrationExpiration = registrationExpiration;
        //     
        //     //Insurance
        //     DateTime insuranceExpiration = DateTime.UtcNow;
        //     if (GlobalRandom.GetRandomNumberInRange(0, 100) < 12)
        //     {
        //         int year = GlobalRandom.GetRandomNumberInRange(0, 2);
        //         int month = GlobalRandom.GetRandomNumberInRange(1, 12);
        //         if (year == 0 && insuranceExpiration.Month <= month) year++;
        //         year = insuranceExpiration.Year - year;
        //         int day = GlobalRandom.GetRandomNumberInRange(1, DateTime.DaysInMonth(year, month));
        //         insuranceExpiration = new DateTime(year, month, day);
        //     }
        //     else
        //     {
        //         insuranceExpiration = insuranceExpiration.AddDays(GlobalRandom.GetRandomNumberInRange(30, 365));    
        //     }
        //     VehicleInsuranceExpiration = insuranceExpiration;
        // }
        //
        // public string SerializeJson()
        // {
        //     return JsonConvert.SerializeObject(this);
        // }
    }
}