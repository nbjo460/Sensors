using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels.Sensors
{
    internal class ThermalSensor : BaseSensor
    {
        public override string Name { get; protected set; } = "Thermal Sensor";
        public static void SpecialPower(IranAgent agent, bool _attached, string _name)
        {
            if (_name == "Thermal Sensor" && _attached)
            {
                Console.WriteLine(agent.RequierdTypesOfSensors[new Random().Next(0, agent.CapacityOfSensors)]);
            }
        }
    }
}
