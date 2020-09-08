﻿using System;
using System.Linq;
using System.Threading;


namespace LEA
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var frametime = 1000 / 144 / 2;

                var car = @"         ¸______¸
        ɍ___ǁ____ƪ___
        ¬(˽)----¬(˽)-' ";

            // for (var i = 0; i < 100; i++)
            for (var i = 0; i < 1; i++)
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
                Console.WriteLine("\x1b[48;2;<0>;<125>;<255>mBar");
            }

            // https://notes.burke.libbey.me/ansi-escape-codes/
            // \x1b or \e  or \033 gibt Folgen von escape sequence an
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
        }
    }
}