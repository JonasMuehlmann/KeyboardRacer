#region

using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class MainMenuView : Window
        {
            #region Fields

            private readonly Button _localGame;

            private readonly Button _multiplayer;

            private readonly Button _quit;

            private readonly Button _settings;

            private readonly Button _singlePayer;

            private readonly Button _statistics;

            #endregion

            #region Constructors

            public MainMenuView()
            {
                Title = "Main menu";

                _statistics = new Button("Statistics")
                              {
                                  X = Pos.Center(), Y = 7, Width = 20, TextAlignment = TextAlignment.Justified
                              };

                _singlePayer = new Button("Singleplayer")
                               {
                                   X             = Pos.Center(),
                                   Y             = 1,
                                   Width         = 20,
                                   TextAlignment = TextAlignment.Justified,
                                   Clicked = () =>
                                             {
                                                 Application.RequestStop();

                                                 Application.Run(new BotSelectionView("Singleplayer"));
                                                 Ui._selectedMenuEntry = "Singleplayer";
                                             }
                               };

                _settings = new Button("Settings")
                            {
                                X = Pos.Center(), Y = 9, Width = 20, TextAlignment = TextAlignment.Justified
                            };

                _quit = new Button("Quit")
                        {
                            X             = Pos.Center(),
                            Y             = 11,
                            Width         = 20,
                            TextAlignment = TextAlignment.Justified,
                            Clicked       = Application.RequestStop
                        };

                _multiplayer = new Button("Multiplayer")
                               {
                                   X = Pos.Center(), Y = 5, Width = 20, TextAlignment = TextAlignment.Justified
                               };

                _localGame = new Button("Local game")
                             {
                                 X             = Pos.Center(),
                                 Y             = 3,
                                 Width         = 20,
                                 TextAlignment = TextAlignment.Justified,
                                 Clicked = () =>
                                           {
                                               Application.RequestStop();
                                               Application.Run<MatchBrowserLanView>();
                                           }
                             };

                Width  = Dim.Fill();
                Height = Dim.Fill();

                Add(_singlePayer,
                    _localGame,
                    _multiplayer,
                    _statistics,
                    _settings,
                    _quit
                   );
            }

            #endregion
        }
    }
}