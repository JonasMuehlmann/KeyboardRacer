#region

using System.IO;

#endregion


namespace KeyboardRacer
{
    public class Settings
    {
        #region Properties

        public string Playername { get; private set; }

        #endregion

        #region Constructor

        public Settings()
        {
            Playername = File.ReadAllText("../../../data/settings.cfg");
        }

        #endregion


        public void ReloadSettings()
        {
            Playername = File.ReadAllText("../../../data/settings.cfg");
        }


        public void ChangePlayerName(string name)
        {
            File.WriteAllText("../../../data/settings.cfg", name);
            ReloadSettings();
        }
    }
}