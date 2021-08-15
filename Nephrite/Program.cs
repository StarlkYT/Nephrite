﻿using System;
using System.IO;

namespace NephriteRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nephrite = new NephriteRunner();

            if (args.Length == 1)
            {
                try
                {
                    nephrite.Run(File.ReadAllText(args[0]));
                }
                catch (IOException)
                {
                    nephrite.ReportError($"Couldn't open the file. ({args[0]})");
                }
            }

            else if (args.Length == 0)
            {
                while (true)
                {
                    var input = Console.ReadLine();

                    if (!string.IsNullOrEmpty(input))
                        new NephriteRunner().Run(input);

                    else
                        break;
                }
            }

            else
                nephrite.ReportError("Usage: Press enter to start the REPL. Or write the file path to run it.");

        }
    }
}