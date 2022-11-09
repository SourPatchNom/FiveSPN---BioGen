using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using FiveSpn.BioGen.Server.Classes;

namespace FiveSpn.BioGen.Server
{
    public class Service : BaseScript
    {
        public Service()
        {
            TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(),3,"Initializing!");
            
            TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(),"The Bio Generator is booting.");
            if (!NameGenerator.Instance.PopulateOptions(out string getNamesResult))
            {
                TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 0,getNamesResult);
                return;
            }
            TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(), NameGenerator.Instance.GetVariationsStringA());    
            TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(), NameGenerator.Instance.GetVariationsStringB());
            
            EventHandlers["FiveSPN-BioGen-GetName"] += new Action<Player, bool>(ClientGetName);
            EventHandlers["FiveSPN-BioGen-GetDob"] += new Action<Player>(ClientGetDob);
            EventHandlers["FiveSPN-BioGen-GetProfile"] += new Action<Player, bool>(ClientGetProfile);
        }
        
        private static void ClientGetName([FromSource] Player player, bool masculine)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-GetName", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname());
        }
        
        private void ClientGetDob([FromSource] Player player)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-GetDob", BirthdayGenerator.GetRandomAdultBirthday());
        }
        
        private void ClientGetProfile([FromSource] Player player, bool masculine)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-GetName", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname(), BirthdayGenerator.GetRandomAdultBirthday(), masculine);
        }




    }
}