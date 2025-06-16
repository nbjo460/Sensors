using Sensors.BaseModels;
using Sensors.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RankDoesNotExist;

namespace Sensors.Exception
{
    internal class Game
    {
        IranAgent agent = FactoryIranAgent.CreateIranAgent(); 
        public void StartGame()
        {
            Menu();
        }
        
        private void PrintMenu(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            int screenWidth = Console.WindowWidth;
            int padding = (screenWidth - str.Length)/2;

            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void ShowMenu()
        {
            string[] menu =
            {
                "Hello! Welcome to my game.\n",
                "The game is about to find the Iran agent.\n",
                $"\n\n" +
                $"We want to tag a dangerous agent {agent}.\n" +
                $"Please help us to catch him.\n" +
                $"For this, you need to found the right Sensors that he can to carry, and attach them.\n" 
            };
            foreach (string line in menu)
                Console.WriteLine(line);
            //PrintMenu(line);
        }
        private void Menu()
        {
            ShowMenu();
            BaseSensor sensor = null;
            Console.WriteLine("Choose one of them:");
            Console.WriteLine(string.Join(" ,", BaseSensor.TypesOfSensors));
            int remained = 0;
            do
            {
                Console.WriteLine("Guess a Type of Sensor to attach.");
                string type = Console.ReadLine();
                try
                {
                    sensor = FactorySensor.CreateSensor(type);
                    remained = sensor.Activate(agent);

                    Console.WriteLine(agent.MatchingSensorString(agent.CountMatchingSensor()));

                    
                }
                catch (SensorDoesNotExist ex)
                {
                    PrintException.Print(ex.Message);
                    continue;
                }
            }
            while (sensor == null || remained > 0);
            

            
        }

    }
}
