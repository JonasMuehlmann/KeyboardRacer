#region

using System;
using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class MainMenuView : Window
        {
            #region Properties

            public Button LocalGame { get; }

            public Button Multiplayer { get; }

            public Button Quit { get; }

            public Button Settings { get; }

            public Button SinglePayer { get; }

            public Button Statistics { get; }

            #endregion

            #region Constructors

            public MainMenuView()
            {
                Title = "Main menu";

                Statistics = new Button("Statistics")
                             {
                                 X = Pos.Center(), Y = 7, Width = 20, TextAlignment = TextAlignment.Justified
                             };

                SinglePayer = new Button("Singleplayer")
                              {
                                  X             = Pos.Center(),
                                  Y             = 1,
                                  Width         = 20,
                                  TextAlignment = TextAlignment.Justified,
                                  Clicked = () =>
                                            {
                                                Application.RequestStop();

                                                Application.Run(new BotSelectionView("Singleplayer"));
                                                Ui.SelectedMenuEntry = "Singleplayer";
                                            }
                              };

                Settings = new Button("Settings")
                           {
                               X = Pos.Center(), Y = 9, Width = 20, TextAlignment = TextAlignment.Justified
                           };

                Quit = new Button("Quit")
                       {
                           X             = Pos.Center(),
                           Y             = 11,
                           Width         = 20,
                           TextAlignment = TextAlignment.Justified,
                           Clicked = () =>
                                     {
                                         Console.Clear();
                                         Environment.Exit(0);
                                     }
                       };

                Multiplayer = new Button("Multiplayer")
                              {
                                  X = Pos.Center(), Y = 5, Width = 20, TextAlignment = TextAlignment.Justified
                              };

                LocalGame = new Button("Local game")
                            {
                                X             = Pos.Center(),
                                Y             = 3,
                                Width         = 20,
                                TextAlignment = TextAlignment.Justified,
                                Clicked = () =>
                                          {
                                              Application.RequestStop();
                                              Application.Run(new MatchBrowserLanView());
                                          }
                            };

                Width  = Dim.Fill();
                Height = Dim.Fill();

                Add(SinglePayer,
                    LocalGame,
                    Multiplayer,
                    Statistics,
                    Settings,
                    Quit
                   );
            }

            #endregion
        }
    }
}