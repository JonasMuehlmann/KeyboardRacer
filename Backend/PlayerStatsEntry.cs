#region

using System;

#endregion


namespace KeyboardRacer
{
    namespace Backend
    {
        public class PlayerStatsEntry
        {
            #region Properties

            public string Name { get; set; }

            public int RaceId { get; set; }

            public int TextLength { get; set; }

            public int Wpm { get; set; }

            public int TotalErrors { get; set; }

            public DateTime StartOfRace { get; set; }

            public DateTime EndOfRace { get; set; }

            #endregion

            #region Constructors

            public PlayerStatsEntry(
                string   name,
                DateTime endOfRace,
                int      raceId,
                DateTime startOfRace,
                int      textLength,
                int      totalErrors,
                int      wpm
            )
            {
                Name        = name;
                EndOfRace   = endOfRace;
                RaceId      = raceId;
                StartOfRace = startOfRace;
                TextLength  = textLength;
                TotalErrors = totalErrors;
                Wpm         = wpm;
            }

            #endregion
        }
    }
}