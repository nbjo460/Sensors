using Sensors.BaseModels;
using Sensors.Factory;
using Sensors.Game;
using Sensors.ModelsClass;
using Sensors.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RankDoesNotExist;

namespace Sensors.Game
{
    internal class Game
    {
        IranAgent agent = FactoryIranAgent.CreateIranAgent();
        Investigation invest;
        public void StartGame()
        {
            Menu();
            CreateInvistigate();
        }

        private void ShowMenu()
        {
            string[] menu =
            {
                "Hello! Welcome to my game.\n",
                "The game is about to find the Iran agent.\n",
                $"\n\n" +
                $"We want to tag some dangerous agents.\n" +
                $"Please help us to catch him.\n" +
                $"For this, you need to found the right Sensors that he can to carry, and attach them.\n"
            };
            Print.PrintMenu(menu);
        }
         
        private void CreateInvistigate() 
        {
            Player moshe = new Player();
            moshe.Name = "Moshe";
            invest = new Investigation(agent, moshe);
            invest.StartInvestigateTillEnd(moshe);
        }
        private void Menu()
        {
            ShowMenu();
        }

    }
}
