#region

using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class MainMenuView : Window
        {
            #region Constructors

            public MainMenuView()
            {
                Title  = "Main menu";
                Width  = Dim.Fill();
                Height = Dim.Fill();

                Add(singlePayer,
                    localGame,
                    multiplayer,
                    statistics,
                    settings,
                    quit
                   );
            }

            #endregion

            #region Fields

            private readonly Button localGame = new Button("Local game")
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

            private readonly Button multiplayer = new Button("Multiplayer")
                                                  {
                                                      X             = Pos.Center(),
                                                      Y             = 5,
                                                      Width         = 20,
                                                      TextAlignment = TextAlignment.Justified
                                                  };

            private readonly Button quit = new Button("Quit")
                                           {
                                               X             = Pos.Center(),
                                               Y             = 11,
                                               Width         = 20,
                                               TextAlignment = TextAlignment.Justified,
                                               Clicked       = Application.RequestStop
                                           };

            private readonly Button settings = new Button("Settings")
                                               {
                                                   X             = Pos.Center(),
                                                   Y             = 9,
                                                   Width         = 20,
                                                   TextAlignment = TextAlignment.Justified
                                               };

            private readonly Button singlePayer = new Button("Singleplayer")
                                                  {
                                                      X             = Pos.Center(),
                                                      Y             = 1,
                                                      Width         = 20,
                                                      TextAlignment = TextAlignment.Justified,
                                                      Clicked = () =>
                                                                {
                                                                    Application.RequestStop();

                                                                    Application.Run(new BotSelectionView("Singleplayer")
                                                                        );
                                                                }
                                                  };

            private readonly Button statistics = new Button("Statistics")
                                                 {
                                                     X             = Pos.Center(),
                                                     Y             = 7,
                                                     Width         = 20,
                                                     TextAlignment = TextAlignment.Justified
                                                 };

            #endregion
        }
    }
}