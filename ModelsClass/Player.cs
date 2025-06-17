using Sensors.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.ModelsClass
{
    internal class Player
    {
        private int uniqueId = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Money { get; private set; } = 1000;
        public int Rank { get; private set; } = 0;
        public int Tries { get; private set; } = 0;

        public Player()
        {
            uniqueId++;
            Id = uniqueId;

        }


    }
}
