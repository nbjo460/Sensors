using Sensors.BaseModels;
using Sensors.ModelsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Game
{
    internal class Mixture : IValidateMixture
    {
        string[] listSensors;
        public void ValidateMixture(string _sensorsType, Func<string, BaseSensor> _create, Func<string, IranAgent, Player, BaseSensor,bool> _attach,
             IranAgent _underInvestigate, Player _investigator)
        {
            List<BaseSensor> sensors = CreateListSensors(_create, _sensorsType);
            bool attached = AttachAll(_attach, sensors, _underInvestigate, _investigator);
            if(!attached) throw new MixtureDoseNotMatch(listSensors);
        }
        private List<BaseSensor> CreateListSensors(Func<string, BaseSensor> CallBack, string _sensorsType)
        {
            listSensors = _sensorsType.Split(' ');
            if (listSensors.Length == 1) throw new NotMixture(listSensors[0]);

            List<BaseSensor> sensors = new List<BaseSensor>();
            foreach (string sensorName in listSensors)
            {
                BaseSensor sensor = CreateSensor(CallBack, sensorName);
                sensors.Add(sensor);
            }

            return sensors;

        }
        private BaseSensor CreateSensor( Func<string, BaseSensor> CallBack , string _sensorType)
        {
            return CallBack(_sensorType);
        }
        private bool AttachAll(Func<string, IranAgent, Player, BaseSensor, bool> _attach,
            List<BaseSensor> _sensors, IranAgent _underInvestigate, Player _investigator)
        {
            bool attached = true;
            foreach(BaseSensor sensor in _sensors)
            {
                attached &= _attach(sensor.Name,_underInvestigate,_investigator,sensor);
                if (!attached)
                {
                    DisAttach(_sensors, _underInvestigate, _investigator);
                    return attached;
                }
                BaseSensor.SpecialPowerExecute(_underInvestigate, attached, sensor != null ? sensor.Name : "");

            }
            return attached;
        }
        void DisAttach(List<BaseSensor> _sensors, IranAgent _underInvestigate, Player _investigator)
        {
            foreach (BaseSensor sensor in _sensors) {
                if (sensor != null)
                {
                    sensor.DisActivate(_underInvestigate);
                    _investigator.Score--;
                } 
            }
        }
    }
}
