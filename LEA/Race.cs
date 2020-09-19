using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LEA
{
    public class Race
    {
        private List<Participant> _completionOrder;
        private int               _completionTime;
        private Host              _gameHost;
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

        public Host GameHost
        {
            get => _gameHost;
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
            _gameHost       = new Host();
        }

        #endregion


        public bool IsNameAvailable(string name)
        {
            return Participants.All(participant => participant.Name != name);
        }


        private void SendCompetitorColors()
        {
            foreach (var player in Participants.OfType<Player>())
            {
                player.SetCompetitorColors();
            }
        }


        public Dictionary<string, int> CollectProgress()
        {
            return Participants.ToDictionary(x => x.Name,
                                             x => x.GetProgress()
                                            );
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


        public void StartGameLoop()
        {
            SendCompetitorColors();

            var tasks = Participants.Select(participant => new Task(participant.TypeText)).ToArray();

            foreach (var task in tasks)
            {
                task.Start();
            }

            Console.WriteLine(Task.WaitAll(tasks, TimeSpan.FromSeconds(8)) ? "Completed" : "Timed out");
            // participant.TypeText();

            // EndRace();
        }
    }
}