using Org.BouncyCastle.Security;
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
            _investigator.AddTurn();
            
             string sensorType = GetTypeOfSensorFromUser();
             BaseSensor sensor = CreateSensor(sensorType);
             bool doesAttached = AttachSensor(sensorType, _underInvestigate, _investigator, sensor);
             
            BaseSensor.SpecialPowerExecute(_underInvestigate, doesAttached, sensor != null ? sensor.Name : "");
            AgentTurn(_underInvestigate, _investigator, doesAttached);

            return RemainAnotherWeakness(_underInvestigate);
        }

        private string AskingATypeSensorFromUserWithoutTimer()
        {
            Print.PrintTurn("Your's turn.");
            Print.PrintSystemInvestigatorRequest("Guess a Type of Sensor to attach to him.");
            return Console.ReadLine();
        }
        private BaseSensor CreateSensor(string _sensorName)
        {
            try
            {
                BaseSensor sensor = FactorySensor.CreateSensor(_sensorName);
                return sensor;
            }
            catch (SensorDoesNotExist ex)
            {
                Print.PrintException(ex.Message);
                return  null;
            }
        }
        private bool AttachSensor(string _sensorName, IranAgent _underInvestigate, Player _investigator, BaseSensor _sensor)
        {
            bool doesAttached = false;
            if (_sensor != null)
            {
                 doesAttached = _sensor.Activate(_underInvestigate);
                _investigator.Score++;
            }
                return doesAttached;
        }
        private void AgentTurn(IranAgent _underInvestigate, Player _investigator, bool _attached)
        {
            Print.PrintTurn("Is Iran agent Turn");
            _underInvestigate.AgentTurn(_attached);
        }
        private bool RemainAnotherWeakness(IranAgent _underInvestigate)
        {
            return _underInvestigate.CapacityOfSensors - _underInvestigate.MatchingSensor > 0;
        }
        private async Task <string> AskingATypeSensorFromUserWithTimer()
        {
            Task<string> investigate = Task.Run(() => { return AskingATypeSensorFromUserWithoutTimer(); });
            Task delayTask = Task.Delay(10000);
            Task completedTask = await(Task.WhenAny(investigate, delayTask));
            bool timeLeft = completedTask == delayTask;
            if (timeLeft) Print.PrintException("\nTime Left. You Waste 1 turn.\n");
            return !timeLeft ? investigate.Result : "";
        }
        public string GetTypeOfSensorFromUser()
        {
            return AskingATypeSensorFromUserWithTimer().GetAwaiter().GetResult();
        }
    }
}
