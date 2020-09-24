#region

using KeyboardRacer.Fronted;
using NStack;
using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class BotSelectionView : Window
        {
            private static readonly Label LblSubMenuTitle = new Label("Bot Selection") {X = 1};

            private static readonly Label LblNumBots =
                new Label("0") {X = Pos.Center(), Y = Pos.Center() - 2, Width = 1, Visible = true};

            private static readonly Label LblNumBotsTxt =
                new Label("Number of bots") {X = Pos.Center(), Y = Pos.Center() - 3, Visible = true};

            private static readonly Label LblBotDifficulty =
                new Label("0") {X = Pos.Center(), Y = Pos.Center() + 3, Width = 1, Visible = true};

            private static readonly Label LblBotDifficultyTxt =
                new Label("Bot difficulty") {X = Pos.Center(), Y = Pos.Center() + 2, Visible = true};

            #region Fields

            private readonly Button BtnBack = new Button("Back")
                                              {
                                                  X             = Pos.Center() - 12,
                                                  Y             = Pos.Percent(75),
                                                  Width         = 10,
                                                  TextAlignment = TextAlignment.Justified,
                                                  Clicked = () =>
                                                            {
                                                                Application.RequestStop();
                                                                Application.Run(new MainMenuView());
                                                            }
                                              };

            private readonly Button BtnLessBots = new Button("-")
                                                  {
                                                      Width = 5,
                                                      X     = Pos.Center() - 7,
                                                      Y     = Pos.Center() - 2,
                                                      Clicked = () => LblNumBots.Text =
                                                                    Helpers.DecrementStringNumber(LblNumBots.Text, 0)
                                                  };

            private readonly Button BtnLessDifficult = new Button("-")
                                                       {
                                                           Width = 5,
                                                           X     = Pos.Center() - 7,
                                                           Y     = Pos.Center() + 3,
                                                           Clicked = () => LblBotDifficulty.Text =
                                                                         Helpers.DecrementStringNumber(LblBotDifficulty
                                                                                     .Text,
                                                                                  0
                                                                             )
                                                       };

            private readonly Button BtnMoreBots = new Button("+")
                                                  {
                                                      Width = 5,
                                                      X     = Pos.Center() + 2,
                                                      Y     = Pos.Center() - 2,
                                                      Clicked = () => LblNumBots.Text =
                                                                    Helpers.IncrementStringNumber(LblNumBots.Text, 5)
                                                  };

            private readonly Button BtnMoreDifficult = new Button("+")
                                                       {
                                                           Width = 5,
                                                           X     = Pos.Center() + 2,
                                                           Y     = Pos.Center() + 3,
                                                           Clicked = () => LblBotDifficulty.Text =
                                                                         Helpers.IncrementStringNumber(LblBotDifficulty
                                                                                     .Text,
                                                                                  5
                                                                             )
                                                       };

            private readonly Button BtnNext = new Button("Next")
                                              {
                                                  Width         = 10,
                                                  X             = Pos.Center() + 2,
                                                  Y             = Pos.Percent(75),
                                                  TextAlignment = TextAlignment.Justified,
                                                  Clicked = () =>
                                                            {
                                                                Application.RequestStop();
                                                                Application.Run(new TextSelectionView("Singleplayer"));
                                                            }
                                              };

            #endregion

            #region Constructors

            public BotSelectionView(ustring title)
            {
                Title  = title;
                Width  = Dim.Fill();
                Height = Dim.Fill();

                Add(LblSubMenuTitle,
                    LblNumBots,
                    LblBotDifficulty,
                    BtnBack,
                    BtnNext,
                    BtnLessBots,
                    BtnMoreBots,
                    BtnLessDifficult,
                    BtnMoreDifficult,
                    LblNumBotsTxt,
                    LblBotDifficultyTxt
                   );
            }

            #endregion
        }
    }
}