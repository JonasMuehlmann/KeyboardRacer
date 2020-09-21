using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace KeyboardRacer
{
    public class Player : Participant
    {
        #region Properties

        private int CurErrors { get; set; }

        private int MaxProgress { get; set; }

        private Dictionary<string, string> CompetitorColors { get; }

        private int CurChar { get; }

        private Stack<char> TypedText { get; }

        private Client NetworkClient { get; }

        #endregion

        #region Constructors

        public Player(string name, string color, Race currentRace) :
            base(name, color, currentRace)
        {
            CurErrors        = 0;
            TypedText        = new Stack<char>(CurrentRace.Text.Length);
            NetworkClient    = new Client();
            CurErrors        = 0;
            CurChar          = 0;
            MaxProgress      = 0;
            CompetitorColors = new Dictionary<string, string>();
        }

        #endregion


        public override int GetProgress()
        {
            double correctChars = TypedText.Count;
            int    curProgress  = Convert.ToInt32(100 * (correctChars / CurrentRace.Text.Length));

            if (curProgress > MaxProgress)
            {
                MaxProgress = curProgress;
            }

            return MaxProgress;
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
        ///     A frame fragment is a 'race lane' in the client's view of the race
        ///     <para />
        ///     <para>Returns:</para>
        ///     A frame fragment to include in a clients view
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
        ///     Collect all participants frame data, construct the frame fragments and merge them
        ///     <para />
        ///     <para>Returns:</para>
        ///     A constructed frame ready to be drawn
        /// </summary>
        /// <param name="participantData">A participants current race data encoded into a string</param>
        /// <returns>A constructed frame ready to be drawn</returns>
        private void DrawCompleteRaceFrameSolo(Dictionary<string, int> participantData)
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

            Console.Write(frame);
            DrawFinishingLine();
            DrawTotalErrors();
            DrawCurErrors();
            DrawWpm();
        }


        private void ClearRaceView()
        {
            // Moving the cursor down voids clearing the typed text
            Cursor.Down(1);

            Console.Write(string.Concat(Enumerable.Repeat(new string(' ', RaceView.MaxWidth),
                                                          Car.Height * (CurrentRace.Participants.Count + 2)
                                                         )
                                       )
                         );

            // Resets cursors to first row of race view, below the typed text
            Cursor.To(3, 1);
        }


        private void DrawFinishingLine()
        {
            // Sets cursor to first row of the race frame
            Cursor.To(4, 1);

            for (int i = 1; i < RaceView.LaneHeight * CurrentRace.Participants.Count; i++)
            {
                Cursor.ToCol(RaceView.MaxWidth);

                Console.Write(i % 2 == 0
                                  ? $"{Fg.Black}#{Fg.Reset}#{Fg.Black}#{Fg.Reset}"
                                  : $"{Fg.Reset}#{Fg.Black}#{Fg.Reset}#"
                             );

                Cursor.Down(1);
            }

            // Resets cursor to correct position in typed text
            Cursor.To(1, TypedText.Count + 1);
        }


        /// <summary>
        ///     Calculates the current Words-Per-Minute (WPM) rating
        ///     <para />
        ///     <para>Returns:</para>
        ///     The current WPM rating as an integer
        /// </summary>
        /// <returns>The current WPM rating as an integer</returns>
        public override int GetWpm()
        {
            double timeInSeconds  = (DateTime.Now - CurrentRace.StartOfRace).TotalSeconds;
            double charsPerSecond = TypedText.Count / timeInSeconds;
            double wordsPerSecond = charsPerSecond  / 5;
            int    wordsPerMinute = (int) Math.Floor(wordsPerSecond * 60);

            return wordsPerMinute;
        }


        private void DrawTotalErrors()
        {
            // Set cursors above the finishing line
            Cursor.To(1, RaceView.MaxWidth);
            Console.Write($"{TotalErrors.ToString().PadLeft(3, ' ')} Total errors");
            // Resets cursor to correct position in typed text
            Cursor.To(1, TypedText.Count + 1);
        }


        private void DrawCurErrors()
        {
            // Set cursors above the finishing line
            Cursor.To(2, RaceView.MaxWidth);
            Console.Write($"{CurErrors.ToString().PadLeft(3, ' ')} Current errors");
            // Resets cursor to correct position in typed text
            Cursor.To(1, TypedText.Count + 1);
        }


        private void DrawWpm()
        {
            // Set cursors above the finishing line
            Cursor.To(3, RaceView.MaxWidth);
            Console.Write($"{GetWpm().ToString().PadLeft(3, ' ')} WPM");
            // Resets cursor to correct position in typed text
            Cursor.To(1, TypedText.Count + 1);
        }


        private async Task RenderLoopAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                ClearRaceView();
                DrawCompleteRaceFrameSolo(CurrentRace.CollectProgress());

                await Task.Delay(TimeSpan.FromMilliseconds(50), cancellationToken);
            }
        }


        /// <summary>
        ///     Let a player type the given text and handle their keypresses
        /// </summary>
        public override void TypeText()
        {
            // Check: If Backbuffering the console view might be useful: https://stackoverflow.com/questions/29920056/c-sharp-something-faster-than-console-write
            // TODO: Make player names follow their cars
            Console.Clear();
            Console.CursorVisible = false;
            Console.Write($"{Fg.BrightBlack}{CurrentRace.Text}{Fg.Reset}\n\n");

            DrawCompleteRaceFrameSolo(CurrentRace.CollectProgress());

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken       = cancellationTokenSource.Token;

            RenderLoopAsync(cancellationToken);

            while (!HasCompletedText())
            {
                var enteredKey = Console.ReadKey(true);
                HandleKeyPress(enteredKey);
            }

            cancellationTokenSource.Cancel();

            Cursor.To(1, 1);
            Console.CursorVisible = true;

            CurrentRace.CompletionOrder.Add(this);
        }


        #region KeyHandlers

        /// <summary>
        ///     Add the char to TypedText and write the char to the console in the appropriate color
        /// </summary>
        /// <param name="enteredChar">The char read from the players console</param>
        private void HandleCorrectChar(char enteredChar)
        {
            TypedText.Push(enteredChar);
            Console.Write($"{Fg.White}{enteredChar}{Fg.Reset}");
        }


        /// <summary>
        ///     Add the char to TypedText, increment CurErrors and TotalErrors and write the char to the console in the appropriate
        ///     color
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
        ///     Delete the most recently entered char from TypedText and the console while decrementing CurErrors if the removed
        ///     char was an error
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
        ///     Read a char from the console and handle it appropriately
        /// </summary>
        /// <param name="enteredKey">The key read from the players console</param>
        private void HandleKeyPress(ConsoleKeyInfo enteredKey)
        {
            var enteredChar = enteredKey.KeyChar;

            try
            {
                if (enteredKey.Key == ConsoleKey.Backspace)
                {
                    HandleBackspace();
                }
                else if (enteredChar == CurrentRace.Text[TypedText.Count])
                {
                    HandleCorrectChar(enteredChar);
                }
                else
                {
                    HandleFalseChar(enteredChar);
                }
            }
            catch (IndexOutOfRangeException e) { }
        }

        #endregion
    }
}