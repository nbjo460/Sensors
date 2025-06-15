using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Models
{
    internal class IranAgent
    {
        private static string[] TypesOfRank = {"Foot Soldier" , "Squad Leader" , "Senior Commander", "Organaization" };

        public string Rank { get; private set;}
        int CapacityOfSensors;
        
        BaseSensor[] AttacedSensors;
        bool[] EnabledByLocation;
        string[] RequierdTypesOfSensors;

        public IranAgent(string _rank,string[] _requierdTypesOfSensors)
        {

            SetCapcityAndRank(_rank);
            InitialyzeParameters();
            RequierdTypesOfSensors = _requierdTypesOfSensors;

        }
        private void SetCapcityAndRank(string _rank)
        {
            if (!TypesOfRank.Contains(_rank)) return;
            Rank = _rank;

            switch (_rank)
            {
                case "Foot Soldier":
                    CapacityOfSensors = 2;
                    break;
                case "Squad Leader":
                    CapacityOfSensors = 4;
                    break;
                case "Senior Commander":
                    CapacityOfSensors = 6;
                    break;
                case "Organaization":
                    CapacityOfSensors = 8;
                    break;
            }
        }
        private void InitialyzeParameters()
        {
            AttacedSensors = new BaseSensor[CapacityOfSensors];
            EnabledByLocation = new bool[CapacityOfSensors];
            for (int i = 0; i < CapacityOfSensors; i++)
            {
                EnabledByLocation[i] = false;
            }
            
        }
    }
}
