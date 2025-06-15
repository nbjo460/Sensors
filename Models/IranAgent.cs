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
        public int CapacityOfSensors { get; private set; }
        
        BaseSensor[] AttachedSensors;
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
            if (!TypesOfRank.Contains(_rank)) throw new RankDoesNotExist(TypesOfRank, _rank);
            
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
            AttachedSensors = new BaseSensor[CapacityOfSensors];
            EnabledByLocation = new bool[CapacityOfSensors];
            for (int i = 0; i < CapacityOfSensors; i++)
            {
                EnabledByLocation[i] = false;
            }
            
        }

        public void AttachSensor(BaseSensor _sensor, int _location = -1)
        {
            //Game With Location
            if (_location >= 0)
            {
                if (_location > CapacityOfSensors)
                    throw new LocationNotInRange(_location, CapacityOfSensors -1);

                else
                    AttachedSensors[_location - 1] = _sensor;
                EnabledByLocation[_location - 1] = true ? RequierdTypesOfSensors.Contains(_sensor.Name) : false;
            }
            //Game without Location
            else
            {
                for (int i = 0; i < CapacityOfSensors; i++)
                {
                    if (!EnabledByLocation[i])
                    {
                        AttachedSensors[i] = _sensor;
                        EnabledByLocation[i] = true ? TypesOfRank.Contains(_sensor.Name) : false;
                    }
                }
            }
        }

    }
}
