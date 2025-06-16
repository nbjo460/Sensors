using Sensors.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Factory
{
    internal static class FactoryIranAgent
    {
        public static IranAgent CreateIranAgent()
        {
            string rank = IranAgent.TypesOfRank[new Random().Next(0, IranAgent.TypesOfRank.Length)];
            //rank = IranAgent.TypesOfRank[1];
            IranAgent agent = new IranAgent(rank);
            string[] TypesOfSensors = new string[agent.CapacityOfSensors];
            Random rnd = new Random();
            for (int i = 0; i < agent.CapacityOfSensors; i++)
            {
                int sensorType = rnd.Next(0, BaseSensor.TypesOfSensors.Length);
                //sensorType = 2;
                TypesOfSensors[i] = BaseSensor.TypesOfSensors[sensorType];
                Console.WriteLine(TypesOfSensors[i]);
            }

            agent.RequierdTypesOfSensors = TypesOfSensors;
            return agent;
        }
    }
}
