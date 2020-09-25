#region

using System;
using System.Collections.Generic;
using Backend;
using KeyboardRacer.Frontend;

#endregion


namespace KeyboardRacer
{
    namespace Backend
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Ui.Init();

                var race = new Race("");

                if (Ui._wantsRandomText)
                {
                    race = new Race(Text.LoadRandomText());
                }
                else if (Ui._wantsTextFromDifficulty)
                {
                    ;
                }
                else
                {
                    race = new Race(Text.LoadExternalText(Ui._selectedFile));
                }

                var _participants = new List<Participant> {new Player("Player", Fg.Magenta, race)};

                if (Ui._selectedMenuEntry == "Singleplayer")
                {
                    for (var i = 0; i < Ui._numBots; i++)
                    {
                        _participants.Add(new Bot($"Bot{i}", Fg.Blue, race, Ui._botDifficulty));
                    }
                }

                race.Participants.AddRange(_participants);
                // Disable mouse input/tracking report to not interfere with rendering
                Console.Write($"{Ansii.Csi}?1000l");
                Console.Clear();
                race.StartGameLoop();
            }
        }
    }
}