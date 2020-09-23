#region

using NStack;
using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class TextSelectionView : Window
        {
            private static readonly Label subMenuTitle = new Label("Text Selection") {X = 1};

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

            private readonly CheckBox CkbxFromDifficulty =
                new CheckBox("Fom path", false) {X = Pos.Center() + 15, Y = Pos.Center() + 2};

            private readonly CheckBox CkbxFromPath =
                new CheckBox("From path", false) {X = Pos.Center() + 15, Y = Pos.Center()};


            private readonly CheckBox CkbxRandom =
                new CheckBox("Random text", true) {X = Pos.Center() + 15, Y = Pos.Center() - 2,};


            public TextSelectionView(ustring title)
            {
                Title  = title;
                Width  = Dim.Fill();
                Height = Dim.Fill();

                Add(subMenuTitle,
                    BtnBack,
                    BtnNext,
                    subMenuTitle,
                    CkbxRandom,
                    CkbxFromPath,
                    CkbxFromDifficulty
                   );
            }
        }
    }
}