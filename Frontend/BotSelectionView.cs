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
            #region Constructors

            public BotSelectionView(ustring title)
            {
                Title = title;

                _btnBack = new Button("Back")
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

                _btnLessBots = new Button("-")
                               {
                                   Width = 5,
                                   X     = Pos.Center() - 7,
                                   Y     = Pos.Center() - 2,
                                   Clicked = () => _lblNumBots.Text =
                                                 Helpers.DecrementStringNumber(_lblNumBots.Text, 0)
                               };

                _btnLessDifficult = new Button("-")
                                    {
                                        Width = 5,
                                        X     = Pos.Center() - 7,
                                        Y     = Pos.Center() + 3,
                                        Clicked = () => _lblBotDifficulty.Text =
                                                      Helpers.DecrementStringNumber(_lblBotDifficulty
                                                                  .Text,
                                                               0
                                                          )
                                    };

                _btnMoreBots = new Button("+")
                               {
                                   Width = 5,
                                   X     = Pos.Center() + 2,
                                   Y     = Pos.Center() - 2,
                                   Clicked = () => _lblNumBots.Text =
                                                 Helpers.IncrementStringNumber(_lblNumBots.Text, 5)
                               };

                _btnMoreDifficult = new Button("+")
                                    {
                                        Width = 5,
                                        X     = Pos.Center() + 2,
                                        Y     = Pos.Center() + 3,
                                        Clicked = () => _lblBotDifficulty.Text =
                                                      Helpers.IncrementStringNumber(_lblBotDifficulty
                                                                  .Text,
                                                               5
                                                          )
                                    };

                _btnNext = new Button("Next")
                           {
                               Width         = 10,
                               X             = Pos.Center() + 2,
                               Y             = Pos.Percent(75),
                               TextAlignment = TextAlignment.Justified,
                               Clicked = () =>
                                         {
                                             Application.RequestStop();
                                             Application.Run(new TextSelectionView("Singleplayer"));
                                             Ui._numBots       = Convert.ToInt32(_lblNumBots.Text);
                                             Ui._botDifficulty = Convert.ToInt32(_lblBotDifficulty.Text);
                                         }
                           };

                Width  = Dim.Fill();
                Height = Dim.Fill();

                _lblSubMenuTitle = new Label("Bot Selection") {X = 1};
                _lblNumBots = new Label("0") {X = Pos.Center(), Y = Pos.Center() - 2, Width = 1, Visible = true};
                _lblNumBotsTxt = new Label("Number of bots") {X = Pos.Center(), Y = Pos.Center() - 3, Visible = true};
                _lblBotDifficulty = new Label("0") {X = Pos.Center(), Y = Pos.Center() + 3, Width = 1, Visible = true};

                _lblBotDifficultyTxt =
                    new Label("Bot difficulty") {X = Pos.Center(), Y = Pos.Center() + 2, Visible = true};

                Add(_lblSubMenuTitle,
                    _lblNumBots,
                    _lblBotDifficulty,
                    _btnLessBots,
                    _btnMoreBots,
                    _btnLessDifficult,
                    _btnMoreDifficult,
                    _lblNumBotsTxt,
                    _btnBack,
                    _btnNext,
                    _lblBotDifficultyTxt
                   );
            }

            #endregion

            #region Fields

            private readonly Button _btnBack;

            private readonly Button _btnLessBots;

            private readonly Button _btnLessDifficult;

            private readonly Button _btnMoreBots;

            private readonly Button _btnMoreDifficult;

            private readonly Button _btnNext;

            private readonly Label _lblBotDifficulty;

            private readonly Label _lblBotDifficultyTxt;

            private readonly Label _lblNumBots;

            private readonly Label _lblNumBotsTxt;
            private readonly Label _lblSubMenuTitle;

            #endregion
        }
    }
}