using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels.Sensors
{
    internal class AudioSensor : BaseSensor
    {
        public override string Name { get; protected set; } = "Audio Sensor";
    }
}
