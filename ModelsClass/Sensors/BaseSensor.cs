using Sensors.BaseModels.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels
{
    internal abstract class BaseSensor
    {
        public static string[] TypesOfSensors { get; } =
            {"Audio Sensor", "Thermal Sensor", "Pulse Sensor", "Motion Sensor",
            "Magnetic Sensor", "Signal Sensor", "Light Sensor" };

        protected virtual int RemainedToActivate { get; }
        public virtual string Name { get; protected set; }
        public virtual IranAgent AgentAttached { get; private set; }
        public virtual int Activate(IranAgent agent)
        {
            AgentAttached = agent;
            AgentAttached.AttachSensor(this);

            int count = AgentAttached.CountMatchingSensor();
            int remained = AgentAttached.CapacityOfSensors - count;

            AgentAttached.MatchingSensorString(count);
            SpecialPower();
            return remained;
        }
        private void SpecialPower()
        {
            PulseSensor.SpecialPower();

            
        }
        public override string ToString()
        {
            return $"The Sensor is: {Name}";
        }
    }
}
