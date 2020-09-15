using System;
using System.IO;
using System.Linq;
using System.Threading;


namespace LEA
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rnd = new Random();
            /*
            const int frametime = 1000 / 144 / 2;

            const string car = @"         ¸______¸
        ɍ___ǁ____ƪ___
        ¬(˽)----¬(˽)-'";

            Console.WriteLine(car);
            // for (var i = 0; i < 100; i++)
            for (var i = 0; i < 100; i++)
            {
                var indentation = new string(' ', i);

                var indented = string.Join(Environment.NewLine,
                                           new[] {indentation, indentation, indentation}
                                              .Zip(car.Split('\n'),
                                                   (a, b) => string.Join("", a, b)
                                                  )
                                          );

                Console.WriteLine(indented);
                Thread.Sleep(frametime * 5);
                Console.Clear();
                Console.WriteLine("\x1b[38;2;<255>;<125>;<0>mFoo");
                Console.WriteLine("\x1b[51;2;<0>;<125>;<255>mBar");
            }

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

            /* var text =
                 "Lorem ipsum dolor sit amet.";
 
             var race = new Race(ref text);
 
             Participant[] players = {new Bot("Bot1", Fg.Blue, race, 6),
                                 // new Player("Player2", Fg.Blue, race),
                                 // new Player("Player3", Fg.Blue, race)
                                 
                             };
 
             race.Participants.AddRange(players);
             race.StartRace();
             */
        }
    }
}