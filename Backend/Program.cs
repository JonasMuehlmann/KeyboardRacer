using KeyboardRacer.Frontend;


namespace KeyboardRacer
{
    namespace Backend
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                // TODO: Maybe bundle a good terminal like alacritty or kritty with the game, maybe deploy via docker?

                #region RenderTest

                /*
                const string car = @"         ¸______¸
            ɍ___ǁ____ƪ___
            ¬(˽)----¬(˽)-'";
    
                Console.WriteLine(car);
    
                // for (var i = 0; i < 100; i++)
                for (var i = 0; i < 200; i++)
                {
                    var indentation = new string(' ', i);
    
                    var indented = string.Join(Environment.NewLine,
                                               new[] {indentation, indentation, indentation}
                                                  .Zip(car.Split('\n'),
                                                       (a, b) => string.Join("", a, b)
                                                      )
                                              );
    
                    Console.WriteLine(Bg.Black
                                    + Fg.BrightWhite
                                    + indented
                                    + '\n'
                                    + Bg.Blue
                                    + Fg.Black
                                    + indented
                                    + '\n'
                                    + Bg.Cyan
                                    + Fg.Blue
                                    + indented
                                    + '\n'
                                    + Bg.Green
                                    + Fg.Cyan
                                    + indented
                                    + '\n'
                                    + Bg.Magenta
                                    + Fg.Green
                                    + indented
                                    + '\n'
                                    + Bg.Red
                                    + Fg.Magenta
                                    + indented
                                    + '\n'
                                    + Bg.White
                                    + Fg.Red
                                    + indented
                                    + '\n'
                                    + Bg.Yellow
                                    + Fg.White
                                    + indented
                                    + '\n'
                                    + Bg.BrightBlack
                                    + Fg.Yellow
                                    + indented
                                    + '\n'
                                    + Bg.BrightBlue
                                    + Fg.BrightBlack
                                    + indented
                                    + '\n'
                                    + Bg.BrightCyan
                                    + Fg.BrightBlue
                                    + indented
                                    + '\n'
                                    + Bg.BrightGreen
                                    + Fg.BrightCyan
                                    + indented
                                    + '\n'
                                    + Bg.BrightMagenta
                                    + Fg.BrightGreen
                                    + indented
                                    + '\n'
                                    + Bg.Blue
                                    + Fg.Black
                                    + indented
                                    + '\n'
                                    + Bg.Cyan
                                    + Fg.Blue
                                    + indented
                                    + Fg.Reset
                                    + Bg.Reset
                                     );
    
                    Thread.Sleep(16);
                    Console.Clear();
                }
                */

                #endregion RenderTest


                Ui.Init();
                // var text = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr";

                // var race = new Race(ref text);

                // Participant[] players =
                // {
                //     new Player("Foo", Fg.Magenta, race),
                //     new Bot("Bot1", Fg.Blue,  race, 2),
                //     new Bot("Bot2", Fg.Red,   race, 3),
                //     new Bot("Bot3", Fg.Green, race, 4)
                // };

                // race.Participants.AddRange(players);
                // race.StartGameLoop();
            }
        }
    }
}