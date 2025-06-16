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
    internal class FactorySensor
    {
        public BaseSensor CreateSensor(string _type)
        {

            //public static string[] TypesOfSensors { get; } =
            //{"Audio", "Thermal", "Pulse", "Motion",
            //"Magnetic", "Signal", "Light" };

        BaseSensor sensor;
            switch (_type) 
            {
                case "Audio":
                    sensor = new AudioSensor();
                    break;
                case "Thermal":
                    sensor = new ThermalSensor();
                    break;
                case "Pulse":
                    sensor = new PulseSensor();
                    break;
                case "Motion":
                    sensor = new MagneticSensor();
                    break;
                case "Signal":
                    sensor = new SignalSensor();
                    break;
                case "Light":
                    sensor = new LightSensor();
                    break;
                default:
                    throw new SensorDoesNotExist(BaseSensor.TypesOfSensors ,_type);
            }
            return sensor;
        }
    }
}
