namespace LEA
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

            /*
            Console.WriteLine("\x1b[38;2;<255>;<125>;<0>mFoo");
            Console.WriteLine("\x1b[51;2;<0>;<125>;<255>mBar");
            // https://notes.burke.libbey.me/ansi-escape-codes/
            // \x1b or \e  or \u001b or \033 gibt Folgen von escape sequence an
            Console.Write("\x1b[36mTEST\x1b[0m");
            Thread.Sleep(800);
            // Back to beginning
            Console.Write("\r");
            // Go back one char
            // Console.Write("\b");
            Console.WriteLine("fooo");
            Console.WriteLine("baar");
            Console.WriteLine(Console.BufferHeight);
            int oldLine = Console.BufferHeight;
            Console.WriteLine(Console.BufferWidth);
            Thread.Sleep(800);
            Console.SetCursorPosition(0, 3);
            Console.Write("abcd");
            Console.SetCursorPosition(0, oldLine);

            Console.WriteLine($"{Effects.Bold}{Effects.Underline}{Effects.Italic}{Fg.BrightRed}{Bg.Blue}Bar{Fg.Reset}{Bg.Reset}{Effects.Reset}Bar"
                             );

            Console.WriteLine($"{Effects.Bold}Foo{Effects.Reset}");
            Console.WriteLine($"{Effects.Reverse}Foo{Effects.Reset}");
            Console.WriteLine($"{Effects.Italic}Foo{Effects.Reset}");
            Console.WriteLine($"{Effects.Underline}Foo{Effects.Reset}");
            */
            var text =
                "Lorem ipsum dolor sit amet.";

            var race = new Race(ref text);

            Participant[] players =
            {
                new Player("Foo", Fg.Magenta, race),
                new Bot("Bot1", Fg.Blue,  race, 5),
                new Bot("Bot2", Fg.Red,   race, 6),
                new Bot("Bot3", Fg.Green, race, 7)
            };

            race.Participants.AddRange(players);
            race.StartGameLoop();
        }
    }
}