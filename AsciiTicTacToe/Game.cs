using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace AsciiTicTacToe
{
    public static class Game
    {
        public static class Singleplayer
        {
            public static void WithComputer()
            {

            }

            unsafe public static void WithPlayer()
            {
                SoundPlayer Sounds = new SoundPlayer(Resources.GameMusic);
                if (Settings.Default.Music) { Sounds.PlayLooping(); }

                int[,] field = new int[3, 3] { {0, 0, 0}, {0, 0, 0}, {0, 0, 0} };
                int[] currentPosition = new int[] { 0, 0 };
                int[] currentPositionReal = new int[] { 1, 0 };
                int step = 1;

                Program.Render("Game", 0, field);
                Console.CursorVisible = true;
                Console.SetCursorPosition(currentPositionReal[0], currentPositionReal[1]);
                while (true)
                {
                    /* Выполнение действия при нажатии Enter */
                    if (Program.Controls("Game", ref currentPosition, ref currentPositionReal))
                    {
                        if (field[currentPosition[0], currentPosition[1]] == 0)
                        {
                            field[currentPosition[0], currentPosition[1]] = step;

                            if (Game.Singleplayer.Win(step, field))
                            {
                                Sounds.Stop();
                                break;
                            }

                            switch (step)
                            {
                                case 1: step = 2; break;
                                case 2: step = 1; break;
                            }
                        }

                    }
                    
                    Program.Render("Game", step, field);

                    if (Program.debugMode)
                    {
                        Console.WriteLine("currentPosition: ({0}, {1})", currentPosition[0], currentPosition[1]);
                        Console.WriteLine("currentPositionReal: ({0}, {1})", currentPositionReal[0], currentPositionReal[1]);
                        Console.WriteLine("field[{0}, {1}]: {2}", currentPosition[0], currentPosition[1], field[currentPosition[0], currentPosition[1]]);
                        Console.WriteLine("step: {0}", step);
                    }

                    Console.SetCursorPosition(currentPositionReal[0], currentPositionReal[1]);
                }
            }

            static bool Win(int step, int[,] field)
            {
                /* Проверка строк */
                for (int i = 0; i < 3; i++)
                {
                    if ((field[i, 0] == step) && (field[i, 1] == step) && (field[i, 2] == step))
                    {
                        Program.Render("Win", parametr: step);
                        while (true) { if (Console.ReadKey().Key == ConsoleKey.Enter) { return true; } Program.Render("Win", parametr: step); }
                    }
                }

                /* Проверка столбцов */
                for (int i = 0; i < 3; i++)
                {
                    if ((field[0, i] == step) && (field[1, i] == step) && (field[2, i] == step))
                    {
                        Program.Render("Win", parametr: step);
                        while (true) { if (Console.ReadKey().Key == ConsoleKey.Enter) { return true; } Program.Render("Win", parametr: step); }
                    }
                }

                /* Проверка диагоналей */
                if ((field[0, 0] == step) && (field[1, 1] == step) && (field[2, 2] == step))
                {
                    Program.Render("Win", parametr: 1);
                    while (true) { if (Console.ReadKey().Key == ConsoleKey.Enter) { return true; } Program.Render("Win", parametr: step); }
                }

                if ((field[0, 2] == step) && (field[1, 1] == step) && (field[2, 0] == step))
                {
                    Program.Render("Win", parametr: step);
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        while (true) { if (Console.ReadKey().Key == ConsoleKey.Enter) { return true; } Program.Render("Win", parametr: step); }
                }

                /* Проверка ничьей */
                int filledCells = 0;
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (field[i, j] != 0) { filledCells += 1; Console.Title = Convert.ToString(filledCells); }

                        if (filledCells == 9)
                        {
                            Program.Render("Win", parametr: 0);
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                                while (true) { if (Console.ReadKey().Key == ConsoleKey.Enter) { return true; } Program.Render("Win", parametr: 0); }
                        }
                    }
                }

                /* Возращение результата, если ни одна проверка не сработала */
                return false;
            }
        }
        public static class Multiplayer
        {

        }
    }
}
