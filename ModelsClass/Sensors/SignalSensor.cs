﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels.Sensors
{
    internal class SignalSensor : BaseSensor
    {
        public override string Name { get; protected set; } = "Signal Sensor";
        public static void SpecialPower(IranAgent _agent, bool _attached ,string _name)
        {
            if (_attached && _name == "Signal Sensor")
                Console.WriteLine(_agent.Rank);
        }
    }
}
