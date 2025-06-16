using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels.Sensors
{
    internal class LightSensor : BaseSensor
    {
        public override string Name { get; protected set; } = "Light Sensor";
        public static void SpecialPower( IranAgent _agent, bool _attached, string _name)
        {
            if (_attached && _name == "Light Sensor")
                Console.WriteLine($"The agent's Rank is: {_agent.Rank}. And his ID is: {_agent.ID}");
        }
    }
}
