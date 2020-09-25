using System;
using System.IO;
using System.Linq;


namespace KeyboardRacer
{
    public class Settings
    {
        #region Properties

        private string playername;

        public string Playername
        {
            get => playername;
        }

        #endregion

        #region Constructor

        public Settings()
        {
            playername = File.ReadAllText("../../../data/settings.cfg");
        }

        #endregion

        public void ReloadSettings()
        {
            playername = File.ReadAllText("../../../data/settings.cfg");
        }

        public void ChangePlayerName(string name)
        {
            System.IO.File.WriteAllText("../../../data/settings.cfg", name);
            ReloadSettings();
        }
    }
}