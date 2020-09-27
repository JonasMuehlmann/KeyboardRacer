#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeyboardRacer.Frontend;

#endregion


namespace KeyboardRacer
{
    namespace Backend
    {
        public class Race
        {
            #region Properties

            public string Text { get; }

            public DateTime StartOfRace { get; }

            public List<Participant> Participants { get; }

            public List<PostGameStats> PostGameStats { get; }

            private int SecondsUntilTimeout { get; }

            private bool RaceCompleted { get; set; }

            public Host GameHost { get; }

            public bool Completed { get; set; }

            #endregion

            #region Constructors

            public Race(string text)
            {
                Text                = text;
                Participants        = new List<Participant>();
                PostGameStats       = new List<PostGameStats>();
                StartOfRace         = DateTime.Now;
                SecondsUntilTimeout = (int) Math.Round(Text.Length * 0.5);
                GameHost            = new Host();
                Completed           = false;
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


            public void StartGameLoop()
            {
                Console.Clear();
                SendCompetitorColors();

                var tasks = Participants.Select(participant => new Task(participant.TypeText)).ToArray();

                foreach (var task in tasks)
                {
                    task.Start();
                }

                // TODO: let users know when the timeout has occured
                // FIX: Timed out players are not added to the scoreboard
                Task.WaitAll(tasks, TimeSpan.FromSeconds(SecondsUntilTimeout));
                Completed = true;
            }
        }
    }
}