using Sensors.BaseModels;
using Sensors.ModelsClass;
using Sensors.UI;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Sensors.BaseModels
{
    public class IranAgent
    {

        public readonly IAgentSensorAttached attachedSensor = new AgentSensorAttached();

   //private readonly IAgentTurn agentTurn;
        public void SpecialPower(bool _attached)
        {
            ChangeWeakness();
            if (!_attached)
            {
                CounterTurns++;
                if (SpecialPowerPossibility >= 0)
                {
                    if (CounterTurns % 10 == 0)
                    {
                        attachedSensor.DeleteSensorsByNum(attachedSensor.CapacityOfSensors);
                        Print.PrintUnderInvestigator("Each 10 turns. Your's all Sensors delete!\nLike Now LOLLL");
                    }
                    else if (SensorsRemove == -1)
                    {
                        return;
                    }
                    else if (CounterTurns % MaxCounterAttackByRank == 0)
                    {
                        attachedSensor.DeleteSensorsByNum(SensorsRemove);
                        Print.PrintUnderInvestigator($"Each {MaxCounterAttackByRank} turns. {SensorsRemove} Sensors are delete!\nLike Now LOLLL");

                    }
                }
                else
                {
                    if (CounterTurns % 10 == 0 || CounterTurns % MaxCounterAttackByRank == 0)
                        SpecialPowerPossibility++;
                }
            }
        }
        private void ChangeWeakness()
        {
            Random rnd = new Random();
            if (CounterTurns > 0 && CounterTurns % 5 == 0)
            {
                int indexWeakness = rnd.Next(0, attachedSensor.CapacityOfSensors);
                int newWeakness = rnd.Next(0, BaseSensor.TypesOfSensors.Length);
                attachedSensor.RequierdTypesOfSensors[indexWeakness] = BaseSensor.TypesOfSensors[newWeakness];
                Print.PrintUnderInvestigator("I changed my weakness.");
            }

        }
        public void AgentTurn(bool _attached)
        {
            string results = SuccssedMatchingString(attachedSensor.CountMatchingSensor());
            Print.PrintUnderInvestigator(results);
            SpecialPower(_attached);
        }
        public int SpecialPowerPossibility = 0;
        private int MaxCounterAttackByRank = 0;
        public int CounterTurns { get; private set; } = 0;
        public const int MaxCounterAttack = 10;



        private static int id = 0;
        public int ID { get; private set; }
        public static string[] TypesOfRank { get; } =
            { "Foot Soldier", "Squad Leader", "Senior Commander", "Organaization" };
        public string Rank { get; private set; }

        private int SensorsRemove = 0;


        public bool IsHiding
        {
            get
            {
                foreach (bool location in attachedSensor.EnabledByLocation)
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
                    attachedSensor.CapacityOfSensors = 2;
                    MaxCounterAttackByRank = 0;
                    SensorsRemove = -1;
                    break;
                case "Squad Leader":
                    attachedSensor.CapacityOfSensors = 4;
                    MaxCounterAttackByRank = 3;
                    SensorsRemove = 1;

                    break;
                case "Senior Commander":
                    attachedSensor.CapacityOfSensors = 6;
                    MaxCounterAttackByRank = 3;
                    SensorsRemove = 2;
                    break;
                case "Organaization":
                    attachedSensor.CapacityOfSensors = 8;
                    MaxCounterAttackByRank = 3;
                    SensorsRemove = 1;
                    break;
            }
        }
        private void InitialyzeParameters()
        {
            attachedSensor.AttachedSensors = new BaseSensor[attachedSensor.CapacityOfSensors];
            attachedSensor.EnabledByLocation = new bool[attachedSensor.CapacityOfSensors];
            for (int i = 0; i < attachedSensor.CapacityOfSensors; i++)
            {
                attachedSensor.EnabledByLocation[i] = false;
            }

        }
        public string SuccssedMatchingString(int count)
        {
            return $"You succssed {count} / {attachedSensor.CapacityOfSensors}";
        }
        public override string ToString()
        {
            return $"The Rank is: {Rank}. {SuccssedMatchingString(attachedSensor.CountMatchingSensor())}";
        }



    }
}
