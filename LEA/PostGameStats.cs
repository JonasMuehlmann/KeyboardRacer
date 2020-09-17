using System;


namespace LEA
{
    public class PostGameStats
    {
        private DateTime _endOfRace;
        private string   _name;
        private int      _raceId;
        private DateTime _startOfRace;
        private int      _textLength;
        private int      _totalErrors;
        private int      _wpm;

        #region Properties

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int RaceId
        {
            get => _raceId;
            set => _raceId = value;
        }

        public int TextLength
        {
            get => _textLength;
            set => _textLength = value;
        }

        public int Wpm
        {
            get => _wpm;
            set => _wpm = value;
        }

        public int TotalErrors
        {
            get => _totalErrors;
            set => _totalErrors = value;
        }

        public DateTime StartOfRace
        {
            get => _startOfRace;
            set => _startOfRace = value;
        }

        public DateTime EndOfRace
        {
            get => _endOfRace;
            set => _endOfRace = value;
        }

        #endregion


        public PostGameStats(
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
    }
}