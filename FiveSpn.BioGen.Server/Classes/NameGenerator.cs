using System;
using System.Collections.Generic;
using System.IO;
using CitizenFX.Core.Native;
using FiveSpnAiInteractServer.Classes;
using Newtonsoft.Json;

namespace FiveSpn.BioGen.Server.Classes
{
    public static class NameManager
    {
        private static List<String> _femaleFirstNames;
        private static int _femaleFirstNameCount = 0;
        private static List<String> _maleFirstNames;
        private static int _maleFirstNameCount = 0;
        private static List<String> _surNames;
        private static int _surNameCount = 0;

        public static void GenerateNameLists()
        {
            try
            {
                string resourceDirectory = API.GetResourcePath(API.GetCurrentResourceName());
                _femaleFirstNames = JsonConvert.DeserializeObject<List<String>>(File.ReadAllText(resourceDirectory + "/Names/names_f_" + GlobalRandom.GetRandomNumberInRange(0, 9) + ".json"));
                if (_femaleFirstNames != null) _femaleFirstNameCount = _femaleFirstNames.Count;
                _maleFirstNames = JsonConvert.DeserializeObject<List<String> >(File.ReadAllText(resourceDirectory + "/Names/names_m_" + GlobalRandom.GetRandomNumberInRange(0, 9) + ".json"));
                if (_maleFirstNames != null) _maleFirstNameCount = _maleFirstNames.Count;
                _surNames = JsonConvert.DeserializeObject<List<String> >(File.ReadAllText(resourceDirectory + "/Names/names_s_" + GlobalRandom.GetRandomNumberInRange(0, 9) + ".json"));
                if (_surNames != null) _surNameCount = _surNames.Count;
                
                Console.WriteLine("FiveSPN-AiInteract: Today's random names are loading!");
                Console.WriteLine("FiveSPN-AiInteract: Total female names loaded = " + _femaleFirstNameCount);
                Console.WriteLine("FiveSPN-AiInteract: Total male names loaded = " + _maleFirstNameCount);
                Console.WriteLine("FiveSPN-AiInteract: Total last names loaded = " + _surNameCount);
                Console.WriteLine("FiveSPN-AiInteract: Total female possibilities = " + (long)_femaleFirstNameCount * (long)_surNameCount);
                Console.WriteLine("FiveSPN-AiInteract: Total male possibilities = " + (long)_maleFirstNameCount * (long)_surNameCount);
                Console.WriteLine("FiveSPN-AiInteract: Name generation complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string GetAiFirstName(bool male)
        {
            if (male)
            {
                if (_maleFirstNameCount != 0)
                {
                    return _maleFirstNames[GlobalRandom.GetRandomNumberInRange(0, _maleFirstNameCount-1)];
                }
            }
            else
            {
                if (_femaleFirstNameCount != 0)
                {
                    return _femaleFirstNames[GlobalRandom.GetRandomNumberInRange(0, _femaleFirstNameCount-1)];
                }
            }
            return male ? "John" : "Jane";
        }

        public static string GetAiSurname()
        {
            if (_surNameCount != 0)
            {
                return _surNames[GlobalRandom.GetRandomNumberInRange(0, _surNameCount-1)];
            }
            return "Doe";
        }
    }
}