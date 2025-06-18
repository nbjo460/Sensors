using Sensors.BaseModels;
using Sensors.ModelsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Game
{
    internal interface IValidateMixture
    {

        void ValidateMixture(string _sensorsType, Func<string, BaseSensor> _create, Func<string, IranAgent, Player, BaseSensor, bool> _attach,
                     IranAgent _underInvestigate, Player _investigator);
    }
}
