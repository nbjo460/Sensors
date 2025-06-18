using Sensors.BaseModels;
using Sensors.ModelsClass;

namespace Sensors.Game
{
    internal interface IInvestigationPlay
    {

        bool InvestigateWeakness(Player Investigator, IranAgent UnderInvestigate);
    }
}