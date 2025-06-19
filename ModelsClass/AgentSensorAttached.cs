using Sensors.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.ModelsClass
{
    public class AgentSensorAttached : IAgentSensorAttached
    {
        public int CapacityOfSensors { get;  set; }
        public BaseSensor[] AttachedSensors { get; set; }
        public bool[] EnabledByLocation { get; set; }
        public string[] RequierdTypesOfSensors
        {
            get { return requierdTypesOfSensors; }
            set
            {
                if (requierdTypesOfSensors == null) requierdTypesOfSensors = value;
            }
        }

        private string[] requierdTypesOfSensors = null;
        public void DeleteSpecificlySensor(BaseSensor _sensor)
        {
            for (int i = 0; i < AttachedSensors.Count(); i++)
            {
                if (_sensor == null && AttachedSensors[i] == null) return;
                else if (AttachedSensors[i] == null) continue;
                else if (_sensor != null && AttachedSensors[i] != null)
                {
                    if (AttachedSensors[i].Equals(_sensor))
                    {
                        AttachedSensors[i] = null;
                        EnabledByLocation[i] = false;
                        Console.WriteLine(_sensor.Name + " Was DELETED");
                        break;
                    }
                }
            }
        }
        public bool AttachSensor(BaseSensor _sensor, int _location = -1)
        {
            //Game With Location
            if (_location >= 0)
            {
                if (_location > CapacityOfSensors)
                    throw new LocationNotInRange(_location, CapacityOfSensors - 1);

                else
                    AttachedSensors[_location - 1] = _sensor;
                EnabledByLocation[_location - 1] = true ? RequierdTypesOfSensors[_location - 1] == _sensor.Name : false;
                return EnabledByLocation[_location - 1];
            }
            //Game without Location
            else
            {
                for (int i = 0; i < CapacityOfSensors; i++)
                {
                    if (!EnabledByLocation[i] && RequierdTypesOfSensors[i] == _sensor.Name)
                    {
                        AttachedSensors[i] = _sensor;
                        EnabledByLocation[i] = true;
                        return true;
                    }
                }
            }
            return false;
        }
        public int CountMatchingSensor()
        {
            int count = 0;
            foreach (bool matching in EnabledByLocation)
            {
                if (matching) count++;
            }
            return count;
        }
        public void DeleteSensorsByNum(int num)
        {
            int countDeleted = 0;
            for (int i = 0; i < CapacityOfSensors; i++)
            {
                if (countDeleted == num) return;
                if (AttachedSensors[i] != null)
                {
                    Console.WriteLine(AttachedSensors[i].Name + " Was DELETED");
                    AttachedSensors[i] = null;
                    EnabledByLocation[i] = false;
                    countDeleted++;
                }
            }
        }
    }
}
