using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Models
{
    internal abstract class     BaseSensor
    {
        public static string[] TypesOfSensors { get; } =
            {"Audio", "Thermal", "Pulse", "Motion",
            "Magnetic", "Signal", "Light" };

        protected virtual int CountToActivate { get; }
        protected virtual string Name { get; set; }

    }
}
