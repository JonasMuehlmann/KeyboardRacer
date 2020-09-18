using System;
using System.Collections.Generic;
using System.Linq;


namespace LEA
{
    public class Player : Participant
    {
        private readonly Client                     _networkClient;
        private          Dictionary<string, string> _competitorColors;
        private          int                        _curChar;
        private          int                        _curErrors;
        private          Stack<char>                _typedText;

        #region Properties

        public int CurErrors
        {
            get => _curErrors;
            set => _curErrors = value;
        }

        public Dictionary<string, string> CompetitorColors
        {
            get => _competitorColors;
            set => _competitorColors = value;
        }

        public int CurChar
        {
            get => _curChar;
            set => _curChar = value;
        }

        public Stack<char> TypedText
        {
            get => _typedText;
            set => _typedText = value;
        }

        public Client NetworkClient
        {
            get => _networkClient;
        }

        #endregion

        #region Constructors

        public Player(string name, string color, Race currentRace) :
            base(name, color, currentRace)
        {
            CurErrors         = 0;
            TypedText         = new Stack<char>(CurrentRace.Text.Length);
            _networkClient    = new Client();
            CurErrors         = 0;
            CurChar           = 0;
            _competitorColors = new Dictionary<string, string>();
        }

        #endregion


        public override int GetProgress()
        {
            double correctChars = TypedText.Count;

            return Convert.ToInt32(100 * (correctChars / CurrentRace.Text.Length));
        }


        public override bool HasCompletedText()
        {
            return TypedText.Count == CurrentRace.Text.Length && CurErrors == 0;
        }


        public void SetCompetitorColors()
        {
            CurrentRace.Participants.ForEach(participant => CompetitorColors.Add(participant.Name, participant.Color));
            CompetitorColors.Remove(Name);
        }


        /// <summary>
        /// A frame fragment is a 'race lane' in the client's view of the race<para />
        /// 
        /// <para>Returns:</para>
        ///  A frame fragment to include in a clients view
        /// </summary>
        /// <param name="progress">The progress as an integer percentage</param>
        /// <param name="color">A string containing the escape sequence for the players color</param>
        /// <param name="name">A players name</param>
        /// <returns>A frame fragment to include in a clients view</returns>
        private static string CreateFrameFragment(int progress, string color, string name)
        {
            var indentation = new string(' ', progress);

            var indentedCar = string.Join(Environment.NewLine,
                                          new[] {indentation, indentation, indentation}
                                             .Zip(Car.Model.Split('\n'),
                                                  (a, b) => string.Join("", a, b)
                                                 )
                                         );

            return $"\n{name}\n{color}{indentedCar}{Fg.Reset}";
        }


        /// <summary>
        /// Collect all participants frame data, construct the frame fragments and merge them<para/>
        /// <para>Returns:</para>
        /// A constructed frame ready to be drawn
        /// </summary>
        /// <param name="participantData">A participants current race data encoded into a string</param>
        /// <returns>A constructed frame ready to be drawn</returns>
        private string CreateCompleteRaceFrameSolo(Dictionary<string, int> participantData)
        {
            // Own data
            string frame = CreateFrameFragment(GetProgress(), Color, Name) + '\n';

            // Competitors data
            participantData.Remove(Name);

            foreach (var dataPoint in participantData)
            {
                int    progress = dataPoint.Value;
                string color    = CompetitorColors[dataPoint.Key];
                string name     = dataPoint.Key;

                frame += CreateFrameFragment(progress, color, name) + "\n";
            }

            return frame;
        }


        /// <summary>
        /// Let a player type the given text and handle their keypresses
        /// </summary>
        public override void TypeText()
        {
            // TODO: Print WPM
            // TODO: Redraw view at set framerate, so WPM and competitor progress can be shown in real time
            Console.Clear();
            Console.CursorVisible = false;
            Console.Write($"{Fg.BrightBlack}{CurrentRace.Text}{Fg.Reset}");

            while (!HasCompletedText())
            {
                Console.Write($"\n\n{CreateCompleteRaceFrameSolo(CurrentRace.CollectProgress())}");
                Console.Write(Cursor.To(4, TypedText.Count));

                for (int i = 0; i <= (Car.Height + 2) * (CurrentRace.Participants.Count - 1); i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write($"{Cursor.ToCol(RaceView.MaxWidth)}{Fg.Black}#{Fg.Reset}#{Fg.Black}#{Fg.Reset}#{Cursor.Down(1)}"
                                     );
                    }
                    else
                    {
                        Console.Write($"{Cursor.ToCol(RaceView.MaxWidth)}{Fg.Reset}#{Fg.Black}#{Fg.Reset}#{Fg.Black}#{Cursor.Down(1)}"
                                     );
                    }
                }

                Console.Write(Cursor.To(1, TypedText.Count + 1));
                var enteredKey = Console.ReadKey(true);
                HandleKeyPress(enteredKey);
                Console.Write(Cursor.Down(1));

                Console.Write(string.Concat(Enumerable.Repeat(new string(' ', RaceView.MaxWidth),
                                                              Car.Height * (CurrentRace.Participants.Count + 2)
                                                             )
                                           )
                             );

                Console.Write(Cursor.To(1, TypedText.Count + 1));
            }

            Console.CursorVisible = true;

            CurrentRace.CompletionOrder.Add(this);
        }


        #region KeyHandlers

        /// <summary>
        /// Add the char to TypedText and write the char to the console in the appropriate color
        /// </summary>
        /// <param name="enteredChar">The char read from the players console</param>
        private void HandleCorrectChar(char enteredChar)
        {
            TypedText.Push(enteredChar);
            Console.Write($"{Fg.White}{enteredChar}{Fg.Reset}");
        }


        /// <summary>
        /// Add the char to TypedText, increment CurErrors and TotalErrors and write the char to the console in the appropriate color
        /// </summary>
        /// <param name="enteredChar">The char read from the players console</param>
        private void HandleFalseChar(char enteredChar)
        {
            TypedText.Push(enteredChar);

            if (enteredChar == ' ')
            {
                Console.Write($"{Bg.Red}{enteredChar}{Bg.Reset}");
            }
            else
            {
                Console.Write($"{Fg.Red}{enteredChar}{Fg.Reset}");
            }

            ++CurErrors;
            ++TotalErrors;
        }


        /// <summary>
        /// Delete the most recently entered char from TypedText and the console while decrementing CurErrors if the removed char was an error
        /// </summary>
        private void HandleBackspace()
        {
            if (TypedText.Count == 0)
            {
                return;
            }

            if (TypedText.Peek() != CurrentRace.Text[TypedText.Count - 1])
            {
                --CurErrors;
            }

            TypedText.Pop();

            try
            {
                Console.Write($"\b{Fg.BrightBlack}{CurrentRace.Text[TypedText.Count]}{Fg.Reset}\b");
            }
            catch (IndexOutOfRangeException)
            {
                Console.Write("\b \b");
            }
        }


        /// <summary>
        /// Read a char from the console and handle it appropriately
        /// </summary>
        /// <param name="enteredKey">The key read from the players console</param>
        private void HandleKeyPress(ConsoleKeyInfo enteredKey)
        {
            var enteredChar = enteredKey.KeyChar;

            if (enteredKey.Key == ConsoleKey.Backspace)
            {
                HandleBackspace();
            }
            // Fix: Exception when typing past the end of the text
            else if (enteredChar == CurrentRace.Text[TypedText.Count])
            {
                HandleCorrectChar(enteredChar);
            }
            else
            {
                HandleFalseChar(enteredChar);
            }
        }

        #endregion
    }
}