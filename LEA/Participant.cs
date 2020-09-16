using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace LEA
{
    public abstract class Participant
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
            set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentException("Name cannot be longer than 20 characters");
                }

                _name = value;
            }
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

        public Participant() { }


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


        public int Progress()
        {
            double correctChars = (double) TypedText.Count - CurErrors;

            return Convert.ToInt32(100 * (correctChars / CurrentRace.Text.Length));
        }


        public abstract bool HasCompletedText();


        public int WordsPerMinute()
        {
            DateTime endOfRace      = DateTime.Now;
            double   timeInSeconds  = (endOfRace - CurrentRace.StartOfRace).TotalSeconds;
            double   charsPerSecond = CurrentRace.Text.Length / timeInSeconds;
            double   wordsPerSecond = charsPerSecond          / 5;
            int      wordsPerMinute = (int) Math.Floor(wordsPerSecond * 60);

            return wordsPerMinute;
        }


        public abstract void TypeText();
    }


    public class Bot : Participant
    {
        private        int    _difficulty;
        private        double _speed; //Speed in characters per second
        private static Random rnd = new Random();

        public static Random Rnd
        {
            get => rnd;
        }

        public int Difficulty
        {
            get => _difficulty;
            set => _difficulty = value;
        }

        public double Speed
        {
            get => _speed;
            set => _speed = value;
        }


        public Bot(string name, string color, Race currentRace, int difficulty) : base(name, color, currentRace)
        {
            Difficulty = difficulty;
            Speed      = Difficulty * 1.66 + (Rnd.Next(0, 167) / 100.0);
        }


        public override bool HasCompletedText()
        {
            return TypedText.Count == CurrentRace.Text.Length && CurErrors == 0;
        }


        public override void TypeText()
        {
            while (!HasCompletedText())
            {
                int rndSeconds = rnd.Next(3, 6);

                if (rnd.Next(1, 21) == 20)
                {
                    Thread.Sleep(rnd.Next(1, 3) * 1000);
                }

                Thread.Sleep(rndSeconds * 100);
                int steps = Convert.ToInt32((rndSeconds * Speed) / 10);

                for (int i = 0; i < steps; i++)
                {
                    if (TypedText.Count < CurrentRace.Text.Length)
                    {
                        TypedText.Push(' ');
                    }
                }
            }

            CurrentRace.CompletionOrder.Add(this);
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


        public override bool HasCompletedText()
        {
            return TypedText.Count == CurrentRace.Text.Length && CurErrors == 0;
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


        public string CreateFrameFragment(int progess, string color, string name)
        {
            var indentation = new string(' ', progess);

            var indentedCar = string.Join(Environment.NewLine,
                                          new[] {indentation, indentation, indentation}
                                             .Zip(Constants.Car.Split('\n'),
                                                  (a, b) => string.Join("", a, b)
                                                 )
                                         );

            return $"{name}\n{color}{indentedCar}{Fg.Reset}";
        }


        public string CreateCompleteRaceFrame(List<string> participantData)
        {
            string frame = CreateFrameFragment(Progress(), Color, Name);

            foreach (string fragment in participantData)
            {
                frame += CreateFrameFragment() + "\n";
            }

            return frame;
        }


        public override void TypeText()
        {
            Console.Write($"{Fg.BrightBlack}{CurrentRace.Text}\r");

            while (!HasCompletedText())
            {
                var enteredKey = Console.ReadKey(true);
                HandleKeyPress(enteredKey);
                Console.WriteLine(CreateCompleteRaceFrame(CurrentRace.CollectPlayerData()));
            }

            CurrentRace.CompletionOrder.Add(this);
        }
    }
}