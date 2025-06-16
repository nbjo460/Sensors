using Sensors.BaseModels;
using Sensors.BaseModels.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RankDoesNotExist;

namespace Sensors.Factory
{
    internal static class FactorySensor
    {
        public static BaseSensor CreateSensor(string _type)
        {

            //public static string[] TypesOfSensors { get; } =
            //{"Audio", "Thermal", "Pulse", "Motion",
            //"Magnetic", "Signal", "Light" };

        BaseSensor sensor;
            switch (_type) 
            {
                case "Audio":
                    return new AudioSensor();
                case "Thermal":
                    return new ThermalSensor();
                case "Pulse":
                    return new PulseSensor();
                case "Motion":
                    return new MotionSensor();
                case "Magnetic":
                    return new MagneticSensor();
                case "Signal":
                    return new SignalSensor();
                case "Light":
                    return new LightSensor();
                default:
                    throw new SensorDoesNotExist(BaseSensor.TypesOfSensors ,_type);
            }
        }
    }
}
