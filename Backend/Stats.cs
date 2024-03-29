#region

using System;
using System.IO;
using System.Linq;

#endregion


namespace KeyboardRacer
{
    namespace Backend
    {
        public class Stats
        {
            //TODO:ADD loadPlayerStatistic void
            //TODO:ADD updatePlayerStatistic void


            private const string StatsDir = "../../../../Backend/data/statistics";

            #region Properties

            public string Name { get; set; }

            public string[] Datapoints { get; set; }

            public int Races { get; set; }

            public int AvgWpm { get; set; }

            public double AvgErrors { get; set; }

            #endregion


            /// <summary>
            ///     <para>Returns:</para>
            ///     True if the player has a non-empty statistics file, false otherwise
            /// </summary>
            /// <param name="player">
            ///     Who's statistics file to check for
            /// </param>
            /// <returns>
            ///     True if the player has a non-empty statistics file, false otherwise
            /// </returns>
            private static bool HasStatistics(string player)
            {
                var statsFile     = $"{StatsDir}/{player}";
                var statsFileInfo = new FileInfo(statsFile);

                return File.Exists(statsFile) && statsFileInfo.Length != 0;
            }


            /// <summary>
            ///     <para>
            ///         Returns:
            ///     </para>
            ///     A list of player names who have existing and non-empty statistics files
            /// </summary>
            /// <returns>
            ///     A list of player names who have existing and non-empty statistics files
            /// </returns>
            public string[] GetPlayerNames()
            {
                return Directory
                      .GetFiles(StatsDir)
                      .Select(Path.GetFileName)
                      .Where(HasStatistics)
                      .ToArray();
            }


            /// <summary>
            ///     Form a datapoint with the PlayerStatsEntry object's members in the desired format for writing
            ///     <para>Returns:</para>
            ///     A datapoint in a ready-to-write format
            /// </summary>
            /// <param name="statsEntry"></param>
            /// <returns></returns>
            private string FormatRaceData(PlayerStatsEntry statsEntry)
            {
                var raceDuration = Convert.ToInt32((statsEntry.EndOfRace - statsEntry.StartOfRace).TotalSeconds);
                var errorRate    = statsEntry.TotalErrors / (double) (statsEntry.TextLength + statsEntry.TotalErrors);

                return $"{statsEntry.RaceId},,{statsEntry.Wpm},,{Math.Round(errorRate, 2)},,{raceDuration}";
            }


            /// <summary>
            ///     Take a statsEntry object, use it to form a datapoint and write the datapoint to a players statistics file
            /// </summary>
            /// <param name="statsEntry">A PlayerStatsEntry object to take values from</param>
            public void AddRaceData(PlayerStatsEntry statsEntry)
            {
                var data = FormatRaceData(statsEntry);

                var file = new StreamWriter($"{StatsDir}/{statsEntry.Name}", true);

                file.WriteLine(data);
            }


            public int GetNumRaces(string[] datapoints)
            {
                return datapoints.Length;
            }


            public int GetAverageWpm(string[] datapoints)
            {
                var wpm = 0;

                foreach (var line in datapoints)
                {
                    var items = line.Split(",,");
                    wpm += Convert.ToInt32(items[2]);
                }

                return (int) Math.Round(wpm / (double) datapoints.Length, 2);
            }


            public double GetAverageErrorRate(string[] datapoints)
            {
                double sumErrorRate = 0;

                foreach (var line in datapoints)
                {
                    var items = line.Split(",,");
                    sumErrorRate += Convert.ToDouble(items[3]);
                }

                return Math.Round(sumErrorRate / datapoints.Length, 2);
            }
        }
    }
}