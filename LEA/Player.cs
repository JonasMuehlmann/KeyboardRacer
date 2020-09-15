using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LEA
{
    public class Participant
    {
        private string      _name;
        private Stack<char> _typedText;
        private Race        _currentRace;
        private int         _totalErrors;
        private int         _curErrors;
        private string      _color;

        #region Properties

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Stack<char> TypedText
        {
            get => _typedText;
            set => _typedText = value;
        }

        public Race CurrentRace
        {
            get => _currentRace;
            set => _currentRace = value;
        }

        public int TotalErrors
        {
            get => _totalErrors;
            set => _totalErrors = value;
        }

        public int CurErrors
        {
            get => _curErrors;
            set => _curErrors = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        #endregion


        public Participant(string name, string color, Race currentRace)
        {
            Name        = name;
            Color       = color;
            CurrentRace = currentRace;
            TypedText   = new Stack<char>(CurrentRace.Text.Length);
            TotalErrors = 0;
            CurErrors   = 0;
            CurrentRace = currentRace;
        }
    }

    public class Player : Participant
    {
        public Player(string name, string color, Race currentRace) : base(name, color, currentRace) { }


        private void HandleCorrectChar(char enteredChar)
        {
            TypedText.Push(enteredChar);
            Console.Write($"{Fg.White}{enteredChar}{Fg.Reset}");
        }


        private int WordsPerMinute(Race currentRace)
        {
            DateTime endOfRace      = DateTime.Now;
            double   timeInSeconds  = (endOfRace - CurrentRace.StartOfRace).TotalSeconds;
            double   charsPerSecond = CurrentRace.Text.Length / timeInSeconds;
            double   wordsPerSecond = charsPerSecond          * 60;
            int      wordsPerMinute = (int) Math.Floor(wordsPerSecond / 5);

            return wordsPerMinute;
        }


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


        private bool HasCompletedText()
        {
            return TypedText.Count == CurrentRace.Text.Length && CurErrors == 0;
        }


        public void TypeText()
        {
            Console.Write($"{Fg.BrightBlack}{CurrentRace.Text}\r");

            while (!HasCompletedText())
            {
                var enteredKey = Console.ReadKey(true);
                HandleKeyPress(enteredKey);
            }

            CurrentRace.CompletionOrder.Add(this);
        }
    }
}