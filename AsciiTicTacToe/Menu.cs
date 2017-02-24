using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace AsciiTicTacToe
{
    class Menu
    {
        unsafe public static void MainMenu()
        {
            SoundPlayer Sounds = new SoundPlayer(Resources.MenuMusic);
            if (Settings.Default.Music) { Sounds.PlayLooping(); }
            int[] currentPosition = new int[2] {0, 0};
            Program.Render("Menu", parametr: 0);
            while (true)
            {
                if (Program.Controls("Menu", currentPosition: ref currentPosition))
                {
                    switch (currentPosition[0])
                    {
                        case 0:
                            Sounds.Stop();
                            Game.Singleplayer.WithPlayer();
                            if (Settings.Default.Music) { Sounds.PlayLooping(); }
                            break;
                        case 1: Menu.SettingsMenu(); break;
                        case 2: Environment.Exit(0); break;
                    }
                }
                Program.Render("Menu", parametr: currentPosition[0]);
                if (Program.debugMode)
                {
                    Console.WriteLine("currentPosition[0]: {0}", currentPosition[0]);
                }
            }
        }

        public static void SettingsMenu()
        {
            SoundPlayer Sounds = new SoundPlayer(Resources.MenuMusic);
            int[] currentPosition = new int[2] { 0, 0 };
            Program.Render("Settings", parametr: 0);
            while (true)
            {
                if (Program.Controls("Settings", currentPosition: ref currentPosition))
                {
                    switch (currentPosition[0])
                    {
                        case 0:
                            if (Settings.Default.Music)
                            {
                                Sounds.Stop();
                                Settings.Default.Music = false;
                            } else
                            {
                                Sounds.PlayLooping();
                                Settings.Default.Music = true;
                            }
                            
                            break;
                        case 1: break;
                        case 2: break;
                        case 3: break;
                        case 4: return;
                    }
                }
                Program.Render("Settings", parametr: currentPosition[0]);
                if (Program.debugMode)
                {
                    Console.WriteLine("currentPosition[0]: {0}", currentPosition[0]);
                }
            }
        }
    }
}
