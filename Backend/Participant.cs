namespace KeyboardRacer
{
    namespace Backend
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


            public abstract int GetWpm();


            public abstract void TypeText();
        }
    }
}