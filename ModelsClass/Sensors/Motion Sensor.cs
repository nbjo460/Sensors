using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.BaseModels.Sensors
{
    internal class MotionSensor : BaseSensor
    {
        public override string Name { get; protected set; } = "Motion Sensor";

        private static int id = 0;
        private int uniqueId;
        public MotionSensor()
        {
            MotionList.Add(this);
            id ++;
            uniqueId = id;
        }

        private static List<MotionSensor> MotionList = new List<MotionSensor>();

        private int activateCount = 0;
        public int ActivateCount { get { return activateCount; } set { if (activateCount <= 2) activateCount++; else DeleteSensor(); } }

        public const int ActivateDureable = 3;

        public static bool DoesSensorsExists()
        {
            return MotionList.Count() > 0;
        }

        public static void DeleteSensor()
        {
            MotionSensor sensor = MotionList[0];
            sensor.AgentAttached.AttachedSensor.DeleteSpecificlySensor(sensor);
            MotionList.RemoveAt(0);
        }

        private static void IncreaseCount()
        {
            try
            {
                foreach (MotionSensor motion in MotionList)
                {
                    if (motion != null) motion.ActivateCount++;
                }
            }
            catch
            {
                foreach (MotionSensor motion in MotionList)
                {
                    if (motion != null) motion.ActivateCount++;
                }
            }
        }
        public static void SpecialPower()
        {
            IncreaseCount();
        }
        public static MotionSensor GetFirstSensor()
        {
            return MotionList[0];
        }


    }
}
