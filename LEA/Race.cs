using System.Collections.Generic;


namespace LEA
{
    public class Race
    {
        #region Constructors

        public Race(ref string text)
        {
            Text            = text;
            Participants    = new List<Player>();
            CompletionOrder = new List<Player>();
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
        // TODO: Add reference to players in race
        // TODO: Add way to detect a player ending the race
        // TODO: Add scoreboard composition (first place, second place, etc)


        #region Properties

        public string Text { get; private set; }

        public List<Player> Participants { get; set; }

        public List<Player> CompletionOrder { get; set; }

        #endregion
    }
}