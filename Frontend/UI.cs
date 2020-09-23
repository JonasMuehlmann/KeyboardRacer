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
            public static void Init()
            {
                Console.CursorVisible = false;
                Application.Run<MainMenuView>();
                Console.CursorVisible = true;
            }
        }
    }
}