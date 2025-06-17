using Sensors.BaseModels;
using Sensors.Factory;
using Sensors.ModelsClass;
using Sensors.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Game
{
    internal class Investigation : InvestigationModel
    {
        private readonly IInvestigationPlay Play;

        protected override List<Player> investigator { get; set; } = new List<Player>();
        protected override IranAgent under_investigation { get; set; }

        public override bool DoesRemeinSensorsToExplode { get; set; } = true;

        public Investigation(IranAgent _iran, Player _investigator)
        {
            investigator.Add(_investigator);
            under_investigation = _iran;

            Play = new InvestigationPlay();

            Print.PrintSystemInvestigatorRequest("Choose one of them:");
            Print.PrintSystemInvestigatorRequest(string.Join(", ", BaseSensor.TypesOfSensors));
        }

        public override void AddInvestigator(Player _investigator)
        {
            investigator.Add(_investigator);
        }

        public override Player GetInvatigatorById(int id)
        {
            throw new NotImplementedException();
        }

        public override void InvestigateSingleTurn(Player _investigator)
        {
            DoesRemeinSensorsToExplode = Play.InvestigateWeakness(_investigator, under_investigation);
        }
        public override void StartInvestigateTillEnd(Player _player)
        {
            while (DoesRemeinSensorsToExplode)
            {
                InvestigateSingleTurn(_player);
            }
        }
    }
}
