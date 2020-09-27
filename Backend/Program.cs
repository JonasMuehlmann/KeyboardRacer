#region

using System;
using System.Collections.Generic;
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
                Ui.ShowMainMenu();
                // Disable mouse input/tracking report to not interfere with rendering
                Console.Write($"{Ansii.Csi}?1000l");

                var race = new Race("");

                if (Ui.WantsRandomText)
                {
                    race = new Race(Text.LoadRandomText());
                }
                else if (Ui.WantsTextFromDifficulty)
                {
                    ;
                }
                else
                {
                    race = new Race(Text.LoadExternalText(Ui.SelectedFile));
                }

                var _participants = new List<Participant> {new Player("Player", Fg.Magenta, race)};

                if (Ui.SelectedMenuEntry == "Singleplayer")
                {
                    for (var i = 0; i < Ui.NumBots; i++)
                    {
                        _participants.Add(new Bot($"Bot{i}", Fg.Blue, race, Ui.BotDifficulty));
                    }
                }

                race.Participants.AddRange(_participants);
                race.StartGameLoop();
                Ui.ShowPostgameView(race.PostGameStats);
                // Disable mouse input/tracking report to not interfere with rendering
                Console.Write($"{Ansii.Csi}?1000l");
            }
        }
    }
}