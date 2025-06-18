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
        private string name = null;
        private int rank = 0;
        private int score = 0;

        private int uniqueId = 0;
        public int Id { get; private set; }
        public string Name { get { return name; }  set { if (name == null) name = value; } }
        public int Money { get;  set; } = 1000;
        public int Rank { get { return rank; } set { if (rank <= 10) rank++; } }
        public int Score { get { return score; } set { if ((value - score) > 0) score += 1; else if ((value - score) < 0) score -= 1; } }

        public int Tries { get; private set; } = 0;

        public Player()
        {
            uniqueId++;
            Id = uniqueId;
        }
        public void AddTurn()
        {
            Tries++;
        }
        public void UpgradeRank()
        {
            Rank++;
        }


    }
}
