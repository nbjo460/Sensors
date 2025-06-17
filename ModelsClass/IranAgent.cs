using Sensors.BaseModels;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Sensors.BaseModels
{
    internal class IranAgent
    {


        //private readonly IAgentSensorAttached _agentRepository;
        //private readonly IAgentRepository _agentRepository;
        //private readonly IAgentRepository _agentRepository;



        private static int id = 0;
        public int ID { get; private set; }
        public static string[] TypesOfRank { get; } = { "Foot Soldier", "Squad Leader", "Senior Commander", "Organaization" };
        public int MatchingSensor { get; private set; } = 0;
        public string Rank { get; private set; }
        public int CapacityOfSensors { get; private set; }

        public int SpecialPowerPossibility = 0;
        public int CounterTurns { get; private set; } = 0;
        private int MaxCounterAttackByRank = 0;
        private int SensorsRemove = 0;
        public const int MaxCounterAttack = 10;

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
            id += 1;
            ID = id;
            SetCapcityAndRank(_rank);
            InitialyzeParameters();
        }
        public IranAgent(int _id ,string _rank, int _turns)
        {
            ID = _id;
            SetCapcityAndRank(_rank);
            InitialyzeParameters();
            CounterTurns = _turns;
        }

        private void SetCapcityAndRank(string _rank)
        {
            if (!TypesOfRank.Contains(_rank)) throw new RankDoesNotExist(TypesOfRank, _rank);

            Rank = _rank;

            switch (_rank)
            {
                case "Foot Soldier":
                    CapacityOfSensors = 2;
                    MaxCounterAttackByRank = 0;
                    SensorsRemove = -1;
                    break;
                case "Squad Leader":
                    CapacityOfSensors = 4;
                    MaxCounterAttackByRank = 3;
                    SensorsRemove = 1;

                    break;
                case "Senior Commander":
                    CapacityOfSensors = 6;
                    MaxCounterAttackByRank = 3;
                    SensorsRemove = 2;
                    break;
                case "Organaization":
                    CapacityOfSensors = 8;
                    MaxCounterAttackByRank = 3;
                    SensorsRemove = 1;
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
        public bool AttachSensor(BaseSensor _sensor, int _location = -1)
        {
            //Game With Location
            if (_location >= 0)
            {
                if (_location > CapacityOfSensors)
                    throw new LocationNotInRange(_location, CapacityOfSensors - 1);

                else
                    AttachedSensors[_location - 1] = _sensor;
                EnabledByLocation[_location - 1] = true ? RequierdTypesOfSensors[_location - 1] == _sensor.Name : false;
                return EnabledByLocation[_location - 1];
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
                        return true;
                    }
                }
            }
            return false;
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
        public string SuccssedMatchingString(int count)
        {
            return $"You succssed {count} / {CapacityOfSensors}";
        }
        public override string ToString()
        {
            return $"The Rank is: {Rank}. {SuccssedMatchingString(CountMatchingSensor())}";
        }
        public void DeleteSpecificlySensor (BaseSensor _sensor)
        {
            for(int i = 0; i < AttachedSensors.Count(); i++)
            {
                if (AttachedSensors[i].Equals(_sensor))
                {
                    AttachedSensors[i] = null;
                    EnabledByLocation[i] = false;
                    Console.WriteLine(_sensor.Name + " Was DELETED");
                    break;
                }
            }
        }
        private void DeleteSensorsByNum(int num)
        {
            int countDeleted = 0;
            for (int i = 0; i < CapacityOfSensors; i++)
            {
                if (countDeleted == num) return;
                if (AttachedSensors[i] != null)
                {
                    Console.WriteLine(AttachedSensors[i].Name + " Was DELETED");
                    AttachedSensors[i] = null;
                    EnabledByLocation[i] = false;
                    countDeleted++;
                }
            }
        }
        public void SpecialPower(bool _attached)
        {
            if (!_attached)
            {
                CounterTurns++;
                if (SpecialPowerPossibility >= 0)
                {
                    if (CounterTurns % 10 == 0)
                    {
                        DeleteSensorsByNum(CapacityOfSensors);
                        Console.WriteLine("Each 10 turns. Your's all Sensors delete!\nLike Now LOLLL");
                    }
                    else if (SensorsRemove == -1)
                    {
                        return;
                    }
                    else if (CounterTurns % MaxCounterAttackByRank == 0)
                    {
                        DeleteSensorsByNum(SensorsRemove);
                        Console.WriteLine($"Each {MaxCounterAttackByRank} turns. {SensorsRemove} Sensors are delete!\nLike Now LOLLL");

                    }
                }
                else
                {
                    if (CounterTurns % 10 == 0 || CounterTurns % MaxCounterAttackByRank == 0)
                        SpecialPowerPossibility++;
                }
            }
        }



    }
}
