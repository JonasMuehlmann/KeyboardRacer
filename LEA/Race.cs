using System;
using System.Collections.Generic;


namespace LEA
{
    public class Race
    {
        #region Properties

        public string Text { get; private set; }

        #endregion

        #region Constructors

        public Race(ref string text)
        {
            Text = text;
        }

        #endregion


        public void EndRace(Player winner)
        {
            ;
        }
    }
}