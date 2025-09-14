using System;
using System.IO;

namespace RobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Toy Robot Simulator - Table dimensions are 5x5. Valid directions: NORTH, SOUTH, EAST, WEST.");
            var robot = new Robot();

            if (args.Length > 0 && File.Exists(args[0]))
            {
                // Read commands from file
                var lines = File.ReadAllLines(args[0]);
                bool robotPlaced = false;
                foreach (var line in lines)
                {
                    var trimmed = line.Trim();
                    if (!robotPlaced && !string.IsNullOrWhiteSpace(trimmed) && !trimmed.StartsWith("#"))
                    {
                        if (!trimmed.ToUpper().StartsWith("PLACE"))
                        {
                            continue;
                        }
                        robotPlaced = true;
                    }
                    ProcessCommand(robot, trimmed);
                }
            }
            else
            {
                // Console mode
                Console.WriteLine("Enter commands (CTRL+C to exit):");
                string input;
                bool robotPlaced = false;
                while ((input = Console.ReadLine()) != null)
                {
                    var trimmed = input.Trim();
                    if (!robotPlaced && !string.IsNullOrWhiteSpace(trimmed) && !trimmed.StartsWith("#"))
                    {
                        if (!trimmed.ToUpper().StartsWith("PLACE"))
                        {
                            continue;
                        }
                        robotPlaced = true;
                    }
                    ProcessCommand(robot, trimmed);
                }
            }
        }

        static void ProcessCommand(Robot robot, string command)
        {
            if (string.IsNullOrWhiteSpace(command)) return;

            var parts = command.Split(' ');
            var cmd = parts[0].ToUpper();

            switch (cmd)
            {
                case "PLACE":
                    if (parts.Length > 1)
                    {
                        var args = parts[1].Split(',');
                        if (args.Length == 3)
                        {
                            bool validX = int.TryParse(args[0], out int xPosition);
                            bool validY = int.TryParse(args[1], out int yPosition);
                            bool validDir = Enum.TryParse(args[2], true, out Direction facingDirection);
                            if (!validX || !validY || !validDir)
                            {
                                Console.WriteLine("Invalid PLACE command. Table dimensions are 5x5. Directions can be: NORTH, SOUTH, EAST, WEST.");
                            }
                            else if (xPosition < 0 || xPosition > 4 || yPosition < 0 || yPosition > 4)
                            {
                                Console.WriteLine("Invalid coordinates. Table dimensions are 5x5 (0-4 for both X and Y). Directions can be: NORTH, SOUTH, EAST, WEST.");
                            }
                            else
                            {
                                robot.Place(xPosition, yPosition, facingDirection);
                            }
                        }
                    }
                    break;

                case "MOVE": robot.Move(); break;
                case "LEFT": robot.Left(); break;
                case "RIGHT": robot.Right(); break;
                case "REPORT": robot.Report(); break;
            }
        }
    }
}
