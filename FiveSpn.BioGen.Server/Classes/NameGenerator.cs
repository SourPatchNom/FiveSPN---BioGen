using System;
using System.Collections.Generic;
using System.IO;
using CitizenFX.Core.Native;
using FiveSpnAiInteractServer.Classes;
using Newtonsoft.Json;

namespace FiveSpn.BioGen.Server.Classes
{
    public static class NameGenerator
    {
        private static List<String> _femaleFirstNames;
        private static int _femaleFirstNameCount = 0;
        private static List<String> _maleFirstNames;
        private static int _maleFirstNameCount = 0;
        private static List<String> _surNames;
        private static int _surNameCount = 0;

        public static bool PopulateOptions(out string result)
        {
            try
            {
                var nameDirectory = API.GetResourcePath(API.GetCurrentResourceName()) + "/Names/";
                if (!Directory.Exists(nameDirectory))
                {
                    result = "Cannot locate Names directory!";
                    return false;
                }
                string femaleFile = "names_f_" + GlobalRandom.GetRandomNumberInRange(0, 9) + ".json";
                string maleFile = "names_m_" + GlobalRandom.GetRandomNumberInRange(0, 9) + ".json";
                string surFile = "names_s_" + GlobalRandom.GetRandomNumberInRange(0, 9) + ".json";
                if (!File.Exists(nameDirectory + femaleFile) || !File.Exists(nameDirectory + maleFile) || !File.Exists(nameDirectory + surFile))
                {
                    if (!File.Exists(nameDirectory + femaleFile))
                    {
                        result = "Cannot locate name file:"+ nameDirectory + femaleFile;
                        return false;
                    }
                    if (!File.Exists(nameDirectory + maleFile))
                    {
                        result = "Cannot locate name file:"+ nameDirectory + maleFile;
                        return false;
                    }
                    if (!File.Exists(nameDirectory + surFile))
                    {
                        result = "Cannot locate name file:"+ nameDirectory + surFile;
                        return false;
                    }
                }
                _femaleFirstNames = JsonConvert.DeserializeObject<List<String>>(File.ReadAllText(nameDirectory + femaleFile));
                if (_femaleFirstNames != null) _femaleFirstNameCount = _femaleFirstNames.Count;
                _maleFirstNames = JsonConvert.DeserializeObject<List<String> >(File.ReadAllText(nameDirectory + maleFile));
                if (_maleFirstNames != null) _maleFirstNameCount = _maleFirstNames.Count;
                _surNames = JsonConvert.DeserializeObject<List<String> >(File.ReadAllText(nameDirectory + surFile));
                if (_surNames != null) _surNameCount = _surNames.Count;
                result = "Success";
                return true;
            }
            catch (Exception e)
            {
                result = "Critical error attempting to get names!\n"+e.Message;
                return false;
            }
        }

        public static string GetFirstName(bool male)
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

        public static string GetSurname()
        {
            if (_surNameCount != 0)
            {
                return _surNames[GlobalRandom.GetRandomNumberInRange(0, _surNameCount-1)];
            }
            return "Doe";
        }

        public static string GetVariationsStringA()
        {
            return "There are a total of " + _femaleFirstNameCount + " feminine names, " + _maleFirstNameCount + " masculine names, and " + _surNameCount + " last names available for this session!";
        }
        
        public static string GetVariationsStringB()
        {
            return "There are a total of " + (_femaleFirstNameCount * _surNameCount) + " feminine name combinations and " + (_maleFirstNameCount * _surNameCount) + " masculine name combinations available for this session!";
        }
    }
}