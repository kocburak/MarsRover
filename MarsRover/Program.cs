using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover marsRover = new Rover();

            Interpreter interpreter = new Interpreter(marsRover);

            if (args.Length >= 1)
            {
                InstructionsFromFile(args, marsRover, interpreter);
            }
            else
            {
                InstructionsFromConsole(marsRover, interpreter);
            }

        }

        private static void InstructionsFromFile(string[] args, Rover marsRover, Interpreter interpreter)
        {
            string[] lines = File.ReadAllLines(args[0]);
            InterpretLines(lines, marsRover, interpreter);
        }

        private static void InstructionsFromConsole(Rover marsRover, Interpreter interpreter)
        {
            var lines = new List<string>();

            while (true)
            {

                var input = Console.ReadLine();

                if (input == "")
                {
                    break;
                }
                lines.Add(input);

            }
            InterpretLines(lines.ToArray(), marsRover, interpreter);
        }

        private static void InterpretLines(string[] lines, Rover marsRover, Interpreter interpreter)
        {
            if (lines.Length < 3)
            {
                throw new ArgumentException("Input should contains at least 3 valid lines");
            }
            else if (lines.Length % 2 != 1)
            {
                throw new ArgumentException("Input should contains odd number of lines");
            }

            interpreter.InterpretMapLimits(lines[0]);

            for (int i = 1; i < lines.Length; i += 2)
            {
                interpreter.InterpretPosition(lines[i]);
                interpreter.InterpretCommands(lines[i + 1]);
                Console.WriteLine($"{marsRover.PositionX} {marsRover.PositionY} {marsRover.CurrentDirection}");
            }
        }


    }

}
