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

            string[] output;

            if (args.Length >= 1)
            {
                output = InstructionsFromFile(args, marsRover, interpreter);
            }
            else
            {
                output = InstructionsFromConsole(marsRover, interpreter);
            }

            PrintOutput(output);

        }

        private static string[] InstructionsFromFile(string[] args, Rover marsRover, Interpreter interpreter)
        {
            string[] lines = File.ReadAllLines(args[0]);
            return interpreter.InterpretLines(lines);
        }

        private static string[] InstructionsFromConsole(Rover marsRover, Interpreter interpreter)
        {
            var lines = new List<string>();

            while (true)
            {

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    break;

                lines.Add(input);

            }
            return interpreter.InterpretLines(lines.ToArray());
        }

        private static void PrintOutput(string[] output)
        {
            foreach(string line in output)
                Console.WriteLine(line); 
        }


    }

}
