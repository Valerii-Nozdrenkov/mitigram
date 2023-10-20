using System;
using System.Collections.Generic;
using System.Linq;
using Traveler.Extensions;
using Traveler.Models;

namespace Traveler
{
    public static class TravelParser
    {
        public static (int x, int y, char direction)[] Run(string input)
        {
            var result = new List<(int, int, char)>();
            var trips = input.Split("POS=", StringSplitOptions.RemoveEmptyEntries);

            foreach (var trip in trips.Where(t => !t.StartsWith("//")))
            {
                var tripData = trip.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var initialPosition = tripData[0].Split(',');

                if (initialPosition.Length != 3)
                {
                    Console.WriteLine("Invalid position format. Processing next trip...");
                    continue;
                }

                if (!int.TryParse(initialPosition[0], out var initX))
                {
                    Console.WriteLine("Failed parse initial position X. Processing next trip...");
                    continue;
                }

                if (!int.TryParse(initialPosition[1], out var initY))
                {
                    Console.WriteLine("Failed parse initial position Y. Processing next trip...");
                    continue;
                }

                var initialDirection = initialPosition[2].FirstOrDefault();

                if (initialDirection == char.MinValue)
                {
                    Console.WriteLine("Failed parse initial direction. Processing next trip...");
                    continue;
                }

                var path = new RobotState(initX, initY, initialDirection);

                try
                {
                    foreach (var root in tripData.Skip(1).Where(t => !t.StartsWith("//")))
                    {
                        foreach (var step in root)
                        {
                            path.Move(step.GetMove());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to process root. Error: {ex.Message} Trying next one..");
                    continue;
                }

                result.Add(path.ToTupleFormat());
            }

            return result.ToArray();
        }
    }
}