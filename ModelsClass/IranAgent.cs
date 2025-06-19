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

        public readonly IAgentSensorAttached AttachedSensor = new AgentSensorAttached();
        public readonly IAgentTurn AgentTurn;

        //public void SpecialPower(bool _attached)
        //{
        //    ChangeWeakness();
        //    if (!_attached)
        //    {
        //        CounterTurns++;
        //        if (SpecialPowerPossibility >= 0)
        //        {
        //            if (CounterTurns % 10 == 0)
        //            {
        //                attachedSensor.DeleteSensorsByNum(attachedSensor.CapacityOfSensors);
        //                Print.PrintUnderInvestigator("Each 10 turns. Your's all Sensors delete!\nLike Now LOLLL");
        //            }
        //            else if (SensorsRemove == -1)
        //            {
        //                return;
        //            }
        //            else if (CounterTurns % MaxCounterAttackByRank == 0)
        //            {
        //                attachedSensor.DeleteSensorsByNum(SensorsRemove);
        //                Print.PrintUnderInvestigator($"Each {MaxCounterAttackByRank} turns. {SensorsRemove} Sensors are delete!\nLike Now LOLLL");

        //            }
        //        }
        //        else
        //        {
        //            if (CounterTurns % 10 == 0 || CounterTurns % MaxCounterAttackByRank == 0)
        //                SpecialPowerPossibility++;
        //        }
        //    }
        //}
        //private void ChangeWeakness()
        //{
        //    Random rnd = new Random();
        //    if (CounterTurns > 0 && CounterTurns % 5 == 0)
        //    {
        //        int indexWeakness = rnd.Next(0, attachedSensor.CapacityOfSensors);
        //        int newWeakness = rnd.Next(0, BaseSensor.TypesOfSensors.Length);
        //        attachedSensor.RequierdTypesOfSensors[indexWeakness] = BaseSensor.TypesOfSensors[newWeakness];
        //        Print.PrintUnderInvestigator("I changed my weakness.");
        //    }

        //}
        //public void AgentTurn(bool _attached)
        //{
        //    string results = SuccssedMatchingString(attachedSensor.CountMatchingSensor());
        //    Print.PrintUnderInvestigator(results);
        //    SpecialPower(_attached);
        //}
        //public int SpecialPowerPossibility = 0;
        //private int MaxCounterAttackByRank = 0;
        //public int CounterTurns { get; private set; } = 0;
        //public const int MaxCounterAttack = 10;



        private static int id = 0;
        public static string[] TypesOfRank { get; } =
            { "Foot Soldier", "Squad Leader", "Senior Commander", "Organaization" };
        public int ID { get; private set; }
        public string Rank { get; private set; }

        public int SensorsRemove = 0;
        public bool IsHiding
        {
            get
            {
                foreach (bool location in AttachedSensor.EnabledByLocation)
                {
                    if (!location) return true;
                }
                return false;
            }
        }

        public IranAgent(string _rank) : this(id+1, _rank, 0)
        {
            id += 1;
            ID = id;
        }
        public IranAgent(int _id ,string _rank, int _turns)
        {
            ID = _id;
            AgentTurn = new AgentTurn(this);
            SetCapcityAndRank(_rank);
            InitialyzeParameters();
            AgentTurn.CounterTurns = _turns;
        }

        
        private void SetCapcityAndRank(string _rank)
        {
            if (!TypesOfRank.Contains(_rank)) throw new RankDoesNotExist(TypesOfRank, _rank);

            Rank = _rank;

            switch (_rank)
            {
                case "Foot Soldier":
                    AttachedSensor.CapacityOfSensors = 2;
                    AgentTurn.MaxCounterAttackByRank = 0;
                    SensorsRemove = -1;
                    break;
                case "Squad Leader":
                    AttachedSensor.CapacityOfSensors = 4;
                    AgentTurn.MaxCounterAttackByRank = 3;
                    SensorsRemove = 1;

                    break;
                case "Senior Commander":
                    AttachedSensor.CapacityOfSensors = 6;
                    AgentTurn.MaxCounterAttackByRank = 3;
                    SensorsRemove = 2;
                    break;
                case "Organaization":
                    AttachedSensor.CapacityOfSensors = 8;
                    AgentTurn.MaxCounterAttackByRank = 3;
                    SensorsRemove = 1;
                    break;
            }
        }
        private void InitialyzeParameters()
        {
            AttachedSensor.AttachedSensors = new BaseSensor[AttachedSensor.CapacityOfSensors];
            AttachedSensor.EnabledByLocation = new bool[AttachedSensor.CapacityOfSensors];
            for (int i = 0; i < AttachedSensor.CapacityOfSensors; i++)
            {
                AttachedSensor.EnabledByLocation[i] = false;
            }

        }
        public string SuccssedMatchingString(int count)
        {
            return $"You succssed {count} / {AttachedSensor.CapacityOfSensors}";
        }
        public override string ToString()
        {
            return $"The Rank is: {Rank}. {SuccssedMatchingString(AttachedSensor.CountMatchingSensor())}";
        }
    }
}
