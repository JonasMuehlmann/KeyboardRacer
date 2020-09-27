namespace KeyboardRacer
{
    namespace Frontend
    {
        public class PostGameStats
        {
            #region Properties

            public string Name { get; }

            public int Wpm { get; }

            public int TotalErrors { get; }

            #endregion

            #region Constructors

            public PostGameStats(string name, int wpm, int totalErrors)
            {
                Name        = name;
                Wpm         = wpm;
                TotalErrors = totalErrors;
            }

            #endregion
        }
    }
}