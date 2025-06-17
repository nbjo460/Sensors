using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.UI
{
    internal static class Print
    {
        public static void PrintCentered(string _str)
        {
            try
            {
                int screenWidth = Console.WindowWidth;

                // פיצול לשורות במקרה של \n
                string[] lines = _str.Split('\n');

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();

                    if (trimmedLine.Length <= screenWidth - 2) // מרווח בטיחות
                    {
                        int padding = Math.Max((screenWidth - trimmedLine.Length) / 2, 0);

                        try
                        {
                            Console.SetCursorPosition(padding, Console.CursorTop);
                            Console.WriteLine(trimmedLine);
                        }
                        catch
                        {
                            // אם SetCursorPosition לא עובד, השתמש ברווחים
                            Console.WriteLine(new string(' ', padding) + trimmedLine);
                        }
                    }
                    else
                    {
                        // טקסט ארוך מדי - הדפס בלי מרכוז
                        Console.WriteLine(trimmedLine);
                    }
                }
            }
            catch
            {
                // אם יש בעיה כלשהי, פשוט הדפס רגיל
                Console.WriteLine(_str);
            }
        }
        private static  void PrintColorMenu(string _str)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCentered(_str);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static  void PrintListString(string[] _str)
        {
            foreach (string line in _str)
                //Console.WriteLine(line);
                PrintCentered(line);
        }
        public static void PrintMenu(string[] _menu)
        {
            foreach (string line in _menu)
                //Console.WriteLine(line);
                PrintColorMenu(line);
        }
    }
}
