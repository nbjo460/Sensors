using Sensors.BaseModels.Sensors;
using Sensors.Dal;
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
        public virtual bool Activate(IranAgent _agent)
        {
            AgentAttached = _agent;
            bool attached = _agent.AttachSensor(this);

            //AgentDal.InsertIranAgent(agent);

            return attached;
        }
        public static void SpecialPowerExecute(IranAgent _agent, bool _attached, string _name)
        {
            PulseSensor.SpecialPower();
            ThermalSensor.SpecialPower(_agent, _attached, _name);
            MagneticSensor.SpecialPower(_agent, _attached, _name);
            MotionSensor.SpecialPower();
            SignalSensor.SpecialPower(_agent, _attached, _name);
            LightSensor.SpecialPower(_agent, _attached, _name);
        }
        public override string ToString()
        {
            return $"The Sensor is: {Name}";
        }
    }
}
