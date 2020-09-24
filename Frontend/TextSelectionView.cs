#region

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
            private static readonly Label LblSubMenuTitle = new Label("Text Selection") {X = 1};

            private static readonly Label LblTextDifficultyTxt =
                new Label("Bot difficulty") {X = Pos.Center(), Y = Pos.Center() - 2, Visible = true};

            private static readonly Label LblTextDifficulty =
                new Label("0") {X = Pos.Center(), Y = Pos.Center() - 1, Width = 1, Visible = true};

            private static readonly OpenDialog FileDialog_ = new OpenDialog("foo", "bar");

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

            private readonly Button BtnChoosePath = new Button("Choose file")
                                                    {
                                                        X = Pos.Center(),
                                                        Y = Pos.Center(),
                                                        Clicked = () =>
                                                                  {
                                                                      Application.RequestStop();
                                                                      Application.Run(FileDialog_);

                                                                      while (FileDialog_.Running)
                                                                      {
                                                                          ;
                                                                      }
                                                                  }
                                                    };

            private readonly Button BtnLessDifficult = new Button("-")
                                                       {
                                                           Width = 5,
                                                           X     = Pos.Center() - 7,
                                                           Y     = Pos.Center() - 1,
                                                           Clicked = () => LblTextDifficulty.Text =
                                                                         Helpers.DecrementStringNumber(LblTextDifficulty
                                                                                     .Text,
                                                                                  0
                                                                             )
                                                       };

            private readonly Button BtnMoreDifficult = new Button("+")
                                                       {
                                                           Width = 5,
                                                           X     = Pos.Center() + 2,
                                                           Y     = Pos.Center() - 1,
                                                           Clicked = () => LblTextDifficulty.Text =
                                                                         Helpers.IncrementStringNumber(LblTextDifficulty
                                                                                     .Text,
                                                                                  100
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
                                                                Application.Run();
                                                            }
                                              };


            private readonly RadioGroup RadioGrpTextChoice =
                new RadioGroup(new ustring[] {"Random text", "From path", "From Difficulty"})
                {
                    X = Pos.Center() + 15, Y = Pos.Center()
                };

            #endregion

            #region Constructors

            public TextSelectionView(ustring title)
            {
                FileDialog_.Title = title;

                Width = Dim.Fill();

                Height = Dim.Fill();


                Add(LblSubMenuTitle,
                    BtnBack,
                    BtnNext,
                    LblSubMenuTitle,
                    RadioGrpTextChoice,
                    LblTextDifficulty,
                    LblTextDifficultyTxt,
                    BtnMoreDifficult,
                    BtnLessDifficult,
                    BtnChoosePath
                   );
            }

            #endregion
        }
    }
}