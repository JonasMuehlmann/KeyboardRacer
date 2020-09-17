using System;
using System.IO;


namespace LEA


{
    public class Text
    {
        //TODO: Load Phrase based on Difficulty


        /// <summary>
        /// <para>Returns:</para>
        /// A random text from the text database
        /// </summary>
        /// <returns>
        /// A random text from the text database
        /// </returns>
        public string LoadRandomText()
        {
            Random   rnd        = new Random();
            string[] lines      = File.ReadAllLines("../../data/texts.csv");
            int      lineNumber = rnd.Next(1, lines.Length);
            string[] textToType = lines[lineNumber].Split(",,,");

            return textToType[2];
        }


        /// <summary>
        /// <para>Returns:</para>
        /// The text with the specified ID, from the text database
        /// </summary>
        /// <param name="id">
        /// The ID of the wanted text
        /// </param>
        /// <returns>
        /// The text with the specified ID
        /// </returns>
        public string LoadSpecificText(int id)
        {
            string[] lines = File.ReadAllLines("../../data/texts.csv");

            return lines[id];
        }


        /// <summary>
        /// <para>Returns:</para>
        /// A string with the given files content
        /// </summary>
        /// <param name="path">
        /// Path of a file who's content will be returned
        /// </param>
        /// <returns>
        /// A string with the given files content
        /// </returns>
        public string LoadExternalText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}