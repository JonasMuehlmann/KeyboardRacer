using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LEA
{
    public class Race
    {
        private List<Participant> _completionOrder;
        private int               _completionTime;
        private List<Participant> _participants;
        private bool              _raceCompleted;
        private DateTime          _startOfRace;
        private string            _text;

        #region Properties

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public DateTime StartOfRace
        {
            get => _startOfRace;
            set => _startOfRace = value;
        }

        public List<Participant> Participants
        {
            get => _participants;
            set => _participants = value;
        }

        public List<Participant> CompletionOrder
        {
            get => _completionOrder;
            set => _completionOrder = value;
        }

        public int CompletionTime
        {
            get => _completionTime;
            set => _completionTime = value;
        }

        public bool RaceCompleted
        {
            get => _raceCompleted;
            set => _raceCompleted = value;
        }

        #endregion

        #region Constructors

        public Race(ref string text)
        {
            Text            = text;
            Participants    = new List<Participant>();
            CompletionOrder = new List<Participant>();
            StartOfRace     = DateTime.Now;
            CompletionTime  = DateTime.Now.AddSeconds(Text.Length * 3.0).Second;
        }

        #endregion


        /// <summary>
        /// playerDataFormat:<para />
        /// Progress;       0-100, max 3 letters<para />
        /// Color;          max 7 letters<para />
        /// Name;           max 20 letters<para />
        /// <para />
        /// eg.: 0;Red;Foo<para />
        /// eg.: 1000;Magenta;Assaro<para />
        /// <para>Returns:</para>
        /// A list of player data
        /// </summary>
        /// <returns>
        /// A list of player data
        /// </returns>
        public List<string> CollectPlayerData()
        {
            List<string> playerData = new List<string>(Participants.Count);

            foreach (Participant participant in Participants)
            {
                playerData.Add($"{participant.Progress()};{participant.Color};{participant.Name}");
            }

            return playerData;
        }


        private void EndRace()
        {
            if (RaceCompleted)
            {
                Console.WriteLine("Already completed");
            }
            else
            {
                RaceCompleted = true;
                Console.WriteLine("completed");
            }
        }


        private async Task CountdownCompletionTime()
        {
            await Task.Delay(CompletionTime * 1000);
            EndRace();
        }


        public void StartRace()
        {
            foreach (Participant participant in Participants)
            {
                participant.TypeText();
            }

            EndRace();
        }
    }
}