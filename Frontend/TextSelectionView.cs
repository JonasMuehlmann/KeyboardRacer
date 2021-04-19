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
            #region Properties

            public Button BtnBack { get; }

            public Button BtnLessDifficult { get; }

            public Button BtnMoreDifficult { get; }

            public Button BtnNext { get; }

            public Label LblSubMenuTitle { get; }

            public Label LblTextDifficulty { get; }

            public Label LblTextDifficultyTxt { get; }

            public TextField TextFieldFilePath { get; }

            #endregion

            #region Constructors

            public TextSelectionView(ustring title)
            {
                Title = title;

                // TODO: Validate existence of file
                TextFieldFilePath =
                    new TextField(Ui.SelectedFile) {X = Pos.Center(), Y = Pos.Center() + 1, Width = 30};


                Width = Dim.Fill();


                BtnLessDifficult = new Button("-") {Width = 5, X = Pos.Center() - 7, Y = Pos.Center()};

                BtnLessDifficult.Clicked += () => LblTextDifficulty.Text =
                                                Helpers.DecrementStringNumber(LblTextDifficulty
                                                                                 .Text,
                                                                              0
                                                                             );

                BtnMoreDifficult = new Button("+") {Width = 5, X = Pos.Center() + 2, Y = Pos.Center()};

                BtnMoreDifficult.Clicked += () => LblTextDifficulty.Text =
                                                Helpers.IncrementStringNumber(LblTextDifficulty
                                                                                 .Text,
                                                                              100
                                                                             );


                RadioGroup _radioGrpTextChoice =
                    new RadioGroup(new ustring[] {"Random text", "From Difficulty", "From path"})
                    {
                        X            = Pos.Center() + 15,
                        Y            = Pos.Center(),
                        SelectedItem = Ui.WantsRandomText ? 0 : Ui.WantsTextFromDifficulty ? 1 : 2
                    };

                Height = Dim.Fill();

                LblSubMenuTitle = new Label("Text Selection") {X = 1};

                LblTextDifficultyTxt =
                    new Label("Text difficulty") {X = Pos.Center(), Y = Pos.Center() - 2, Visible = true};

                LblTextDifficulty = new Label(Convert.ToString(Ui.TextDifficulty))
                                    {
                                        X             = Pos.Center(),
                                        Y             = Pos.Center(),
                                        Width         = 3,
                                        Visible       = true,
                                        TextAlignment = TextAlignment.Centered
                                    };

                BtnBack = new Button("Back")
                          {
                              X             = Pos.Center() - 12,
                              Y             = Pos.Percent(75),
                              Width         = 10,
                              TextAlignment = TextAlignment.Justified
                          };

                BtnBack.Clicked += () =>
                                   {
                                       Ui.SelectedFile            = Convert.ToString(TextFieldFilePath.Text);
                                       Ui.WantsRandomText         = _radioGrpTextChoice.SelectedItem == 0;
                                       Ui.WantsTextFromDifficulty = _radioGrpTextChoice.SelectedItem == 1;
                                       Ui.TextDifficulty          = Convert.ToInt32(LblTextDifficulty.Text);
                                       Application.RequestStop();
                                       Application.Run(new BotSelectionView(title));
                                   };

                BtnNext = new Button("Next")
                          {
                              Width         = 10,
                              X             = Pos.Center() + 2,
                              Y             = Pos.Percent(75),
                              TextAlignment = TextAlignment.Justified
                          };

                BtnNext.Clicked += () =>
                                   {
                                       Ui.SelectedFile            = Convert.ToString(TextFieldFilePath.Text);
                                       Ui.WantsRandomText         = _radioGrpTextChoice.SelectedItem == 0;
                                       Ui.WantsTextFromDifficulty = _radioGrpTextChoice.SelectedItem == 1;
                                       Ui.TextDifficulty          = Convert.ToInt32(LblTextDifficulty.Text);
                                       Application.RequestStop();
                                   };

                Add(LblSubMenuTitle,
                    LblSubMenuTitle,
                    LblTextDifficulty,
                    LblTextDifficultyTxt,
                    BtnLessDifficult,
                    BtnMoreDifficult,
                    TextFieldFilePath,
                    _radioGrpTextChoice,
                    BtnBack,
                    BtnNext
                   );
            }

            #endregion
        }
    }
}