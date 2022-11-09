using System;
using System.Globalization;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using FiveSpn.BioGen.Server.Classes;

namespace FiveSpn.BioGen.Server
{
    public class Service : BaseScript
    {
        private readonly bool _discordLogging;
        private readonly bool _verboseLogging;
        
        public Service()
        {
            _discordLogging = API.GetResourceMetadata(API.GetCurrentResourceName(), "discord_share", 0) == "true";
            _verboseLogging = API.GetResourceMetadata(API.GetCurrentResourceName(), "verbose_logs", 0) == "true";
            
            TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(),3,"Initializing!");
            
            if (_discordLogging) TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(),"The Bio Generator is booting.");
            if (!NameGenerator.Instance.PopulateOptions(out string getNamesResult))
            {
                TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 0,getNamesResult);
                return;
            }
            if (_discordLogging) TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(), NameGenerator.Instance.GetVariationsStringA());    
            if (_discordLogging) TriggerEvent("FiveSPN-LogToDiscord", true, API.GetCurrentResourceName(), NameGenerator.Instance.GetVariationsStringB());
            
            EventHandlers["FiveSPN-BioGen-ClientGetName"] += new Action<Player, bool>(ClientGetName);
            EventHandlers["FiveSPN-BioGen-ClientGetDob"] += new Action<Player>(ClientGetDob);
            EventHandlers["FiveSPN-BioGen-ClientGetAll"] += new Action<Player, bool>(ClientGetAll);
            
            EventHandlers["FiveSPN-BioGen-TxName"] += new Action<string, bool>(ServerGetName);
            EventHandlers["FiveSPN-BioGen-TxDob"] += new Action<string>(ServerGetDob);
            EventHandlers["FiveSPN-BioGen-TxProfile"] += new Action<string, bool>(ServerGetAll);
        }
        
        private void ClientGetName([FromSource] Player player, bool masculine)
        {
            if (_verboseLogging) TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 5, player.Name + " requested a new name!");
            TriggerClientEvent(player, "FiveSPN-BioGen-ClientGetName", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname());
        }
        
        private void ClientGetDob([FromSource] Player player)
        {
            if (_verboseLogging) TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 5, player.Name + " requested a new dob!");
            TriggerClientEvent(player, "FiveSPN-BioGen-ClientGetDob", BirthdayGenerator.GetRandomAdultBirthday().ToString(CultureInfo.CurrentCulture));
        }
        
        private void ClientGetAll([FromSource] Player player, bool masculine)
        {
            if (_verboseLogging) TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 5, player.Name + " requested a new profile!");
            TriggerClientEvent(player, "FiveSPN-BioGen-ClientGetAll", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname(), BirthdayGenerator.GetRandomAdultBirthday().ToString(CultureInfo.CurrentCulture), masculine);
        }
        
        private void ServerGetName(string source, bool masculine)
        {
            if (_verboseLogging) TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 5, source + " requested a new name!");
            TriggerEvent("FiveSPN-BioGen-RxName", source, NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname());
        }
        
        private void ServerGetDob(string source)
        {
            if (_verboseLogging) TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 5, source + " requested a new dob!");
            TriggerEvent( "FiveSPN-BioGen-RxDob", source, BirthdayGenerator.GetRandomAdultBirthday().ToString(CultureInfo.CurrentCulture));
        }
        
        private void ServerGetAll(string source, bool masculine)
        {
            if (_verboseLogging) TriggerEvent("FiveSPN-LogToServer", API.GetCurrentResourceName(), 5, source + " requested a new profile!");
            TriggerEvent("FiveSPN-BioGen-RxAll", source, NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname(), BirthdayGenerator.GetRandomAdultBirthday().ToString(CultureInfo.CurrentCulture), masculine);
        }



    }
}