using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace FiveSpn.BioGen.Test.Client
{
    public class Service : BaseScript
    {
        public Service()
        {
            EventHandlers["FiveSPN-BioGen-ClientGetName"] += new Action<string, string>(ClientRxName);
            EventHandlers["FiveSPN-BioGen-ClientGetDob"] += new Action<string>(ClientRxDob);
            EventHandlers["FiveSPN-BioGen-ClientGetAll"] += new Action<string, string, string, bool>(ClientRxAll);

            API.RegisterCommand("getbios", new Action<int, List<object>, string>((source, args, raw) =>
            {
                Debug.WriteLine("Testing BioGen");
                for (int i = 0; i < 10; i++)
                {
                    TriggerServerEvent("FiveSPN-BioGen-ClientGetName", true);
                    TriggerServerEvent("FiveSPN-BioGen-ClientGetName", false);
                    TriggerServerEvent("FiveSPN-BioGen-ClientGetDob");
                    TriggerServerEvent("FiveSPN-BioGen-ClientGetDob");
                    TriggerServerEvent("FiveSPN-BioGen-ClientGetAll", true);
                    TriggerServerEvent("FiveSPN-BioGen-ClientGetAll", false);
                    Delay(1000);
                }
            }),false);
        }

        private void ClientRxName(string arg1, string arg2)
        {
            Debug.WriteLine("Received Name: "+arg1+" "+arg2);
        }

        private void ClientRxDob(string dateString)
        {
            DateTime date = DateTime.Parse(dateString);
            Debug.WriteLine("Received DOB: "+ date.Date.ToString("d"));
        }

        private void ClientRxAll(string arg1, string arg2, string dateString, bool arg4)
        {
            DateTime date = DateTime.Parse(dateString);
            Debug.WriteLine("Received All: "+ arg1 +" "+ arg2+" "+date.Date.ToString("d") + " " +(arg4?"Male":"Female"));
        }
    }
}