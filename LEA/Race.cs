using System;
using System.Collections.Generic;


namespace LEA
{
    public class Race
    {
        #region Properties

        public string Text { get; private set; }

        public DateTime StartOfRace {get; set;}

        #endregion

        #region Constructors

        public Race(ref string text)
        {
            Text = text;
            StartOfRace = DateTime.Now;
        }

        #endregion


        public void EndRace(Player winner)
        {
            ;
        }
    }
}