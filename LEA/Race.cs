using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace LEA
{
    public class Race
    {
        private string            _text;
        private DateTime          _startOfRace;
        private List<Participant> _participants;
        private List<Participant> _completionOrder;
        private int               _completionTime;
        private bool              _raceCompleted;

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
            CompletionTime  = DateTime.Now.AddSeconds(Text.Length * 10.0).Second;
        }

        #endregion


        public List<string> CollectFrameFragments()
        {
            List<string> frameFragments = new List<string>(Participants.Count);

            foreach (Participant participant in Participants)
            {
                frameFragments.Add(participant.CreateOwnFrameFragment());
            }

            return frameFragments;
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