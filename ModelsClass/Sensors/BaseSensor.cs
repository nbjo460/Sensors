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
            bool attached = AgentAttached.AttachSensor(this);
            SpecialPower(agent, attached);

            int count = AgentAttached.CountMatchingSensor();
            int remained = AgentAttached.CapacityOfSensors - count;

            AgentAttached.MatchingSensorString(count);
            return remained;
        }
        private void SpecialPower(IranAgent _agent, bool _attached)
        {
            PulseSensor.SpecialPower();
            _agent.SpecialPower();
            ThermalSensor.SpecialPower(_agent, _attached, Name);
            MagneticSensor.SpecialPower(_agent, Name);


        }
        public override string ToString()
        {
            return $"The Sensor is: {Name}";
        }
    }
}
