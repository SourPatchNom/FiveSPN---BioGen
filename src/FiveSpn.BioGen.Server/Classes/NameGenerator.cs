using System;
using System.Collections.Generic;
using System.IO;
using CitizenFX.Core.Native;
using Newtonsoft.Json;

namespace FiveSpn.BioGen.Server.Classes
{
    public class NameGenerator
    {
        private static readonly Lazy<NameGenerator> instance = new Lazy<NameGenerator>(() => new NameGenerator());
        private NameGenerator(){}
        public static NameGenerator Instance => instance.Value;
        
        
        private List<String> _femaleFirstNames;
        private int _femaleFirstNameCount = 0;
        private List<String> _maleFirstNames;
        private int _maleFirstNameCount = 0;
        private List<String> _surNames;
        private int _surNameCount = 0;

        public bool PopulateOptions(out string result)
        {
            try
            {
                var nameDirectory = API.GetResourcePath(API.GetCurrentResourceName()) + "/Names/";
                if (!Directory.Exists(nameDirectory))
                {
                    result = "Cannot locate Names directory!";
                    return false;
                }
                string femaleFile = "names_f_" + ConcurrentRandom.GetRandomNumberInRange(0, 9) + ".json";
                string maleFile = "names_m_" + ConcurrentRandom.GetRandomNumberInRange(0, 9) + ".json";
                string surFile = "names_s_" + ConcurrentRandom.GetRandomNumberInRange(0, 9) + ".json";
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

        public string GetFirstName(bool male)
        {
            if (male)
            {
                if (_maleFirstNameCount != 0)
                {
                    return _maleFirstNames[ConcurrentRandom.GetRandomNumberInRange(0, _maleFirstNameCount-1)];
                }
            }
            else
            {
                if (_femaleFirstNameCount != 0)
                {
                    return _femaleFirstNames[ConcurrentRandom.GetRandomNumberInRange(0, _femaleFirstNameCount-1)];
                }
            }
            return male ? "John" : "Jane";
        }

        public string GetSurname()
        {
            if (_surNameCount != 0)
            {
                return _surNames[ConcurrentRandom.GetRandomNumberInRange(0, _surNameCount-1)];
            }
            return "Doe";
        }

        public string GetVariationsStringA()
        {
            return "There are a total of " + _femaleFirstNameCount + " feminine names, " + _maleFirstNameCount + " masculine names, and " + _surNameCount + " last names available for this session!";
        }
        
        public string GetVariationsStringB()
        {
            return "There are a total of " + (_femaleFirstNameCount * _surNameCount) + " feminine name combinations and " + (_maleFirstNameCount * _surNameCount) + " masculine name combinations available for this session!";
        }
    }
}