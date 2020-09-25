#region

using System;
using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class Ui
        {
            public static string _selectedMenuEntry;
            public static int    _numBots;
            public static int    _botDifficulty;
            public static bool   _wantsRandomText;
            public static bool   _wantsTextFromDifficulty;
            public static string _selectedFile;
            public static int    _textDifficulty;


            public static void Init()
            {
                Console.CursorVisible = false;
                Application.Run<MainMenuView>();
                Console.CursorVisible = true;
            }
        }
    }
}