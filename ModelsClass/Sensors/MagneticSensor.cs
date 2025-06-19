using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels.Sensors
{
    internal class MagneticSensor : BaseSensor
    {
        public override string Name { get; protected set; } = "Magnetic Sensor";
        public static void SpecialPower(IranAgent agent, bool _attached, string _name)
        {
            if (_attached && _name == "Magnetic Sensor")
            agent.AgentTurn.SpecialPowerPossibility = -2; 
        }
    }
}
