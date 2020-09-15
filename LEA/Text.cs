using System;
using System.IO;
namespace LEA


{
    public class Text
    {
        private int Id { get; set; } 
        private string Phrase { get; set; }
     
        
        //TODO: Constructor
        //TODO: Load Phrase based on Difficulty

        public string LoadRandomText()
        {
            Random rnd = new Random();
            string[] testarray= File.ReadAllLines("/home/assaro/RiderProjects/LEA/LEA/data/texts.csv");
            Console.WriteLine("Done");
            string[] text =testarray[rnd.Next(1,testarray.Length)].Split(",,,");
            return text[2];
        }

        public string LoadExternalText(string path)
        {
            return File.ReadAllText(path);
        }

    }
}