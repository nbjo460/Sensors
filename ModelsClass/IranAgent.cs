using Sensors.BaseModels;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Sensors.BaseModels
{
    internal class IranAgent
    {
        public static string[] TypesOfRank { get; } = { "Foot Soldier", "Squad Leader", "Senior Commander", "Organaization" };
        public int MatchingSensor { get; private set; } = 0;
        public string Rank { get; private set; }
        public int CapacityOfSensors { get; private set; }

        BaseSensor[] AttachedSensors;
        bool[] EnabledByLocation;
        private string[] requierdTypesOfSensors = null;
        public string[] RequierdTypesOfSensors
        {
            get { return requierdTypesOfSensors; }
            set
            {
                if (requierdTypesOfSensors == null) requierdTypesOfSensors = value;
            }
        }
        public bool IsHiding
        {
            get
            {
                foreach (bool location in EnabledByLocation)
                {
                    if (!location) return true;
                }
                return false;
            }
        }

        public IranAgent(string _rank)
        {
            SetCapcityAndRank(_rank);
            InitialyzeParameters();
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
                    throw new LocationNotInRange(_location, CapacityOfSensors - 1);

                else
                    AttachedSensors[_location - 1] = _sensor;
                EnabledByLocation[_location - 1] = true ? RequierdTypesOfSensors[_location - 1] == _sensor.Name : false;
            }
            //Game without Location
            else
            {
                for (int i = 0; i < CapacityOfSensors; i++)
                {
                    if (!EnabledByLocation[i] && RequierdTypesOfSensors[i] == _sensor.Name)
                    {
                        AttachedSensors[i] = _sensor;
                        EnabledByLocation[i] = true;

                        Console.WriteLine(string.Join(", ",RequierdTypesOfSensors));

                        break;
                    }
                }
            }
        }
        public int CountMatchingSensor()
        {
            int count = 0;
            foreach (bool matching in EnabledByLocation)
            {
                if (matching) count++;
            }
            MatchingSensor = count;
            return count;
        }
        public string MatchingSensorString(int count)
        {
            return $"You succssed {count} / {CapacityOfSensors}";
        }
        public override string ToString()
        {
            return $"The Rank is: {Rank}. {MatchingSensorString(CountMatchingSensor())}";
        }
        public void DeleteSensor (BaseSensor _sensor)
        {
            for(int i = 0; i < AttachedSensors.Count(); i++)
            {
                if (AttachedSensors[i].Equals(_sensor))
                {
                    AttachedSensors[i] = null;
                    EnabledByLocation[i] = false;
                    Console.WriteLine(_sensor + "Was DELETED");
                    break;
                }
            }
        }
    }
}
