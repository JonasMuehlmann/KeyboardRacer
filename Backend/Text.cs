#region

using System;
using System.IO;
using System.Text.RegularExpressions;

#endregion


namespace KeyboardRacer
{
    namespace Backend


    {
        public static class Text
        {
            //TODO: Load Phrase based on Difficulty
            private static readonly string _textDbPath = "../../../../Backend/data/texts.csv";


            /// <summary>
            ///     <para>Returns:</para>
            ///     A random text from the text database
            /// </summary>
            /// <returns>
            ///     A random text from the text database
            /// </returns>
            public static string LoadRandomText()
            {
                var rnd          = new Random();
                var lines        = File.ReadAllLines(_textDbPath);
                var lineNumber   = rnd.Next(1, lines.Length);
                var selectedText = lines[lineNumber].Split(",,,")[1];
                // Substringing removes quotation marks
                var textToType = selectedText.Substring(1, selectedText.Length - 2);

                return textToType;
            }


            /// <summary>
            ///     <para>Returns:</para>
            ///     The text with the specified ID, from the text database
            /// </summary>
            /// <param name="id">
            ///     The ID of the wanted text
            /// </param>
            /// <returns>
            ///     The text with the specified ID
            /// </returns>
            public static string LoadSpecificText(int id)
            {
                var lines = File.ReadAllLines(_textDbPath);

                return lines[id];
            }


            /// <summary>
            ///     <para>Returns:</para>
            ///     A string with the given files content
            /// </summary>
            /// <param name="path">
            ///     Path of a file who's content will be returned
            /// </param>
            /// <returns>
            ///     A string with the given files content
            /// </returns>
            public static string LoadExternalText(string path)
            {
                // Cutting out line feeds as they prevent finishing typing text
                return Regex.Replace(File.ReadAllText(path), @"\t|\n|\r", "");
            }
        }
    }
}