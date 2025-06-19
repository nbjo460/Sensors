using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels.Sensors
{
    internal class PulseSensor : BaseSensor
    {
        private static int id = 0;
        private int uniqueId;
        public PulseSensor()
        {
            PulseList.Add(this);
            id += 1;
            uniqueId = id;
        }

        private static List<PulseSensor> PulseList = new List<PulseSensor>();

        private  int activateCount = 0;
        public  int ActivateCount { get { return activateCount; } set { if (activateCount <= 2) activateCount++; else DeleteSensor(); } }

        public const int ActivateDureable = 3;
        public override string Name { get; protected set; } = "Pulse Sensor";

        public static bool DoesSensorsExists()
        {
            return PulseList.Count() > 0;
        }

        public static void DeleteSensor()
        {
            PulseSensor sensor = PulseList[0];
            sensor.AgentAttached.attachedSensor.DeleteSpecificlySensor(sensor);
            PulseList.RemoveAt(0);
        }

        private static void IncreaseCount()
        {
            try
            {
                foreach (PulseSensor pulse in PulseList)
                {
                    if (pulse != null) pulse.ActivateCount++;
                }
            }
            catch
            {
                foreach (PulseSensor pulse in PulseList)
                {
                    if (pulse != null) pulse.ActivateCount++;
                }
            }
        }
        public static void SpecialPower()
        {
            IncreaseCount();
        }
        public static PulseSensor GetFirstSensor() 
        {
            return PulseList[0];
        }


    }
}
