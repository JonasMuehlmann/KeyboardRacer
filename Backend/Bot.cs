using System;
using System.Threading;


namespace Backend
{
    public class Bot : Participant
    {
        private static readonly Random Rng = new Random();

        #region Properties

        private int TypedChars { get; set; }


        public int Difficulty { get; set; }

        private double Speed { get; }

        #endregion

        #region Constructors

        public Bot(string name, string color, Race currentRace, int difficulty) :
            base(name, color, currentRace)
        {
            Speed = difficulty * 1.66 + Rng.Next(0, 167) / 100.0;
        }

        #endregion


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
            double charsPerSecond = TypedChars     / timeInSeconds;
            double wordsPerSecond = charsPerSecond / 5;
            int    wordsPerMinute = (int) Math.Floor(wordsPerSecond * 60);

            return wordsPerMinute;
        }


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
        ///     Simulate the bot playing the game
        /// </summary>
        public override void TypeText()
        {
            // TODO: Fix instantaneous completion
            while (!HasCompletedText())
            {
                int rndSeconds = Rng.Next(3, 6);

                if (Rng.Next(1, 21) == 20)
                {
                    Thread.Sleep(Rng.Next(1, 3) * 1000);
                }

                Thread.Sleep(rndSeconds * 100);
                int steps = Convert.ToInt32(rndSeconds * Speed / 10);

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