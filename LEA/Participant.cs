using System;


namespace LEA
{
    public abstract class Participant
    {
        #region Properties

        protected Race CurrentRace { get; }

        protected int TotalErrors { get; set; }

        public string Color { get; }

        public string Name { get; }

        #endregion

        #region Constructors

        protected Participant(string name, string color, Race currentRace)
        {
            Name        = name;
            Color       = color;
            CurrentRace = currentRace;
            TotalErrors = 0;
        }

        #endregion


        /// <summary>
        ///     <para>Returns:</para>
        ///     The integer-percentage of the players progress until the end of the race
        /// </summary>
        /// <returns>The integer-percentage of the players progress until the end of the race</returns>
        public abstract int GetProgress();


        public abstract bool HasCompletedText();


        /// <summary>
        ///     Calculates the current Words-Per-Minute (WPM) rating
        ///     <para />
        ///     <para>Returns:</para>
        ///     The current WPM rating as an integer
        /// </summary>
        /// <returns>The current WPM rating as an integer</returns>
        public int WordsPerMinute()
        {
            double timeInSeconds  = (DateTime.Now - CurrentRace.StartOfRace).TotalSeconds;
            double charsPerSecond = CurrentRace.Text.Length / timeInSeconds;
            double wordsPerSecond = charsPerSecond          / 5;
            int    wordsPerMinute = (int) Math.Floor(wordsPerSecond * 60);

            return wordsPerMinute;
        }


        public abstract void TypeText();
    }
}