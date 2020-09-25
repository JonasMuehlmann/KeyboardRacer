#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion


namespace Backend
{
    public class Race
    {
        #region Properties

        public string Text { get; }

        public DateTime StartOfRace { get; }

        public List<Participant> Participants { get; }

        public List<Participant> CompletionOrder { get; }

        private int SecondsUntilTimeout { get; }

        private bool RaceCompleted { get; set; }

        public Host GameHost { get; }

        #endregion

        #region Constructors

        public Race(string text)
        {
            Text                = text;
            Participants        = new List<Participant>();
            CompletionOrder     = new List<Participant>();
            StartOfRace         = DateTime.Now;
            SecondsUntilTimeout = (int) Math.Round(Text.Length * 0.5);
            GameHost            = new Host();
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
            Console.Clear();
            SendCompetitorColors();

            var tasks = Participants.Select(participant => new Task(participant.TypeText)).ToArray();

            foreach (var task in tasks)
            {
                task.Start();
            }

            Console.WriteLine(Task.WaitAll(tasks, TimeSpan.FromSeconds(SecondsUntilTimeout)) ? "Completed" : "Timed out"
                             );
            // participant.TypeText();

            // EndRace();
        }
    }
}