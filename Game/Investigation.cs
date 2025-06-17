using Sensors.BaseModels;
using Sensors.ModelsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Game
{
    internal class Investigation : InvestigationModel
    {
        protected override List<Player> investigator { get; set; } = new List<Player>();
        protected override IranAgent under_investigation { get; set; }

        public Investigation(IranAgent _iran, Player _investigigator)
        {
            investigator.Add(_investigigator);
            under_investigation = _iran;
        }

        public override void AddInvestigator(Player _investigator)
        {
            investigator.Add(_investigator);
        }

        public override Player GetInvatigatorById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Investigate(Player _Investigator)
        {
            throw new NotImplementedException();
        }
    }
}
