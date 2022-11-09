using System;
using System.Globalization;
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
            
            EventHandlers["FiveSPN-BioGen-ClientGetName"] += new Action<Player, bool>(ClientGetName);
            EventHandlers["FiveSPN-BioGen-ClientGetDob"] += new Action<Player>(ClientGetDob);
            EventHandlers["FiveSPN-BioGen-ClientGetAll"] += new Action<Player, bool>(ClientGetAll);
            
            EventHandlers["FiveSPN-BioGen-TxName"] += new Action<bool>(ServerGetName);
            EventHandlers["FiveSPN-BioGen-TxDob"] += new Action(ServerGetDob);
            EventHandlers["FiveSPN-BioGen-TxProfile"] += new Action<bool>(ServerGetAll);
        }
        
        private static void ClientGetName([FromSource] Player player, bool masculine)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-ClientGetName", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname());
        }
        
        private void ClientGetDob([FromSource] Player player)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-ClientGetDob", BirthdayGenerator.GetRandomAdultBirthday().ToString(CultureInfo.CurrentCulture));
        }
        
        private void ClientGetAll([FromSource] Player player, bool masculine)
        {
            TriggerClientEvent(player, "FiveSPN-BioGen-ClientGetAll", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname(), BirthdayGenerator.GetRandomAdultBirthday().ToString(CultureInfo.CurrentCulture), masculine);
        }
        
        private static void ServerGetName(bool masculine)
        {
            TriggerEvent("FiveSPN-BioGen-RxName", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname());
        }
        
        private void ServerGetDob()
        {
            TriggerEvent( "FiveSPN-BioGen-RxDob", BirthdayGenerator.GetRandomAdultBirthday());
        }
        
        private void ServerGetAll(bool masculine)
        {
            TriggerEvent("FiveSPN-BioGen-RxName", NameGenerator.Instance.GetFirstName(masculine), NameGenerator.Instance.GetSurname(), BirthdayGenerator.GetRandomAdultBirthday(), masculine);
        }



    }
}