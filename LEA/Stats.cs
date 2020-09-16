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
        //TODO:ADD races calculation
        //TODO:ADD avgWPM calculation
        //TODO:ADD avgErrors calculation
        
        public string name;
        public string[] datapoints;
        public int races;
        public int avgWPM;
        public double avgErrors;

        private string Name
        {
            get => name;
            set => name = value;
        }

        private string[] Datapoints
        {
            get => datapoints;
            set => datapoints = value;
        }

        private int Races
        {
            get => races;
            set => races = value;
        }

        private int AvgWpm
        {
            get => avgWPM;
            set => avgWPM = value;
        }

        private double AvgErrors
        {
            get => avgErrors;
            set => avgErrors = value;
        }

        public string[] getPlayerNames()
        {
            return Enumerable.ToArray(Directory
                .GetFiles("../../../data/players/")
                .Select(f => Path.GetFileName(f)));
        }

        public void CreateNewPlayer(string name)
        {
            File.Create(("../../../data/players/" + name));
        }
    }
}