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
            if (!NameGenerator.PopulateOptions(out string getNamesResult))
            {
                TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 0,getNamesResult);
                return;
            }
            TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(), NameGenerator.GetVariationsStringA());    
            TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(), NameGenerator.GetVariationsStringB());
            EventHandlers["FiveSPN-BioGen-GetName"] += new Action<Player, bool>(ClientGetName);
            EventHandlers["FiveSPN-BioGen-GetDob"] += new Action<Player>(ClientGetDob);
            EventHandlers["FiveSPN-BioGen-GetProfile"] += new Action<Player, bool>(ClientGetProfile);
        }
        
        private static void ClientGetName([FromSource] Player player, bool masculine)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-GetName", NameGenerator.GetFirstName(masculine), NameGenerator.GetSurname());
        }
        
        private void ClientGetDob([FromSource] Player player)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-GetDob", BirthdayGenerator.GetRandomAdultBirthday());
        }
        
        private void ClientGetProfile([FromSource] Player player, bool masculine)
        {
            throw new NotImplementedException();
        }




    }
}