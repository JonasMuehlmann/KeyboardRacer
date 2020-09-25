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
        public class TextSelectionView : Window
        {
            #region Constructors

            public TextSelectionView(ustring title)
            {
                Title = title;
                // TODO: Validate existence of file
                _textFieldFilePath = new TextField("") {X = Pos.Center(), Y = Pos.Center() + 1, Width = 30};


                Width = Dim.Fill();

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


                _btnLessDifficult = new Button("-")
                                    {
                                        Width = 5,
                                        X     = Pos.Center() - 7,
                                        Y     = Pos.Center(),
                                        Clicked = () => _lblTextDifficulty.Text =
                                                      Helpers.DecrementStringNumber(_lblTextDifficulty
                                                                  .Text,
                                                               0
                                                          )
                                    };

                _btnMoreDifficult = new Button("+")
                                    {
                                        Width = 5,
                                        X     = Pos.Center() + 2,
                                        Y     = Pos.Center(),
                                        Clicked = () => _lblTextDifficulty.Text =
                                                      Helpers.IncrementStringNumber(_lblTextDifficulty
                                                                  .Text,
                                                               100
                                                          )
                                    };


                var _radioGrpTextChoice =
                    new RadioGroup(new ustring[] {"Random text", "From Difficulty", "From path"})
                    {
                        X = Pos.Center() + 15, Y = Pos.Center()
                    };

                Height = Dim.Fill();

                _lblSubMenuTitle = new Label("Text Selection") {X = 1};

                _lblTextDifficultyTxt =
                    new Label("Text difficulty") {X = Pos.Center(), Y = Pos.Center() - 1, Visible = true};

                _lblTextDifficulty = new Label("0")
                                     {
                                         X             = Pos.Center(),
                                         Y             = Pos.Center(),
                                         Width         = 3,
                                         Visible       = true,
                                         TextAlignment = TextAlignment.Centered
                                     };

                _btnNext = new Button("Next")
                           {
                               Width         = 10,
                               X             = Pos.Center() + 2,
                               Y             = Pos.Percent(75),
                               TextAlignment = TextAlignment.Justified,
                               Clicked = () =>
                                         {
                                             Ui._selectedFile            = Convert.ToString(_textFieldFilePath.Text);
                                             Ui._wantsRandomText         = _radioGrpTextChoice.SelectedItem == 0;
                                             Ui._wantsTextFromDifficulty = _radioGrpTextChoice.SelectedItem == 1;
                                             Ui._textDifficulty          = Convert.ToInt32(_lblTextDifficulty.Text);
                                             Application.RequestStop();
                                         }
                           };

                Add(_lblSubMenuTitle,
                    _lblSubMenuTitle,
                    _lblTextDifficulty,
                    _lblTextDifficultyTxt,
                    _btnLessDifficult,
                    _btnMoreDifficult,
                    _textFieldFilePath,
                    _radioGrpTextChoice,
                    _btnBack,
                    _btnNext
                   );
            }

            #endregion

            #region Fields

            private readonly Label _lblSubMenuTitle;

            private readonly Label _lblTextDifficultyTxt;

            private readonly Label _lblTextDifficulty;

            private readonly TextField _textFieldFilePath;

            private readonly Button _btnBack;

            private readonly Button _btnLessDifficult;

            private readonly Button _btnMoreDifficult;

            private readonly Button _btnNext;

            #endregion
        }
    }
}