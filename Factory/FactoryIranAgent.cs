using Sensors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Factory
{
    internal class FactoryIranAgent
    {
        public IranAgent CreateIranAgent()
        {
            string rank = IranAgent.TypesOfRank[new Random().Next(0, IranAgent.TypesOfRank.Length)];
            IranAgent agent = new IranAgent(rank);
            string[] TypesOfSensors = new string[agent.CapacityOfSensors];
            for (int i = 0; i < agent.CapacityOfSensors; i++)
            {
                TypesOfSensors[i] = BaseSensor.TypesOfSensors[new Random().Next(0, BaseSensor.TypesOfSensors.Length)]; 
            }
            agent.RequierdTypesOfSensors = TypesOfSensors;
            return agent;
        }
    }
}
