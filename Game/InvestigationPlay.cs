using Sensors.BaseModels;
using Sensors.Factory;
using Sensors.ModelsClass;
using Sensors.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Game
{
    internal class InvestigationPlay : IInvestigationPlay
    {
        public bool InvestigateWeakness(Player _investigator, IranAgent _underInvestigate)
        {
            int remained = 0;
            _investigator.AddTurn();
            try
            {
                Print.PrintSystemInvestigatorRequest("Guess a Type of Sensor to attach to him.");
                string type = Console.ReadLine();

                BaseSensor sensor = FactorySensor.CreateSensor(type);
                remained = sensor.Activate(_underInvestigate);
                _investigator.Score++;


                string results = _underInvestigate.SuccssedMatchingString(_underInvestigate.CountMatchingSensor());
                Print.PrintUnderInvestigator(results);

                return remained > 0;
            }
            catch (SensorDoesNotExist ex)
            {
                Print.PrintException(ex.Message);
                return _underInvestigate.CapacityOfSensors - _underInvestigate.MatchingSensor > 0;
            }
        }
    }
}
