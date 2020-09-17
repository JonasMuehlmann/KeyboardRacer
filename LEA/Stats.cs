using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;


namespace LEA
{
    public class Stats
    {
        //TODO:ADD loadPlayerStatistic void
        //TODO:ADD updatePlayerStatistic void
        //TODO:ADD avgWPM calculation
        //TODO:ADD avgErrors calculation

        private const string   StatsDir = "../../../data/statistics";
        private       double   _avgErrors;
        private       int      _avgWpm;
        private       string[] _datapoints;
        private       string   _name;
        private       int      _races;

        #region Properties

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string[] Datapoints
        {
            get => _datapoints;
            set => _datapoints = value;
        }

        public int Races
        {
            get => _races;
            set => _races = value;
        }

        public int AvgWpm
        {
            get => _avgWpm;
            set => _avgWpm = value;
        }

        public double AvgErrors
        {
            get => _avgErrors;
            set => _avgErrors = value;
        }

        #endregion


        /// <summary>
        /// <para>Returns:</para>
        /// True if the player has a non-empty statistics file, false otherwise
        /// </summary>
        /// <param name="player">
        /// Who's statistics file to check for
        /// </param>
        /// <returns>
        /// True if the player has a non-empty statistics file, false otherwise
        /// </returns>
        public static bool HasStatisticsFile(string player)
        {
            string statsFile    = $"{StatsDir}/{player}";
            var    statsFileIno = new FileInfo(statsFile);

            return File.Exists(statsFile) && statsFileIno.Length != 0;
        }


        /// <summary>
        /// <para>
        /// Returns:
        /// </para>
        /// A list of player names who have existing and non-empty statistics files
        /// </summary>
        /// <returns>
        /// A list of player names who have existing and non-empty statistics files
        /// </returns>
        public string[] GetPlayerNames()
        {
            return Directory
                  .GetFiles(StatsDir)
                  .Select(Path.GetFileName)
                  .Where(HasStatisticsFile)
                  .ToArray();
        }


        /// <summary>
        /// Creates a statistics file for the given player
        /// </summary>
        /// <param name="player">
        /// Player for whom a statistics file should be created
        /// </param>
        public void CreateNewStatisticsFile(string player)
        {
            File.Create($"{StatsDir}/{player}");
        }


        public int GetNumRaces(string[] datapoints)
        {
            return datapoints.Length;
        }


        public int GetAverageWpm(string[] datapoints)
        {
            foreach (var line in datapoints) { }

            return 0;
        }
    }
}