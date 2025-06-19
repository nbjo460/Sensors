using Sensors.UI;
using System;

namespace Sensors.BaseModels
{
    public class AgentTurn : IAgentTurn
    {
        IranAgent Agent;
        public AgentTurn(IranAgent _agent)
        {
            Agent = _agent;
        }
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
                        Agent.AttachedSensor.DeleteSensorsByNum(Agent.AttachedSensor.CapacityOfSensors);
                        Print.PrintUnderInvestigator("Each 10 turns. Your's all Sensors delete!\nLike Now LOLLL");
                    }
                    else if (Agent.SensorsRemove == -1)
                    {
                        return;
                    }
                    else if (CounterTurns % MaxCounterAttackByRank == 0)
                    {
                        Agent.AttachedSensor.DeleteSensorsByNum(Agent.SensorsRemove);
                        Print.PrintUnderInvestigator($"Each {MaxCounterAttackByRank} turns. {Agent.SensorsRemove} Sensors are delete!\nLike Now LOLLL");

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
                int indexWeakness = rnd.Next(0, Agent.AttachedSensor.CapacityOfSensors);
                int newWeakness = rnd.Next(0, BaseSensor.TypesOfSensors.Length);
                Agent.AttachedSensor.RequierdTypesOfSensors[indexWeakness] = BaseSensor.TypesOfSensors[newWeakness];
                Print.PrintUnderInvestigator("I changed my weakness.");
            }

        }
        public void PlaysTurn(bool _attached)
        {
            string results = Agent.SuccssedMatchingString(Agent.AttachedSensor.CountMatchingSensor());
            Print.PrintUnderInvestigator(results);
            SpecialPower(_attached);
        }

        public int CounterTurns { get; set; } = 0;
        public int SpecialPowerPossibility { get; set; }
        public int MaxCounterAttackByRank { get; set ; }

        public const int MaxCounterAttack = 10;

    }
}