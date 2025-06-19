using Sensors.BaseModels.Sensors;
using Sensors.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels
{
    public abstract class BaseSensor
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
            bool attached = _agent.AttachedSensor.AttachSensor(this);

            AgentDal.InsertIranAgent(_agent);

            return attached;
        }
        public virtual void DisActivate(IranAgent _agent)
        {
            AgentAttached = null;
            _agent.AttachedSensor.DeleteSpecificlySensor(this);
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
