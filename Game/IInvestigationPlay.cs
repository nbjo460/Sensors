using Sensors.BaseModels;
using Sensors.ModelsClass;
using System.Threading.Tasks;

namespace Sensors.Game
{
    internal interface IInvestigationPlay
    {

        bool InvestigateWeakness(Player Investigator, IranAgent UnderInvestigate);

    }
}