using System;
using System.IO;


namespace LEA


{
    public class Text
    {
        //TODO: Load Phrase based on Difficulty


        public string LoadRandomText()
        {
            Random   rnd        = new Random();
            string[] lines      = File.ReadAllLines("../../data/texts.csv");
            int      lineNumber = rnd.Next(1, lines.Length);
            string[] textToType = lines[lineNumber].Split(",,,");

            return textToType[2];
        }


        public string LoadExternalText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}