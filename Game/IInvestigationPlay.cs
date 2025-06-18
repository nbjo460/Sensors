using Sensors.BaseModels;
using Sensors.ModelsClass;
using System.Threading.Tasks;

namespace Sensors.Game
{
    internal interface IInvestigationPlay
    {

        Task<bool> InvestigateWeaknessByTimer(Player Investigator, IranAgent UnderInvestigate);
        bool InvestigateWeakness(Player Investigator, IranAgent UnderInvestigate);
    }
}