#region

using System;
using System.Collections.Generic;
using Terminal.Gui;

#endregion


namespace KeyboardRacer
{
    namespace Frontend
    {
        public class PostGameView : Window
        {
            #region Properties

            public Button BtnBack { get; }

            #endregion

            #region Constructors

            public PostGameView(List<PostGameStats> stats)
            {
                Console.Clear();
                Title  = "Post game view";
                Width  = Dim.Fill();
                Height = Dim.Fill();

                BtnBack = new Button("Quit")
                          {
                              X = Pos.Center(), Y = Pos.Percent(75), Width = 8, TextAlignment = TextAlignment.Justified
                          };

                BtnBack.Clicked += Application.RequestStop;

                int i = 1;

                foreach (PostGameStats postGameStats in stats)
                {
                    Add(new
                        Label($"{i}# Place: {postGameStats.Name}  {postGameStats.Wpm} wpm  {postGameStats.TotalErrors} total errors"
                             ) {X = Pos.Center(), Y = Pos.Center() - 10 + 2 * (i - 1)}
                       );

                    ++i;
                }

                Add(BtnBack);
            }

            #endregion
        }
    }
}