namespace Sensors.BaseModels
{
    public interface IAgentSensorAttached
    {
        int CapacityOfSensors { get; set; }
        string[] RequierdTypesOfSensors { get; set; }
        bool[] EnabledByLocation { get; set; }
        BaseSensor[] AttachedSensors { get; set; }

        void DeleteSpecificlySensor(BaseSensor _sensor);
        bool AttachSensor(BaseSensor _sensor, int _location = -1);
        int CountMatchingSensor();
        void DeleteSensorsByNum(int num);
    }
}