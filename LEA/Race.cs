using System;
using System.Collections.Generic;


namespace LEA
{
    public class Race
    {
        #region Properties

        public string Text { get; private set; }

        public DateTime StartOfRace { get; set; }

        public List<Player> Participants { get; set; }

        public List<Player> CompletionOrder { get; set; }

        #endregion

        #region Constructors

        public Race(ref string text)
        {
            Text            = text;
            Participants    = new List<Player>();
            CompletionOrder = new List<Player>();
            Text            = text;
            StartOfRace     = DateTime.Now;
        }

        #endregion


        public void StartRce()
        {
            foreach (var player in Participants)
            {
                player.TypeText();
            }
        }


        public void EndRace(Player winner)
        {
            ;
        }
    }
}