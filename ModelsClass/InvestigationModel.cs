using Sensors.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.ModelsClass
{
    internal abstract class InvestigationModel
    {

        protected abstract List<Player> investigator { get; set; }
        protected abstract IranAgent under_investigation { get; set; }

        public abstract void AddInvestigator(Player _investigator);
        public abstract Player GetInvatigatorById(int id);
        public abstract void Investigate(Player _Investigator);

    }
}
