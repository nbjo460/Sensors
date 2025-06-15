using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Models
{
    internal abstract class BaseSensor
    {
        public static string[] TypesOfSensors { get; } =
            {"Audio", "Thermal", "Pulse", "Motion",
            "Magnetic", "Signal", "Light" };

        protected abstract int RemainActivate { get; }
        public abstract string Name { get; set; }

        public virtual IranAgent AgentAttached {private get; set; }
        public virtual int Activate()
        {
            AgentAttached.AttachSensor(this);
            return AgentAttached.CountMatchingSensor();
        }

    }
}
