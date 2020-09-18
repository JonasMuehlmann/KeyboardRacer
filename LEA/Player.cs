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
        private          List<Char>                 _typedText;

        #region Properties

        public int CurErrors
        {
            get => _curErrors;
            set => _curErrors = value;
        }

        public int CurChar
        {
            get => _curChar;
            set => _curChar = value;
        }

        public List<Char> TypedText
        {
            get => _typedText;
            set => _typedText = value;
        }

        public Client NetworkClient
        {
            get => _networkClient;
        }

        public Dictionary<string, string> CompetitorColors
        {
            get => _competitorColors;
        }

        #endregion

        #region Constructors

        public Player(string name, string color, Race currentRace) :
            base(name, color, currentRace)
        {
            CurErrors         = 0;
            CurChar           = 0;
            _networkClient    = new Client();
            _competitorColors = new Dictionary<string, string>();
            TypedText         = CurrentRace.Text.Select(c => new Char(c)).ToList();
        }

        #endregion


        private int GetCorrectChars()
        {
            return TypedText.Count(c => c.Color == Fg.White);
        }


        public override int GetProgress()
        {
            double correctChars = GetCorrectChars();

            return Convert.ToInt32(100 * (correctChars / CurrentRace.Text.Length));
        }


        public override bool HasCompletedText()
        {
            return CurrentRace.Text.Length == GetCorrectChars() && CurErrors == 0;
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

            return $"{name}\n{color}{indentedCar}{Fg.Reset}";
        }


        /// <summary>
        /// Collect all participants frame data, construct the frame fragments and merge them<para/>
        /// <para>Returns:</para>
        /// A constructed frame ready to be drawn
        /// </summary>
        /// <param name="participantData">A participants current race data encoded into a string</param>
        /// <returns>A constructed frame ready to be drawn</returns>
        private string CreateCompleteRaceFrameNetwork(List<string> participantData)
        {
            string frame = CreateFrameFragment(GetProgress(),
                                               Name,
                                               Color
                                              );

            foreach (string dataPoint in participantData)
            {
                List<string> data     = dataPoint.Split(";").ToList();
                int          progress = Convert.ToInt32(data[0]);
                string       color    = data[1];
                string       name     = data[2];
                frame += CreateFrameFragment(progress, color, name) + "\n";
            }

            return frame;
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
            Console.Clear();

            while (!HasCompletedText())
            {
                RenderTypedText();
                Console.Write($"\n\n\n{CreateCompleteRaceFrameSolo(CurrentRace.CollectProgress())}");
                Console.Write(Cursor.To(1, TypedText.Count));

                var enteredKey = Console.ReadKey(true);
                HandleKeyPress(enteredKey);
                Console.Clear();
            }

            CurrentRace.CompletionOrder.Add(this);
        }


        #region KeyHandlers

        /// <summary>
        /// Add the char to TypedText and write the char to the console in the appropriate color
        /// </summary>
        /// <param name="enteredChar">The char read from the players console</param>
        private void HandleCorrectChar(char enteredChar)
        {
            TypedText[CurChar].Color = Fg.White;
            ++CurChar;
        }


        /// <summary>
        /// Add the char to TypedText, increment CurErrors and TotalErrors and write the char to the console in the appropriate color
        /// </summary>
        /// <param name="enteredChar">The char read from the players console</param>
        private void HandleFalseChar(char enteredChar)
        {
            if (enteredChar == ' ')
            {
                TypedText[CurChar].Color = Bg.Red;
                TypedText[CurChar].Reset = Bg.Reset;
            }
            else
            {
                TypedText[CurChar].Color = Fg.Red;
                TypedText[CurChar].Reset = Fg.Reset;
            }

            ++CurErrors;
            ++TotalErrors;
            --CurChar;
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

            if (TypedText[CurChar].C == CurrentRace.Text[TypedText.Count - 1])
            {
                --CurErrors;
            }

            TypedText[CurChar].Color = Fg.BrightBlack;
            --CurChar;
        }


        private void RenderTypedText()
        {
            Console.Write(new string(TypedText.Select(c => c.ToString())));
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
            else if (enteredChar == CurrentRace.Text[CurChar])
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