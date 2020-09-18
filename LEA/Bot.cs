using System;
using System.Threading;


namespace LEA
{
    public class Bot : Participant
    {
        private static readonly Random Rng = new Random();

        private int _difficulty;

        //Speed is measured in characters per second
        private double _speed;
        private int    _typedChars;

        #region Properties

        public int TypedChars
        {
            get { return _typedChars; }
            set { _typedChars = value; }
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

        #endregion

        #region Constructors

        public Bot(ParticipantIdentification participantIdentification, Race currentRace, int difficulty) :
            base(participantIdentification, currentRace)
        {
            Speed = difficulty * 1.66 + (Rng.Next(0, 167) / 100.0);
        }

        #endregion


        public override int GetProgress()
        {
            double correctChars = TypedChars;

            return Convert.ToInt32(100 * (correctChars / CurrentRace.Text.Length));
        }


        public override bool HasCompletedText()
        {
            return TypedChars == CurrentRace.Text.Length;
        }


        /// <summary>
        /// Simulate the bot playing the game
        /// </summary>
        public override void TypeText()
        {
            while (!HasCompletedText())
            {
                int rndSeconds = Rng.Next(3, 6);

                if (Rng.Next(1, 21) == 20)
                {
                    Thread.Sleep(Rng.Next(1, 3) * 1000);
                }

                Thread.Sleep(rndSeconds * 100);
                int steps = Convert.ToInt32((rndSeconds * Speed) / 10);

                for (int i = 0; i < steps; i++)
                {
                    if (TypedChars < CurrentRace.Text.Length)
                    {
                        TypedChars = CurrentRace.Text.Length;
                    }
                }
            }
        }
    }
}