using System;
using System.Threading;

namespace LEA
{
    public class Bot : Participant
    {
        private int _difficulty;
        private double _speed; //Speed in characters per second
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
            _difficulty = difficulty;
            _speed = _difficulty * 1.66 + (Rnd.Next(0, 167)/100.0);
        }

        private bool CompletedText(int progress)
        {
            if (progress == CurrentRace.Text.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public override void TypeText()
        {
            
            int textLength = CurrentRace.Text.Length;
            int progress = 0;
            int rndSeconds = 0;
            while (!CompletedText(progress))
            {
                rndSeconds = rnd.Next(3, 6);
                if (rnd.Next(1,21) == 20)
                {
                    Thread.Sleep(rnd.Next(1,3) * 1000);
                }
                Thread.Sleep(rndSeconds * 100);
                progress += Convert.ToInt32((rndSeconds * Speed)/10);
                if (progress > textLength)
                {
                    progress = textLength;
                }

            }
            
            CurrentRace.CompletionOrder.Add(this);
            int wpm = WordsPerMinute(CurrentRace);
            Console.WriteLine("WPM:{0}",wpm);

        }
    }
}