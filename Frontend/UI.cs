using Terminal.Gui;


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class BotSelectionView : Window { }

        public abstract class MatchBrowserView : Window { }

        public class MatchBrowserLanView : MatchBrowserView { }

        public class MatchBrowserOnlineView : MatchBrowserView { }

        public class TextSelectionView : Window { }

        public class WaitScreenView : Window { }

        public class PostGameView : Window { }

        public class StatisticsView : Window { }

        public class SettingsView : Window { }

        public class MainMenuView : Window
        {
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
                                                      TextAlignment = TextAlignment.Justified
                                                  };

            private readonly Button statistics = new Button("Statistics")
                                                 {
                                                     X             = Pos.Center(),
                                                     Y             = 7,
                                                     Width         = 20,
                                                     TextAlignment = TextAlignment.Justified
                                                 };

            private readonly Window win = new Window("Main menu") {Width = Dim.Fill(), Height = Dim.Fill()};

            #endregion

            #region Constructors

            public MainMenuView()
            {
                win.Add(singlePayer,
                        localGame,
                        multiplayer,
                        statistics,
                        settings,
                        quit
                       );

                Add(win);
            }

            #endregion
        }

        public class Ui
        {
            public static void Init()
            {
                Application.Run<MainMenuView>();
            }
        }
    }
}