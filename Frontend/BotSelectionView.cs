#region

using System;
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
            #region Properties

            public Button BtnBack { get; }

            public Button BtnLessBots { get; }

            public Button BtnLessDifficult { get; }

            public Button BtnMoreBots { get; }

            public Button BtnMoreDifficult { get; }

            public Button BtnNext { get; }

            public Label LblBotDifficulty { get; }

            public Label LblBotDifficultyTxt { get; }

            public Label LblNumBots { get; }

            public Label LblNumBotsTxt { get; }

            public Label LblSubMenuTitle { get; }

            #endregion

            #region Constructors

            public BotSelectionView(ustring title)
            {
                Title = title;

                BtnBack = new Button("Back")
                          {
                              X             = Pos.Center() - 12,
                              Y             = Pos.Percent(75),
                              Width         = 10,
                              TextAlignment = TextAlignment.Justified
                          };

                BtnBack.Clicked += () =>
                                   {
                                       Ui.NumBots       = Convert.ToInt32(LblNumBots.Text);
                                       Ui.BotDifficulty = Convert.ToInt32(LblBotDifficulty.Text);
                                       Application.RequestStop();
                                       Application.Run(new MainMenuView());
                                   };

                BtnLessBots = new Button("-") {Width = 5, X = Pos.Center() - 7, Y = Pos.Center() - 2};

                BtnLessBots.Clicked += () => LblNumBots.Text =
                                           Helpers.DecrementStringNumber(LblNumBots.Text, 0);

                BtnLessDifficult = new Button("-") {Width = 5, X = Pos.Center() - 7, Y = Pos.Center() + 3};

                BtnLessDifficult.Clicked += () => LblBotDifficulty.Text =
                                                Helpers.DecrementStringNumber(LblBotDifficulty
                                                                                 .Text,
                                                                              0
                                                                             );

                BtnMoreBots = new Button("+") {Width = 5, X = Pos.Center() + 2, Y = Pos.Center() - 2};

                BtnMoreBots.Clicked += () => LblNumBots.Text =
                                           Helpers.IncrementStringNumber(LblNumBots.Text, 4);

                BtnMoreDifficult = new Button("+") {Width = 5, X = Pos.Center() + 2, Y = Pos.Center() + 3};

                BtnMoreDifficult.Clicked += () => LblBotDifficulty.Text =
                                                Helpers.IncrementStringNumber(LblBotDifficulty
                                                                                 .Text,
                                                                              9
                                                                             );

                BtnNext = new Button("Next")
                          {
                              Width         = 10,
                              X             = Pos.Center() + 2,
                              Y             = Pos.Percent(75),
                              TextAlignment = TextAlignment.Justified
                          };

                BtnNext.Clicked += () =>
                                   {
                                       Ui.NumBots       = Convert.ToInt32(LblNumBots.Text);
                                       Ui.BotDifficulty = Convert.ToInt32(LblBotDifficulty.Text);
                                       Application.RequestStop();
                                       Application.Run(new TextSelectionView("Singleplayer"));
                                   };

                Width  = Dim.Fill();
                Height = Dim.Fill();

                LblSubMenuTitle = new Label("Bot Selection") {X = 1};

                LblNumBotsTxt = new Label("Number of bots") {X = Pos.Center(), Y = Pos.Center() - 3, Visible = true};

                LblNumBots = new Label(Convert.ToString(Ui.NumBots))
                             {
                                 X = Pos.Center(), Y = Pos.Center() - 2, Width = 1, Visible = true
                             };


                LblBotDifficultyTxt =
                    new Label("Bot difficulty") {X = Pos.Center(), Y = Pos.Center() + 2, Visible = true};

                LblBotDifficulty = new Label(Convert.ToString(Ui.BotDifficulty))
                                   {
                                       X = Pos.Center(), Y = Pos.Center() + 3, Width = 1, Visible = true
                                   };

                Add(LblSubMenuTitle,
                    LblNumBots,
                    LblBotDifficulty,
                    BtnLessBots,
                    BtnMoreBots,
                    BtnLessDifficult,
                    BtnMoreDifficult,
                    LblNumBotsTxt,
                    BtnBack,
                    BtnNext,
                    LblBotDifficultyTxt
                   );
            }

            #endregion
        }
    }
}