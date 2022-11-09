using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace FiveSpn.BioGen.Test.Server
{
    public class Service : BaseScript
    {
        public Service()
        {
            EventHandlers["FiveSPN-BioGen-RxName"] += new Action<string, string, string>(ClientRxName);
            EventHandlers["FiveSPN-BioGen-RxDob"] += new Action<string, string>(ClientRxDob);
            EventHandlers["FiveSPN-BioGen-RxAll"] += new Action<string, string, string, string, bool>(ClientRxAll);

            RunServerTest();
        }

        private async Task RunServerTest()
        {
            for (int i = 0; i < 10; i++)
            {
                TriggerEvent("FiveSPN-BioGen-TxName", API.GetCurrentResourceName(), true);
                TriggerEvent("FiveSPN-BioGen-TxName", API.GetCurrentResourceName(), false);
                TriggerEvent("FiveSPN-BioGen-TxDob", API.GetCurrentResourceName());
                TriggerEvent("FiveSPN-BioGen-TxDob", API.GetCurrentResourceName());
                TriggerEvent("FiveSPN-BioGen-TxProfile", API.GetCurrentResourceName(), true);
                TriggerEvent("FiveSPN-BioGen-TxProfile", API.GetCurrentResourceName(), false);
                await Delay(1000);
            }
        }
        
        private void ClientRxName(string target, string arg1, string arg2)
        {
            if (target != API.GetCurrentResourceName()) return;
            Debug.WriteLine("Received Name: "+arg1+" "+arg2);
        }

        private void ClientRxDob(string target, string dateString)
        {
            if (target != API.GetCurrentResourceName()) return;
            var date = DateTime.Parse(dateString);
            Debug.WriteLine("Received DOB: "+ date.Date.ToString("d"));
        }

        private void ClientRxAll(string target, string arg1, string arg2, string dateString, bool arg4)
        {
            if (target != API.GetCurrentResourceName()) return;
            var date = DateTime.Parse(dateString);
            Debug.WriteLine("Received All: "+ arg1 +" "+ arg2+" "+ date.Date.ToString("d") + " " + (arg4?"Male":"Female"));
        }
    }
}