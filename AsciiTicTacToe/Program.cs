using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace AsciiTicTacToe
{
    class Program
    {
        public static bool soundMode = Settings.Default.Music;
        public static bool debugMode = false;
        static void Main(string[] args)
        {
            Console.Title = "TicTacToe";
            if (args.Length != 0) { if (args[0] == "debug") { debugMode = true; } }
            Menu.MainMenu();
        }

        /*Метод управления "Controls"*/
        unsafe public static bool Controls(string canvasType, ref int[] currentPosition, ref int[] currentPositionReal)
        {
            switch (canvasType) {
                case "Menu":
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentPosition[0] - 1 < 0) { currentPosition[0] = 2; } else { currentPosition[0] -= 1; }  
                            return false;
                        case ConsoleKey.DownArrow:
                            if (currentPosition[0] + 1 > 2) { currentPosition[0] = 0; } else { currentPosition[0] += 1; }
                            return false;
                        case ConsoleKey.Enter:
                            return true;
                    }
                    break;
                case "Settings":
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentPosition[0] - 1 < 0) { currentPosition[0] = 4; } else { currentPosition[0] -= 1; }
                            return false;
                        case ConsoleKey.DownArrow:
                            if (currentPosition[0] + 1 > 4) { currentPosition[0] = 0; } else { currentPosition[0] += 1; }
                            return false;
                        case ConsoleKey.Enter:
                            return true;
                    }
                    break;
                case "Game":
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentPosition[1] - 1 < 0) { currentPosition[1] = 0; } else { currentPosition[1] -= 1; }
                            if (currentPositionReal[1] - 2 < 0) { currentPositionReal[1] = 0; } else { currentPositionReal[1] -= 2; }
                            return false;
                        case ConsoleKey.DownArrow:
                            if (currentPosition[1] + 1 > 2) { currentPosition[1] = 2; } else { currentPosition[1] += 1; }
                            if (currentPositionReal[1] + 2 > 4) { currentPositionReal[1] = 4; } else { currentPositionReal[1] += 2; }
                            return false;
                        case ConsoleKey.LeftArrow:
                            if (currentPosition[0] - 1 < 0) { currentPosition[0] = 0; } else { currentPosition[0] -= 1; }
                            if (currentPositionReal[0] - 4 < 1) { currentPositionReal[0] = 1; } else { currentPositionReal[0] -= 4; }
                            return false;
                        case ConsoleKey.RightArrow:
                            if (currentPosition[0] + 1 > 2) { currentPosition[0] = 2; } else { currentPosition[0] += 1; }
                            if (currentPositionReal[0] + 4 > 9) { currentPositionReal[0] = 9; } else { currentPositionReal[0] += 4; }
                            return false;
                        case ConsoleKey.Enter:
                            return true;
                    }
                    break;
            }
            return false;
        }

        /* Перегрузка метода Controls */
        public static bool Controls(string canvasType, ref int[] currentPosition)
        {
            int[] currentPositionReal = {0, 0};
            return Controls(canvasType, ref currentPosition, ref currentPositionReal);
        }

        /* Метод вывода изображений "Render" */
        public static void Render(string canvasType, int parametr, int[,] field = null)
        {
            if (!debugMode) { Console.SetWindowSize(11, 8); }
            Console.Clear();
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            switch (canvasType)
            {
                case "Menu":
                    switch (parametr)
                    {
                        case 0:
                            Console.WriteLine("   T i c   ");
                            Console.WriteLine("   T a c   ");
                            Console.WriteLine("   T o e   ");
                            Console.WriteLine();
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Начать игру");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" Настройки ");
                            Console.WriteLine("   Выход   ");
                            break;
                        case 1:
                            Console.WriteLine("   T i c   ");
                            Console.WriteLine("   T a c   ");
                            Console.WriteLine("   T o e   ");
                            Console.WriteLine();
                            Console.WriteLine("Начать игру");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" Настройки ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("   Выход   ");
                            break;
                        case 2:
                            Console.WriteLine("   T i c   ");
                            Console.WriteLine("   T a c   ");
                            Console.WriteLine("   T o e   ");
                            Console.WriteLine();
                            Console.WriteLine("Начать игру");
                            Console.WriteLine(" Настройки ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("   Выход   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    break;
                case "Settings":
                    switch (parametr)
                    {
                        case 0:
                            Console.WriteLine(" Настройки ");
                            Console.WriteLine("");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("  Звук: {0}  ", Convert.ToInt16(Settings.Default.Music));
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("           ");
                            Console.WriteLine("           ");
                            Console.WriteLine("           ");
                            Console.WriteLine("   Назад   ");
                            break;
                        case 1:
                            Console.WriteLine(" Настройки ");
                            Console.WriteLine("");
                            Console.WriteLine("  Звук: {0}  ", Convert.ToInt16(Settings.Default.Music));
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("           ");
                            Console.WriteLine("           ");
                            Console.WriteLine("   Назад   ");
                            break;
                        case 2:
                            Console.WriteLine(" Настройки ");
                            Console.WriteLine("");
                            Console.WriteLine("  Звук: {0}  ", Convert.ToInt16(Settings.Default.Music));
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("           ");
                            Console.WriteLine("   Назад   ");
                            break;
                        case 3:
                            Console.WriteLine(" Настройки ");
                            Console.WriteLine("");
                            Console.WriteLine("  Звук: {0}  ", Convert.ToInt16(Settings.Default.Music));
                            Console.WriteLine("           ");
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("   Назад   ");
                            break;
                        case 4:
                            Console.WriteLine(" Настройки ");
                            Console.WriteLine("");
                            Console.WriteLine("  Звук: {0}  ", Convert.ToInt16(Settings.Default.Music));
                            Console.WriteLine("           ");
                            Console.WriteLine("           ");
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("   Назад   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    break;
                case "ChangeGamemode":
                    switch (parametr)
                    {
                        case 0:
                            Console.WriteLine("Выбор  игры");
                            Console.WriteLine("");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("   С  ИИ   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" С игроком ");
                            Console.WriteLine("  По сети  ");
                            Console.WriteLine("           ");
                            Console.WriteLine("   Назад   ");
                            break;
                        case 1:
                            Console.WriteLine("Выбор  игры");
                            Console.WriteLine("");
                            Console.WriteLine("   С  ИИ   ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" С игроком ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("  По сети  ");
                            Console.WriteLine("           ");
                            Console.WriteLine("   Назад   ");
                            break;
                        case 2:
                            Console.WriteLine("Выбор  игры");
                            Console.WriteLine("");
                            Console.WriteLine("   С  ИИ   ");
                            Console.WriteLine(" С игроком ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("  По сети  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("           ");
                            Console.WriteLine("   Назад   ");
                            break;
                        case 3:
                            Console.WriteLine("Выбор  игры");
                            Console.WriteLine("");
                            Console.WriteLine("   С  ИИ   ");
                            Console.WriteLine(" С игроком ");
                            Console.WriteLine("  По сети  ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("   Назад   ");
                            break;
                        case 4:
                            Console.WriteLine("Выбор  игры");
                            Console.WriteLine("");
                            Console.WriteLine("   С  ИИ   ");
                            Console.WriteLine(" С игроком ");
                            Console.WriteLine("  По сети  ");
                            Console.WriteLine("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("   Назад   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    break;
                case "Game":
                    char[] val = { ' ', 'X', 'O' };
                    Console.WriteLine(" {0} ║ {1} ║ {2} ", val[field[0, 0]], val[field[1, 0]], val[field[2, 0]]);
                    Console.WriteLine("═══╬═══╬═══");
                    Console.WriteLine(" {0} ║ {1} ║ {2} ", val[field[0, 1]], val[field[1, 1]], val[field[2, 1]]);
                    Console.WriteLine("═══╬═══╬═══");
                    Console.WriteLine(" {0} ║ {1} ║ {2} ", val[field[0, 2]], val[field[1, 2]], val[field[2, 2]]);
                    Console.WriteLine("   Ходит   ");
                    if (parametr == 2)
                    {
                        Console.WriteLine("   нолик   ");
                    } else
                    {
                        Console.WriteLine("  крестик  ");
                    }
                    Console.CursorVisible = true;
                    break;
                case "Win":
                    switch (parametr)
                    {
                        case 0:
                            Console.WriteLine("");
                            Console.WriteLine("   НИЧЬЯ   ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("   Выход   ");
                            Console.WriteLine("  в  меню  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            break;
                        case 1:
                            Console.WriteLine("");
                            Console.WriteLine(" Крестики  ");
                            Console.WriteLine("  Выиграли ");
                            Console.WriteLine("");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("   Выход   ");
                            Console.WriteLine("  в  меню  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            break;
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine(" Нолики    ");
                            Console.WriteLine("  Выиграли ");
                            Console.WriteLine("");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("   Выход   ");
                            Console.WriteLine("  в  меню  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            break;
                    }
                    break;
            }
        }
    }
}
