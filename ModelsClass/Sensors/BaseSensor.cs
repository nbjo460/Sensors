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
            {"Audio", "Thermal", "Pulse", "Motion",
            "Magnetic", "Signal", "Light" };

        protected virtual int RemainedToActivate { get; }
        public virtual string Name { get; protected set; }
        public virtual IranAgent AgentAttached { private get; set; }
        public virtual int Activate()
        {
            AgentAttached.AttachSensor(this);
            return AgentAttached.CountMatchingSensor();
        }
        public override string ToString()
        {
            return $"The Sensor is: {Name}";
        }
    }
}
