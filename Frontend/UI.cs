#region

using System;
using System.Collections.Generic;
using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class Ui
        {
            #region Properties

            public static string SelectedMenuEntry { get; set; }

            public static int NumBots { get; set; }

            public static int BotDifficulty { get; set; }

            // Default value for the text selection
            public static bool WantsRandomText { get; set; } = true;

            public static bool WantsTextFromDifficulty { get; set; }

            public static string SelectedFile { get; set; } = "";

            public static int TextDifficulty { get; set; }

            #endregion


            public static void ShowMainMenu()
            {
                Console.Clear();
                Console.CursorVisible = false;
                Application.Run(new MainMenuView());
                Console.CursorVisible = true;
            }


            public static void ShowPostgameView(List<PostGameStats> stats)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Application.Run(new PostGameView(stats));
                Console.CursorVisible = true;
            }
        }
    }
}